using System.Windows.Forms;

namespace Unisched.Core.Interfaces
{
    public interface IDataUserControl
    {
        void Initialize(bool admin);

        Control GetControl();
    }
}
