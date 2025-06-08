
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodeLogApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : Controller
{

    private readonly AuthService _authService;
    
    public AuthController(AuthService authService)
    {
        _authService = authService;
    }
    
    // GET
    [Authorize]
    [HttpGet("authenticate")]
    public IActionResult Authenticate()
    {
        return Ok();
    }

    [HttpPost("registerUser")]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterUserModel model)
    {
        try
        {
            var result = await _authService.RegisterUser(model);
            
            if(result.Success) return Ok(result.Message);
            
            string errors = string.Join("; ", result.IdentityResult!.Errors.Select(e => $"{e.Code}: {e.Description}"));
            
            return BadRequest(result.Message + errors);

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {

        try
        {
            
            var result = await _authService.Login(model.Email, model.Password, model.RememberMe);

            if (result.Success) return Ok(result.Message);
            
            return Unauthorized(result.Message);

        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        try
        {
            await _authService.Logout();
            return Ok("Logout success");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}