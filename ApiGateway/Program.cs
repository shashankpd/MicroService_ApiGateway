using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath).AddJsonFile("Ocelot.json", optional: false, reloadOnChange: true);

builder.Services.AddControllers();
builder.Services.AddOcelot();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseOcelot().Wait();

app.MapControllers();

app.Run();