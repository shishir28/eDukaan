using Identity.API.Services;
using Microsoft.Extensions.Logging;

namespace Identity.API.Controller
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IIdentityServerInteractionService _interaction;
        //private readonly IOptionsSnapshot<AppSettings> _settings;
        private readonly IRedirectService _redirectSvc;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IIdentityServerInteractionService interaction, 
            //IOptionsSnapshot<AppSettings> settings, 
            IRedirectService redirectSvc,
            ILogger<HomeController> logger
            )
        {
            _interaction = interaction;
            //_settings = settings;
            _redirectSvc = redirectSvc;
            _logger = logger;
        }

        public IActionResult Index(string returnUrl)
        {
            
            return View();
        }

        public IActionResult ReturnToOriginalApplication(string returnUrl)
        {
            if (returnUrl != null)
                return Redirect(_redirectSvc.ExtractRedirectUriFromReturnUrl(returnUrl));
            else
                return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Shows the error page
        /// </summary>
        public async Task<IActionResult> Error(string errorId)
        {
            var vm = new ErrorViewModel();

            // retrieve error details from identityserver
            var message = await _interaction.GetErrorContextAsync(errorId);
            if (message != null)
            {
                vm.Error = message;

                _logger.LogError(message.Error);
                _logger.LogError(message.ErrorDescription);

            }

            return View("Error", vm);
        }

    }
}
