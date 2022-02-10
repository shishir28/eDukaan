using Microsoft.AspNetCore.Authorization;
using User.API.Models;
using User.API.Services;

namespace User.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize("ClientIdPolicy")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        private readonly IIdentityParser<ApplicationUser> _appUserParser;

        public UserController(IIdentityParser<ApplicationUser> appUserParser, ILogger<UserController> logger)
        {
            _appUserParser = appUserParser ?? throw new ArgumentNullException(nameof(appUserParser));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApplicationUser))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApplicationUser>> GetUserDetail()
        {
            try
            {
                var user = _appUserParser.Parse(HttpContext.User);
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
    }
}