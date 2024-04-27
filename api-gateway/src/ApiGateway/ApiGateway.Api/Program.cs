using ApiGateway.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddMvcCore()
//    .AddApiExplorer()
//    .AddJsonFormatters();

//builder.Services.AddLambdaServer(options =>
//{
//    options.ApplicationBasePath = "/api";
//});

var app = builder.Build();

app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
