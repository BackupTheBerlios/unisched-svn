using System;
using System.Collections.Generic;
using System.Text;

namespace Unisched.Data
{
    public class DataViewSettings
    {
        private bool isReadonly;
        private Dictionary<string, string> colNames;
        private Dictionary<string, bool> colReadonly;
        private Dictionary<string, bool> colVisible;

        public bool IsReadonly
        {
            get { return isReadonly; }
            set { isReadonly = value; }
        }

        public Dictionary<string, string> ColNames
        {
            get { return colNames; }
            set { colNames = value; }
        }

        public Dictionary<string, bool> ColReadonly
        {
            get { return colReadonly; }
            set { colReadonly = value; }
        }

        public Dictionary<string, bool> ColVisible
        {
            get { return colVisible; }
            set { colVisible = value; }
        }

        public DataViewSettings(bool isReadonly, Dictionary<string, string> colNames, Dictionary<string, bool> colReadonly, Dictionary<string, bool> colVisible)
        {
            IsReadonly = isReadonly;
            ColNames = colNames;
            ColReadonly = colReadonly;
            ColVisible = colVisible;
        }

        public DataViewSettings()
        {
            IsReadonly = true;
            ColNames = new Dictionary<string, string>();
            ColReadonly = new Dictionary<string, bool>();
            ColVisible = new Dictionary<string, bool>();
        }
    }
}
