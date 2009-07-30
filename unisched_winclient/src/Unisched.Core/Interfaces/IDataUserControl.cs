using System.Windows.Forms;

namespace Unisched.Core.Interfaces
{
    public interface IDataUserControl
    {
        void Initialize(bool admin);
        void Edit();
        void Abort();
        void Save();
        bool IsEditable();
        Control GetControl();
    }
}
