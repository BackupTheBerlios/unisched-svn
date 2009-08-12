using System;

namespace Unisched.Calendar
{
    public class Booking
    {
        private int curId;

        public int CurId
        {
            get { return curId; }
            set { curId = value; }
        }

        private DateTime begin;

        public DateTime Begin
        {
            get { return begin; }
            set { begin = value; }
        }

        private DateTime end;

        public DateTime End
        {
            get { return end; }
            set { end = value; }
        }

        public Booking(int curId, DateTime begin, DateTime end)
        {
            this.curId = curId;
            this.begin = begin;
            this.end = end;
        }
    }
}
