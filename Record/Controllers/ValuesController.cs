using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Record.Dtos;

namespace Record.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        [HttpPost("[action]")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {       
            loginDto.Email =string.Empty;
                return Ok("Login Success");          
            
        }

        [HttpPost("[action]")]
        public IActionResult LoginWithRecord([FromBody] Login login)
        {
            //loginDto.Email =string.Empty;
            return Ok("Login Success");

        }

    }
}
