using ControllersExample.Controllers;

var builder = WebApplication.CreateBuilder(args);
//Instead of adding one controller at a time via AddTransient, then you can use the AddControllers method and then it will add all of them.
//builder.Services.AddTransient<HomeController>();
builder.Services.AddControllers();
var app = builder.Build();
app.UseRouting();
//adds all controllers that implement Controller. You do not need to manually make endpoints here
app.MapControllers();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});

app.Run();