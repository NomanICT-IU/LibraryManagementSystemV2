

using LibraryManagementSystemV2.Api.Authentication;
using LibraryManagementSystemV2.Api.Exceptions;
using Microsoft.OpenApi;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// ======================================================
// Controllers
// ======================================================
builder.Services
    .AddControllers(options =>
    {
        options.Filters.Add<GlobalValidationFilter>();
    })
    .AddXmlSerializerFormatters();

// ======================================================
// API Explorer
// ======================================================
builder.Services.AddEndpointsApiExplorer();

// ======================================================
// Serilog
// ======================================================
builder.Services.AddSerilog((services, loggerConfiguration) =>
{
    loggerConfiguration
        .ReadFrom.Configuration(builder.Configuration)
        .ReadFrom.Services(services);
});

// ======================================================
// Swagger
// ======================================================
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Library Management System API",
        Version = "v1"
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter your JWT Bearer token."
    });

    options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference("Bearer", document)] =
            new List<string>()
    });

});

// ======================================================
// Data Access
// ======================================================
builder.Services.AddApplicationDataAccess(
    builder.Configuration.GetConnectionString("DefaultConnection"));

// ======================================================
// Application Services
// ======================================================
builder.Services.AddApplicationServices();
// ======================================================
// Authentication
// ======================================================
builder.Services.AddJwtAuthentication();
builder.Services.AddPermissionAuthorization();

// ======================================================
// Build Application
// ======================================================
var app = builder.Build();

// ======================================================
// Custom Exception Handler
// ======================================================
app.UseMiddleware<CustomExceptionHandler>();

// ======================================================
// Serilog Request Logging
// ======================================================
app.UseSerilogRequestLogging();

// ======================================================
// Swagger
// Swagger UI will open at the root URL (/)
// ======================================================
app.UseSwagger();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint(
        "/swagger/v1/swagger.json",
        "Library Management System API v1");

    // Open Swagger directly at /
    options.RoutePrefix = string.Empty;
});

// ======================================================
// HTTPS Redirection
// ======================================================
app.UseHttpsRedirection();

// ======================================================
// Authorization
// ======================================================
app.UseAuthentication();
app.UseAuthorization();

// ======================================================
// Controllers
// ======================================================
app.MapControllers();

// ======================================================
// Run Application
// ======================================================
app.Run();