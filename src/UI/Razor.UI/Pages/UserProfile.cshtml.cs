namespace Razor.UI.Pages
{
    [Authorize(AuthenticationSchemes = OpenIdConnectDefaults.AuthenticationScheme)]
    public class UserProfileModel : PageModel
    {
        private readonly IUserService _userService;

        public UserProfileModel(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        public ApplicationUserModel UserDetail { get; set; } = new ApplicationUserModel();

        public async Task<IActionResult> OnGetAsync(string categoryName)
        {
            var userDetail = await _userService.GetUserDetail();
            UserDetail = userDetail;
            return Page();
        }
    }
}
