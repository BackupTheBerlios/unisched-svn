/*
 *   This file is part of Unisched Winclient.
 *
 *   Unisched Winclient is free software: you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation, either version 3 of the License, or
 *   (at your option) any later version.
 *
 *   Unisched Winclient is distributed in the hope that it will be useful,
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *   GNU General Public License for more details.
 *
 *   You should have received a copy of the GNU General Public License
 *   along with Unisched Winclient.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;

namespace Unisched.Calendar
{
    /// <summary>
    /// Class, that descripes a time unit
    /// </summary>
    public class Timeunit
    {
        private DateTime startTime;
        private TimeSpan duration;

        /// <summary>
        /// Constructor, initializes the class.
        /// </summary>
        /// <param name="startTime">Start of the time unit.</param>
        /// <param name="duration">Duration of the time unit.</param>
        public Timeunit(DateTime startTime, TimeSpan duration)
        {
            StartTime = startTime;
            Duration = duration;
        }

        /// <summary>
        /// Constructor, initializes the class.
        /// </summary>
        /// <param name="minutesToStart">The minutes (from midnight 0:00) to the start of the time unit.</param>
        /// <param name="durationMinutes">The duration of the time unit in minutes.</param>
        public Timeunit(int minutesToStart, int durationMinutes)
        {
            int hours = (int)(minutesToStart / 60);
            hours %= 24;
            int minutes = minutesToStart % 60;
            StartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hours, minutes, 0);
            Duration = new TimeSpan(0, durationMinutes, 0);
        }

        /// <summary>
        /// Start of the rime unit.
        /// </summary>
        public DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }

        /// <summary>
        /// Duration of the time unit.
        /// </summary>
        public TimeSpan Duration
        {
            get { return duration; }
            set { duration = value; }
        }
    }
}
