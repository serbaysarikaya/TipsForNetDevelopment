using DataAccess.Context;
using DataAccess.Models;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// OpenAPI (Swagger) desteðini ekleyelim
builder.Services.AddEndpointsApiExplorer(); // Minimal API desteði
builder.Services.AddSwaggerGen(); // Swagger Dokümantasyonu

var app = builder.Build();

// Geliþtirme ortamýnda Swagger'ý etkinleþtirme
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Swagger JSON dökümantasyonunu aktive eder
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1"));
}

app.Use(async (context, next) =>
{
	try
	{
		

		await next(context);
	}
	catch (Exception e)
	{

		AppDbContext _context = new();
		DataAccess.Models.ErrorLog errorLog = new()
		{
			MethotName = context.Request.Path.Value,
			Trace = e.StackTrace,
			CreateDate = DateTime.Now

		};

		await _context.ErrorLogs.AddAsync(errorLog);
		await _context.SaveChangesAsync();

        context.Response.ContentType = "text/plain";
		await context.Response.WriteAsync(e.Message);
		
	}
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();