using CryptoCurrencyApp.Infrastructure.Logging;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace CryptoCurrencyApp.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    { 
        private readonly ILogManager _logger;

        public ErrorController(ILogManager logger)
        {
            _logger = logger; 
        }

        [Route("error")]
        public IActionResult Error()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>();
            _logger.Error(@$"Error in API | {exception.Error.Message}", exception.Error);
            return Problem();
        }
       
    }
}
