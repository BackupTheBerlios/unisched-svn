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

        public Control GetControl()
        {
            return this;
        }
    }
}
