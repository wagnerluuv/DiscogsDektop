using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libDicogsDesktopControls.Extensions
{
    public static class ControlExtensions
    {
        public static void InvokeIfRequired(this Control control, Action action)
        {
            if (control.InvokeRequired)
            {
                control.Invoke((MethodInvoker)action.Invoke);
            }
            else
            {
                action.Invoke();
            }
        }
    }
}
