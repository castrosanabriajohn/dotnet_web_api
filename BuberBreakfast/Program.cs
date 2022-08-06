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
  // using built-in capability of the framework to add try catches surrounding the following middlewares
  app.UseExceptionHandler("/error"); // if an exception is encountered, it's catched and switches the request route to the one specified and re-executes the request 
  app.UseHttpsRedirection();
  app.MapControllers();
  app.Run();
}
