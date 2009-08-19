using System.Windows.Forms;

namespace Unisched.Core.Interfaces
{
    /// <summary>
    /// Interface that allows to use a control in administrative and normal mode.
    /// </summary>
    public interface IDataUserControl
    {
        /// <summary>
        /// Initializes the control on the basis of an administrative flag.
        /// </summary>
        /// <param name="admin">Determines whether the control should initialize in administrative mode.</param>
        void Initialize(bool admin);

        /// <summary>
        /// Returns the Control that uses the Interface.
        /// </summary>
        /// <returns>Control that implements the interface.</returns>
        Control GetControl();
    }
}
