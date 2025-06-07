namespace Application.Services.DTOs.Calendar
{
    public class CalendarListDto
    {
        public string nextSyncToken { get; set; }

        public List<CalendarDto> items { get; set; }


    }
}
