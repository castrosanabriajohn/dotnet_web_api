// New template dotnet 6    
var builder = WebApplication.CreateBuilder(args);
{
  builder.Services.AddControllers(); // Bulder variable can be used for dependency injection and configuration
}
var app = builder.Build(); // App variable for managing the request pipeline
{
  app.UseHttpsRedirection();
  app.MapControllers();
  app.Run();
}
