using System;
using System.Collections.Generic;
using System.Text;

namespace Unisched.Calendar
{
    public class Appointment
    {
        private String name;
        private DateTime start;
        private DateTime end;

        public Appointment(string name, DateTime start, DateTime end)
        {
            Name = name;
            Start = start;
            End = end;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public DateTime Start
        {
            get { return start; }
            set { start = value; }
        }

        public DateTime End
        {
            get { return end; }
            set { end = value; }
        }
    }
}