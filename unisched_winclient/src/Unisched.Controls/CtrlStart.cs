using System.Windows.Forms;
using Unisched.Core.Interfaces;

namespace Unisched.Controls
{
    public partial class CtrlStart : UserControl, IDataUserControl
    {
        public CtrlStart()
        {
            InitializeComponent();
        }

        public void Initialize(bool admin)
        {
            // nothing to do
        }

        public Control GetControl()
        {
            return this;
        }
    }
}
