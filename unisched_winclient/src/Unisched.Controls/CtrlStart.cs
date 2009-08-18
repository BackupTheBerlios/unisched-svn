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
