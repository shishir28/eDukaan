using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Monad.EDukaan.Service.Identity.Services.Interfaces;
using Monad.EDukaan.Service.Identity.Web.Api.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Monad.EDukaan.Service.Identity.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly ILoginService _loginService;

        public AccountController(ILoginService loginService,
        ILogger<AccountController> logger)
        {
            _loginService = loginService;
            _logger = logger;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Login")]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _loginService.FindByUsername(model.UserName);
                if (user != null)
                {
                    var result = await _loginService.SignIn(model.UserName, model.Password);
                    if (result.Succeeded)
                    {
                        Console.WriteLine("Login successfull");

                    }

                }

            }
            return new StatusCodeResult(412);

        }

    }
}
