using DataAccess.Context;
using DataAccess.Models;
using Microsoft.OpenApi.Models;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1"));
}

app.Use(async (context, next) =>
{
    var stopwatch = new Stopwatch();
    stopwatch.Start();

    AppDbContext _context = new();
    PerformanceLog performanceLog = new()
    {
        MethodName = context.Request.Path.Value,
        StatingDate = DateTime.Now

    };

     await next(context);

    performanceLog.EndingDate = DateTime.Now;

    performanceLog.TransactionTimeInSeconds=(int)stopwatch.Elapsed.TotalSeconds;
    performanceLog.TransactionTimeInMilliseconds = (int)stopwatch.Elapsed.TotalMilliseconds;


    _context.PerformanceLogs.Add(performanceLog);
    await _context.SaveChangesAsync();
    _context.Dispose();
    stopwatch.Stop();

});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();