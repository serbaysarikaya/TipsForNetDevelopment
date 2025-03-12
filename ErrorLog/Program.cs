using DataAccess.Context;
using DataAccess.Models;
using Microsoft.AspNetCore.Builder;

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