using LibraryManagementSystemV2.Api.Exceptions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Serilog
builder.Services.AddSerilog((services, loggerConfiguration) =>
{
    loggerConfiguration
        .ReadFrom.Configuration(builder.Configuration)
        .ReadFrom.Services(services);
});

// Controllers
builder.Services.AddControllers(options =>
{
    options.Filters.Add<GlobalValidationFilter>();
});

// Add Controllers
builder.Services.AddControllers();

// OpenAPI
builder.Services.AddOpenApi();

// Swagger
builder.Services.AddSwaggerGen();

// Data Access
builder.Services.AddApplicationDataAccess(
    builder.Configuration.GetConnectionString("DefaultConnection"));

// Application Services
builder.Services.AddApplicationServices();

var app = builder.Build();

// Custom Exception Handler
app.UseMiddleware<CustomExceptionHandler>();

// Serilog request logging
app.UseSerilogRequestLogging();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // OpenAPI
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();