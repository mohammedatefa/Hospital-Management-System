using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalSystemManagement.BusinessLogic
{
    internal class PressNumber
    {
        public static void KeyPressNumber(object s,KeyPressEventArgs e) {
            if (e.KeyChar == (char)Keys.Enter)
                e.Handled = true;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            { e.Handled = true; }
            if ((e.KeyChar == '.') && ((s as TextBox).Text.IndexOf('.') > -1))
                e.Handled = true;
        }
    }
}
