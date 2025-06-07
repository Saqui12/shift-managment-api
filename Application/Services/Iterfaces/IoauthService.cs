using Application.Services.DTOs.Auth;
using Application.Services.DTOs.Calendar;

namespace Application.Services.Iterfaces
{
    public interface IoauthService
    {
        string GetAuthorizationUrl();
        Task<GoogleTokenResponse> ExchangeCodeForTokenAsync(string code);
        Task<CalendarListDto> GetUserCalendarsAsync(string accessToken);
        Task<List<EventsDto>> GetCalendarEventsAsync(string accessToken, string calendarId, DateTime? timeMin = null, DateTime? timeMax = null);
    }
}
