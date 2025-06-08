
var builder = WebApplication.CreateBuilder(args);

builder.AddArchitectures().AddServices();

var app = builder.Build();

app.UseArchitectures();

app.Run();
