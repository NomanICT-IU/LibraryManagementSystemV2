var builder = WebApplication.CreateBuilder(args);

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