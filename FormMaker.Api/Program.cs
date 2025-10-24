using FormMaker.Api.Data;
using FormMaker.Api.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();

// Add DbContext with SQLite for local development
var connectionString = builder.Configuration.GetValue<string>("Values:ConnectionStrings:FormMakerDb")
    ?? builder.Configuration.GetValue<string>("ConnectionStrings:FormMakerDb")
    ?? "Data Source=formmaker.db";

builder.Services.AddDbContext<FormMakerDbContext>(options =>
{
    options.UseSqlite(connectionString);
});

// Register JWT Token Service
// For development, use a default secret if not configured
var jwtSecret = builder.Configuration.GetValue<string>("Values:JwtSecret")
    ?? builder.Configuration.GetValue<string>("JwtSecret")
    ?? "your-secret-key-min-32-characters-long-for-development";
var jwtIssuer = builder.Configuration.GetValue<string>("Values:JwtIssuer")
    ?? builder.Configuration.GetValue<string>("JwtIssuer")
    ?? "FormMaker";
var jwtAudience = builder.Configuration.GetValue<string>("Values:JwtAudience")
    ?? builder.Configuration.GetValue<string>("JwtAudience")
    ?? "FormMakerClient";

builder.Services.AddSingleton(sp => new TokenService(jwtSecret, jwtIssuer, jwtAudience));

// Register Auth Service
builder.Services.AddScoped<AuthService>();

// Register Template Service
builder.Services.AddScoped<TemplateService>();

builder.Services
    .AddApplicationInsightsTelemetryWorkerService()
    .ConfigureFunctionsApplicationInsights();

builder.Build().Run();
