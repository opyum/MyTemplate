using Blazored.LocalStorage;
using CoolPlanner.CrossCutting;
using CoolPlanner.CrossCutting.Constantes;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace CoolPlanner.Web
{
    public class LoginApiClient
    {
        private readonly HttpClient httpClient;
        private readonly ILocalStorageService localStorageService;
        private readonly ILogger<LoginApiClient> logger;
        private static readonly JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public LoginApiClient(HttpClient httpClient, ILocalStorageService localStorageService, ILogger<LoginApiClient> logger)
        {
            this.httpClient = httpClient;
            this.localStorageService = localStorageService;
            this.logger = logger;
        }

        #region Login

        public async Task<bool> RegisterUser(UserRecordModel request)
        {
            var response = await httpClient.PostAsJsonAsync("register", request);
            return await ProcessResponse(response);
        }

        public async Task<AccessTokenResponse> LoginUser(LoginRequest request)
        {
            var response = await httpClient.PostAsJsonAsync("login", request);
            return await ProcessResponse<AccessTokenResponse>(response);
        }

        public async Task<string> TestToken()
        {
            await SetToken();
            var response = await httpClient.GetAsync("test");
            return await ProcessResponse<string>(response);
        }

        

        public async Task<bool> CreateUser(UserRecordModel request)
        {
            var response = await httpClient.PostAsJsonAsync("api/users", request);
            return await ProcessResponse(response);
        }

        private async Task<T> ProcessResponse<T>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                if (typeof(T) == typeof(string))
                    return (T)(object)responseContent;

                return JsonSerializer.Deserialize<T>(responseContent, options);
            }
            else
            {
                LogError(response);
                return default;
            }
        }

        private async Task<bool> ProcessResponse(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
                return true;
            else
            {
                LogError(response);
                return false;
            }
        }
        #endregion

        #region Mission
        public async Task<List<MissionModel>> GetAllMission()
        {
            var response = await httpClient.GetAsync("api/missions");
            return await ProcessResponse<List<MissionModel>>(response);
        }
        public async Task<MissionModel> CreateMission(MissionModel request)
        {
            var response = await httpClient.PostAsJsonAsync("api/missions", request);
            return await ProcessResponse<MissionModel>(response);
        }

        #endregion

        #region Transverse
        private async void LogError(HttpResponseMessage response)
        {
            var test = response.Content.ReadAsStringAsync();
            logger.LogError($"Erreur : {response.StatusCode}, {response.RequestMessage}, {await response.Content.ReadAsStringAsync()}");
        }
        private async Task SetToken()
        {
            var token = await localStorageService.GetItemAsync<string>(Const.AUTH_TOKEN);
            var userId = await localStorageService.GetItemAsync<string>(Const.USER_ID);
            var familyId = await localStorageService.GetItemAsync<string>(Const.FAMILY_ID);
            if (!string.IsNullOrEmpty(token))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                httpClient.DefaultRequestHeaders.Add(Const.USER_ID, userId);
                httpClient.DefaultRequestHeaders.Add(Const.FAMILY_ID, familyId);
            }
        }
        #endregion
    }
}
