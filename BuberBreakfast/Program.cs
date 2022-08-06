using BuberBreakfast.Services.Breakfasts;

var builder = WebApplication.CreateBuilder(args);
{
  // Builder variable can be used for dependency injection and configuration
  builder.Services.AddControllers();
  /* every time an object is instantiated, if that object requests the interface in the constructor the use 
  the Object as its implementation, specifying singleton tells the framework the first time the interface is
  requested to create an object, following requests will use the same instance of the object, see AddScoped */
  builder.Services.AddScoped<IBreakfastService, BreakfastService>();
}
var app = builder.Build(); // App variable for managing the request pipeline
{
  app.UseHttpsRedirection();
  app.MapControllers();
  app.Run();
}
