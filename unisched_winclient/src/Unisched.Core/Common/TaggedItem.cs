using System;
using System.Collections.Generic;
using System.Text;

namespace Unisched.Core.Common
{
    public class TaggedItem
    {
        private string displayName;
        private object tag;

        public string DisplayName
        {
            get { return displayName; }
            set { displayName = value; }
        }

        public object Tag
        {
            get { return tag; }
            set { tag = value; }
        }

        public TaggedItem(string displayName, object tag)
        {
            this.displayName = displayName;
            this.tag = tag;
        }

        public override string ToString()
        {
            return displayName;
        }
    }
}
