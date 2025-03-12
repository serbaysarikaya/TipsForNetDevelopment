

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// OpenAPI (Swagger) deste�ini ekleyelim
builder.Services.AddEndpointsApiExplorer(); // Minimal API deste�i
builder.Services.AddSwaggerGen(); // Swagger Dok�mantasyonu

var app = builder.Build();

// Geli�tirme ortam�nda Swagger'� etkinle�tirme
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Swagger JSON d�k�mantasyonunu aktive eder
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();