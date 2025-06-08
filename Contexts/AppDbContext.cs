
namespace CodeLogApi.Contexts;

public class AppDbContext(DbContextOptions options ) : IdentityDbContext<UserModel>(options)
{
    
}