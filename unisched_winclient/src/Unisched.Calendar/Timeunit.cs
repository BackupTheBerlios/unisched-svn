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
