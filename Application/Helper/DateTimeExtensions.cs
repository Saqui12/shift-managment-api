using System;
namespace Application.Helper
{
    public static class DateTimeExtensions
    {
        public static DateOnly GetStartOfTheWeek(this DateOnly dates)
        {
            
            switch (dates.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    return dates.AddDays(-6);
                case DayOfWeek.Monday:
                    return dates.AddDays(-0);
                case DayOfWeek.Tuesday:
                    return dates.AddDays(-1);
                case DayOfWeek.Wednesday:
                    return dates.AddDays(-2);
                case DayOfWeek.Thursday:
                    return dates.AddDays(-3);
                case DayOfWeek.Friday:
                    return dates.AddDays(-4);
                case DayOfWeek.Saturday:
                    return dates.AddDays(-5);
                default:
                    throw new ArgumentOutOfRangeException();
            }

        }
        public static DateOnly? GetStartOfTheWeek(this DateOnly? date)
        {
            if (date.HasValue)
            {
                // Llama al método de extensión para DateOnly (no nullable)
                return date.Value.GetStartOfTheWeek();
            }
            return null;
        }

    }
}
