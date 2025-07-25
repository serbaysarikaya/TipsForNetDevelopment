var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// OpenAPI (Swagger) desteğini ekleyelim
builder.Services.AddEndpointsApiExplorer(); // Minimal API desteği
builder.Services.AddSwaggerGen(); // Swagger Dokümantasyonu

var app = builder.Build();

// Geliştirme ortamında Swagger'ı etkinleştirme
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Swagger JSON dökümantasyonunu aktive eder
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();