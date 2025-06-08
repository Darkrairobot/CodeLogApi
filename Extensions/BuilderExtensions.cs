namespace CodeLogApi.Extensions;


public static class BuilderExtensions
{

    public static WebApplicationBuilder AddArchitectures(this WebApplicationBuilder builder)
    {
        // Add services to the container.
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();
        
        builder.Services.AddControllers();

        //adding context
        builder.Services.AddDbContext<AppDbContext>(option =>
        {
            option.UseSqlServer(builder.Configuration["connectionString"]);
        });
        
        builder.Services.AddIdentityApiEndpoints<UserModel>().AddEntityFrameworkStores<AppDbContext>();
        
        return builder;
    }
    
    public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
    {

        builder.Services.AddScoped<AuthService>();
        
        return builder;
    }
    
}