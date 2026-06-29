using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WBHealthScheme.Api.Middleware;
using WBHealthScheme.Application.Interfaces;
using WBHealthScheme.Application.Interfaces.Repositories;
using WBHealthScheme.Application.Interfaces.Services;
using WBHealthScheme.Application.Services;
using WBHealthScheme.Infrastructure.Persistence;
using WBHealthScheme.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = false;
});

// API Versioning
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
}).AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "WBHealthScheme API",
        Version = "v1"
    });
});

// Database
var connectionString = builder.Configuration
    .GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string not found.");

builder.Services.AddDbContext<WBHSDbContext>(options =>
    options.UseSqlServer(connectionString)
);

// Repository
builder.Services.AddScoped<IEmployeeRegistrationRepository, EmployeeRegistrationRepository>();
builder.Services.AddScoped<IRegistrationVerificationRepository, RegistrationVerificationRepository>();
builder.Services.AddScoped<IApiLogRepository, ApiLogRepository>();


// Service
builder.Services.AddScoped<IEmployeeRegistrationService, EmployeeRegistrationService>();
builder.Services.AddScoped<IDdoVerificationService, DdoVerificationService>();
builder.Services.AddScoped<IHooVerificationService, HooVerificationService>();

//API
builder.Services.AddScoped<IApiKeyRepository, ApiKeyRepository>();
builder.Services.AddScoped<IApiKeyService, ApiKeyService>();
builder.Services.AddScoped<EncryptionService>();

builder.Services.AddScoped<IBeneficiaryAuthenticationRepository,
BeneficiaryAuthenticationRepository>();
builder.Services.AddScoped<IBeneficiaryAuthenticationService,
BeneficiaryAuthenticationService>();

builder.Services.AddScoped<IRatelistReturnRepository, RateListReturnRepository>();
builder.Services.AddScoped<IRatelistReturnService, RatelistReturnService>();

builder.Services.AddScoped<INewsRepository, NewsRepository>();
builder.Services.AddScoped<INewsService, NewsService>();

var app = builder.Build();

// Global Exception
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error");
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "WBHealthScheme API v1");
    });
}
app.UseMiddleware<RateLimitingMiddleware>();
app.UseMiddleware<ApiLoggingMiddleware>();
app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();