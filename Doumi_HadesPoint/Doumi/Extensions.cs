namespace Doumi
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public static class Extensions
    {
        public static void ThreadSafeInvoke(this Control control, Action action)
        {
            try
            {
                if (!control.InvokeRequired)
                {
                    action();
                }
                else
                {
                    control.Invoke(action);
                }
            }
            catch
            {
            }
        }
    }
}

