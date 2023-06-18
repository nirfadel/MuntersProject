using MuntersProject.Core.Model;
using MuntersProject.Core.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRouting();
builder.Services.AddControllers();
builder.Services.AddMemoryCache();
builder.Services.AddScoped<IMainService, MainService>();
builder.Services.AddScoped<IGiphyService, GiphyService>();
builder.Services.Configure<GiphySettings>(
    builder.Configuration.GetSection("GiphySettings"));
builder.Services.AddMvc();
var app = builder.Build();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


app.Run();
