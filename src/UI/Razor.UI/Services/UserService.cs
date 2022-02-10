using Newtonsoft.Json;
using System.Text.Json;

namespace Razor.UI.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _client;
        private readonly ILogger<UserService> _logger;


        public UserService(HttpClient client, ILogger<UserService> logger)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ApplicationUserModel> GetUserDetail()
        {

            var response = await _client.GetAsync($"/User");
            try
            {
                _logger?.LogInformation(await response.Content.ReadAsStringAsync());
                var result = await response.ReadContentAs<ApplicationUserModel>();
                _logger.LogInformation("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                var opt = new JsonSerializerOptions() { WriteIndented = true };
                string strJson = System.Text.Json.JsonSerializer.Serialize<ApplicationUserModel>(result, opt);

                _logger?.LogInformation(strJson);
                _logger.LogInformation("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }

        }
    }
}
