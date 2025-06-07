namespace Application.Services.DTOs.Calendar
{
    public class EventsDto
    {
        public string id { get; set; }
        public string colorId { get; set; }
        public string summary { get; set; }
        public string description { get; set; }
        public EventTime start { get; set; }
        public EventTime end { get; set; }
        public string location { get; set; }
        public string status { get; set; }
        public string htmlLink { get; set; }
        public string created { get; set; }
        public string updated { get; set; }
        public Organizer organizer { get; set; }
    }

    public class  EventTime
    {
        public DateOnly date { get; set; }
        public DateTime dateTime { get; set; }
        public string timeZone { get; set; }

    }
    public class Organizer
    {
        public string email { get; set; }
        public string displayName { get; set; }
        public bool self { get; set; }
    }
}

