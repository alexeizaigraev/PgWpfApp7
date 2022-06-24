using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PgWpfApp7
{
    internal class RefreshFromInData : Papa
    {
        internal static void MainRefreshFromInData()
        {
            ClearInfo();
            /*
            Process proc = new Process();
            try
            {
                //SayBlue("\nSharpForPy start...\n");
                proc.StartInfo.FileName = @"C:\SharpForPy\SharpForPy.exe";
                proc.Start();
                proc.WaitForExit();
                SayBlue("\nSharpForPy finish\n");
            }
            catch (Exception ex) { SayRed("\nno start SgsarpForPy\n"); }
            finally
            {
                try { proc.Kill(); }
                catch { }
            }
            */

            DbOtborMet.RefreshOtborFromFile();
            DbDepMeth.RefreshDepartment();
            DbTermMeth.RefreshTerminal();
            Say("\n\tall refreshed");
        }
    }
}
