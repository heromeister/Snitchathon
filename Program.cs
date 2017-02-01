using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.Security.Principal;
using Microsoft.Win32;

namespace SnitchExe
{
    class Program
    {
        static void Main(string[] args)
        {
            /*bool flag = (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
            Console.WriteLine(flag);*/

            /*WindowsIdentity winId = WindowsIdentity.GetCurrent();
            Console.WriteLine(winId);*/

            Microsoft.Win32.SystemEvents.SessionSwitch += new Microsoft.Win32.SessionSwitchEventHandler(SystemEvents_SessionSwitch);
        }

        static void SystemEvents_SessionSwitch(object sender, Microsoft.Win32.SessionSwitchEventArgs e)
        {
            WindowsIdentity winId = WindowsIdentity.GetCurrent();
            if (e.Reason == SessionSwitchReason.SessionLock)
            {
                Console.WriteLine("User is locked");
            }
            else if (e.Reason == SessionSwitchReason.SessionUnlock)
            {
                Console.WriteLine("User is logged");
            }
        }
    }
}
