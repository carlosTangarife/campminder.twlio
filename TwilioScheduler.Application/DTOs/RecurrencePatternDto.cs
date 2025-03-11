namespace TwilioScheduler.Application.DTOs
{
    public class RecurrencePatternDto
    {
        public string Type { get; set; }
        public int Interval { get; set; }
        public string[] DaysOfWeek { get; set; }
        public int? DayOfMonth { get; set; }
        public int? MonthOfYear { get; set; }
    }
}