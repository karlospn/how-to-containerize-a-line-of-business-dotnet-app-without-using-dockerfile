using Microsoft.AspNetCore.Mvc;
using MyOwn.EmailService;

namespace BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DoWork()
        {
           _emailService.DoWork();
           return Ok();
        }

    }
}