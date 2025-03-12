using DataAccess.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ErrorLog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet("[action]")]
        public IActionResult Calculate(int x, int y)
        {
            int result = x / y;

            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetErrorLog(int x, int y)
        {
            AppDbContext context = new();
            IList<DataAccess.Models.ErrorLog> errorLogs = await context.ErrorLogs.OrderByDescending(p => p.CreateDate).ToListAsync();

            return Ok(errorLogs);

        }
    }
}
