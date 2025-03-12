using DataAccess.Context;
using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PerformanceLogWepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellation)
        {

            AppDbContext context = new();

            IList<DataAccess.Models.PerformanceLog> performanceLogs = await context.PerformanceLogs
                .OrderByDescending(p=>p.Id)
                .ToListAsync(cancellation);

            return Ok(performanceLogs);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllProductsAsync(CancellationToken cancellationToken)
        {

            AppDbContext context = new();
            IList<Product> products = await context.Products.ToListAsync(cancellationToken);

            return Ok(products.Take(10));
        }
    }
}
