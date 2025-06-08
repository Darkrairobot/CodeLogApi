namespace CodeLogApi.Extensions;

public static class AppExtensions
{

    public static WebApplication UseArchitectures(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }
        
        app.MapControllers();
        
        app.UseAuthentication();
        app.UseAuthorization();

        //app.UseHttpsRedirection();
        
        return app;
    }
    
}