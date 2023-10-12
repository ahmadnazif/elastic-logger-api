using ElasticLoggerApi.Services;
using ILogger = ElasticLoggerApi.Services.ILogger;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

switch (config["LoggerUsed"])
{
    case "Elastic": builder.Services.AddSingleton<ILogger, ElasticLogger>(); break;
    case "Console": builder.Services.AddSingleton<ILogger, ConsoleLogger>(); break;
}

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(x => x.AddDefaultPolicy(y => y.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

builder.WebHost.ConfigureKestrel(x =>
{
    var httpPort = int.Parse(config["Port"]);
    x.ListenAnyIP(httpPort);
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
