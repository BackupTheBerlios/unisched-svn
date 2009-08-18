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
