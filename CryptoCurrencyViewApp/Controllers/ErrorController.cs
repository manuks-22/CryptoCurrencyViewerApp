using Microsoft.AspNetCore.Mvc;

namespace CryptoCurrencyApp.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("error")]
        public IActionResult Error() => Problem();
    }
}
