using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        [HttpGet("Hello")]
        public ActionResult Get() => Ok("Hello");
    }
}