namespace CodeLogApi.Models.Results;

public class AuthResultModel
{
    public bool Success { get; set; }
    
    public string? Message { get; set; }
    
    public SignInResult? SignInResult { get; set; }
    
    public IdentityResult? IdentityResult { get; set; }
}