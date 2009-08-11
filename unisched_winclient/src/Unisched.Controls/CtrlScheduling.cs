using System.Windows.Forms;
using Unisched.Core.Interfaces;

namespace Unisched.Controls
{
    public partial class CtrlScheduling : UserControl, IDataUserControl
    {
        public CtrlScheduling()
        {
            InitializeComponent();
        }

        public void Initialize(bool admin)
        {
            ctrlCalendar.SetAccess(admin);
        }

        public void Edit()
        {
            
        }

        public void Abort()
        {
            
        }

        public void Save()
        {
            
        }

        public bool IsEditable()
        {
            return true; 
        }

        public Control GetControl()
        {
            return this;
        }
    }
}
