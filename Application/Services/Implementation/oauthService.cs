using Application.Services.DTOs.Auth;
using Application.Services.DTOs.Calendar;
using Application.Services.Iterfaces;
using Azure;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Web;

namespace Application.Services.Implementation
{
    public class oauthService : IoauthService
    {
        private readonly IConfiguration _config;
        private readonly IHttpClientFactory _httpClientFactory;

        public oauthService(IConfiguration config, IHttpClientFactory httpClientFactory)
        {
            _config = config;
            _httpClientFactory = httpClientFactory;
        }

        public string GetAuthorizationUrl()
        {
            var clientId = _config["Authentication:Google:ClientId"];
            var redirectUri = _config["Authentication:Google:RedirectUri"];
            var scope = "https://www.googleapis.com/auth/calendar.readonly";

            var response= $"https://accounts.google.com/o/oauth2/v2/auth" +
                   $"?response_type=code" +
                   $"&client_id={clientId}" +
                   $"&redirect_uri={HttpUtility.UrlEncode(redirectUri)}" +
                   $"&scope={HttpUtility.UrlEncode(scope)}" +
                   $"&access_type=offline&prompt=consent";
           
            Console.WriteLine(response);

            return response;
        }

        public async Task<GoogleTokenResponse> ExchangeCodeForTokenAsync(string code)
        {
            var clientId = _config["Authentication:Google:ClientId"];
            var clientSecret = _config["Authentication:Google:ClientSecret"];
            var redirectUri = _config["Authentication:Google:RedirectUri"];

            var client = _httpClientFactory.CreateClient();

            var content = new FormUrlEncodedContent(new[]
            {
              new KeyValuePair<string, string>("code", code),
              new KeyValuePair<string, string>("client_id", clientId),
              new KeyValuePair<string, string>("client_secret", clientSecret),
              new KeyValuePair<string, string>("redirect_uri", redirectUri),
              new KeyValuePair<string, string>("grant_type", "authorization_code")
            });

            var response = await client.PostAsync("https://oauth2.googleapis.com/token", content);
            response.EnsureSuccessStatusCode();
           

            var result = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<GoogleTokenResponse>(result);
        }

        public async Task<CalendarListDto> GetUserCalendarsAsync(string accessToken)
        {
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await client.GetAsync("https://www.googleapis.com/calendar/v3/users/me/calendarList");

              var result=  await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<CalendarListDto>(result);
        }
        public async Task<List<EventsDto>> GetCalendarEventsAsync(string accessToken, string calendarId, DateTime? timeMin = null, DateTime? timeMax = null)
        {
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var query = new List<string>
              {
                   "singleEvents=true",
                   "orderBy=startTime"
               };

            if (timeMin.HasValue)
                query.Add($"timeMin={Uri.EscapeDataString(timeMin.Value.ToUniversalTime().ToString("o"))}");

            if (timeMax.HasValue)
                query.Add($"timeMax={Uri.EscapeDataString(timeMax.Value.ToUniversalTime().ToString("o"))}");

            var queryString = "?" + string.Join("&", query);
            var url = $"https://www.googleapis.com/calendar/v3/calendars/{Uri.EscapeDataString(calendarId)}/events{queryString}";
            Console.WriteLine(url);

            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();

            using var document = JsonDocument.Parse(result);
            var itemsElement = document.RootElement.GetProperty("items");

            var events = JsonSerializer.Deserialize<List<EventsDto>>(itemsElement.GetRawText(), new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return events;
        }
    }
}
