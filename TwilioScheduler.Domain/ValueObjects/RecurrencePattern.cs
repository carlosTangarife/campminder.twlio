using System;
using TwilioScheduler.Domain.Enums;

namespace TwilioScheduler.Domain.ValueObjects
{
    public class RecurrencePattern
    {
        public RecurrenceType Type { get; private set; }
        public int Interval { get; private set; }
        public DayOfWeek[] DaysOfWeek { get; private set; }
        public int? DayOfMonth { get; private set; }
        public int? MonthOfYear { get; private set; }
        
        private RecurrencePattern() {}
        
        public static RecurrencePattern Daily(int interval = 1)
        {
            return new RecurrencePattern
            {
                Type = RecurrenceType.Daily,
                Interval = interval
            };
        }
        
        public static RecurrencePattern Weekly(int interval = 1, DayOfWeek[] daysOfWeek = null)
        {
            return new RecurrencePattern
            {
                Type = RecurrenceType.Weekly,
                Interval = interval,
                DaysOfWeek = daysOfWeek ?? [DayOfWeek.Monday]
            };
        }
        
        public static RecurrencePattern Monthly(int interval = 1, int dayOfMonth = 1)
        {
            return new RecurrencePattern
            {
                Type = RecurrenceType.Monthly,
                Interval = interval,
                DayOfMonth = dayOfMonth
            };
        }
        
        public static RecurrencePattern Yearly(int interval = 1, int monthOfYear = 1, int dayOfMonth = 1)
        {
            return new RecurrencePattern
            {
                Type = RecurrenceType.Yearly,
                Interval = interval,
                MonthOfYear = monthOfYear,
                DayOfMonth = dayOfMonth
            };
        }
    }
}