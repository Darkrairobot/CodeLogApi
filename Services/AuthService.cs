

namespace CodeLogApi.Services;

public class AuthService
{
    
    private readonly UserManager<UserModel> _userManager;
    private readonly SignInManager<UserModel> _signInManager;

    public AuthService(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }
    
    public async Task<AuthResultModel> RegisterUser(RegisterUserModel model)
    { 
        
        var result = await _userManager.CreateAsync(new UserModel() { UserName = model.UserName, Email = model.Email} , model.Password);
        
        if(result.Succeeded) return new AuthResultModel() {Success = true, Message = "User created successfully", IdentityResult = result};
        
        return new AuthResultModel() {Success = false, Message = "User creation failed ", IdentityResult = result};
        
    }

    public async Task<AuthResultModel> Login(string email, string password, bool rememberMe)
    {
        
        var user = await _userManager.FindByEmailAsync(email);
        
        if(user == null) return new AuthResultModel() {Success = false, Message = "User not found"};
        
        if(!await _userManager.CheckPasswordAsync(user,password)) return new AuthResultModel() {Success = false, Message = "Password doesn't match"};
        
        var result = await _signInManager.PasswordSignInAsync(user.UserName!, password, rememberMe, false);
        
        if (!result.Succeeded) return new AuthResultModel() {Success = false, Message = "Failed to login"};
        
        return new AuthResultModel() {Success = true, Message = "User Logged with success"};
        
    }

    public async Task Logout()
    {
        await _signInManager.SignOutAsync();
    }
}