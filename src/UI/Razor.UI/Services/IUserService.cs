namespace Razor.UI.Services
{
    public interface IUserService
    {
        Task<ApplicationUserModel> GetUserDetail();
    }

}
