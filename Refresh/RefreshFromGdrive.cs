using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PgWpfApp7
{
    internal class RefreshFromGdrive : Papa
    {
        internal static void MainRefreshFromGdrive()
        {
            ClearInfo();

            try
            {
                FromGdriveToInData("departments.csv");
                FromGdriveToInData("terminals.csv");
                FromGdriveToInData("otbor.csv");

                DbOtborMet.RefreshOtborFromFile();
                DbDepMeth.RefreshDepartment();
                DbTermMeth.RefreshTerminal();
                Say("\n\tall refreshed");
            }

            catch (Exception ex) { info += ex.Message; }


        }

        static void FromGdriveToInData(string fName)
        {
            CopyOneFile(Path.Combine(dbGdrivePath, fName), Path.Combine(dataInPath, fName));
            info += fName + "\n";
        }
    }
}
