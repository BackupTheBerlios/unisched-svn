using System;

namespace Unisched.Calendar
{
    public class Appointment
    {
        private String name;
        private DateTime start;
        private DateTime end;
        private bool custom;

        public Appointment(string name, DateTime start, DateTime end, bool custom)
        {
            Name = name;
            Start = start;
            End = end;
            Custom = custom;
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

        public bool Custom
        {
            get { return custom; }
            set { custom = value; }
        }
    }
}