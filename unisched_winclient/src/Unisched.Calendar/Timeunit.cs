using System;
using System.Collections.Generic;
using System.Text;

namespace Unisched.Calendar
{
    /// <summary>
    /// Klasse, die eine Zeiteinheit beschreibt
    /// </summary>
    public class Timeunit
    {
        private DateTime startTime;
        private TimeSpan duration;

        public Timeunit(DateTime startTime, TimeSpan duration)
        {
            StartTime = startTime;
            Duration = duration;
        }

        public Timeunit(int minutesToStart, int durationMinutes)
        {
            int hours = (int)(minutesToStart / 60);
            hours %= 24;
            int minutes = minutesToStart % 60;
            StartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hours, minutes, 0);
            Duration = new TimeSpan(0, durationMinutes, 0);
        }

        /// <summary>
        /// Startzeit
        /// </summary>
        public DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }

        /// <summary>
        /// Dauer
        /// </summary>
        public TimeSpan Duration
        {
            get { return duration; }
            set { duration = value; }
        }
    }
}
