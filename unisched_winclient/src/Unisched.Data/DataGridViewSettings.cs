using System;
using System.Collections.Generic;
using System.Text;

namespace Unisched.Data
{
    public class DataGridViewSettings
    {
        private bool isReadonly;
        private Dictionary<string, string> colNames;
        private Dictionary<string, bool> colReadonly;
        private Dictionary<string, bool> colVisible;

        public bool IsReadonly
        {
            get { return isReadonly; }
        }

        public Dictionary<string, string> ColNames
        {
            get { return colNames; }
        }

        public Dictionary<string, bool> ColReadonly
        {
            get { return colReadonly; }
        }

        public Dictionary<string, bool> ColVisible
        {
            get { return colVisible; }
        }

        public DataGridViewSettings(bool isReadonly, Dictionary<string, string> colNames, Dictionary<string, bool> colReadonly, Dictionary<string, bool> colVisible)
        {
            this.isReadonly = isReadonly;
            this.colNames = colNames;
            this.colReadonly = colReadonly;
            this.colVisible = colVisible;
        }
    }
}
