using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PgWpfApp7
{
    internal class Activaciya : Papa
    {
        internal static void MainActivaciya()
        {

            ClearInfo();
            string head = "№ п/п;№ відділення ТОВ«ЕПС»;Адреса відділення; ЗН;ФН;Дата";

            string fName = "Activaciya.csv";

            var docPath = Path.Combine(dataOutPath, "DOC");
            docPath = Path.Combine(docPath, fName);

            info = "";
            if (head != "") info = head + "\n";
            var data = GetData();
            int count = 0;
            foreach (var line in data)
            {
                count += 1;
                info += $"{count};{String.Join(";", line)};{DateNowNormal()}\n";
            }


            info = info.Replace(" 0:00:00", "").Replace("null", "");

            infoFname = docPath;
        }

        private static List<List<string>> GetData()
        {
            #region
            List<List<string>> outList = new List<List<string>>();
            using (var context = new postgresContext())
            {
                var department = context.Departments;
                var terminal = context.Terminals;
                var otbor = context.Otbors;
                var w = department.ToList();

                var lingVar = from dep in department
                              join term in terminal on dep.Department1 equals term.Department
                              join otb in otbor on term.Termial equals otb.Term
                              select
                              new
                              {
                                  dep = dep.Department1,
                                  addr = dep.Address,
                                  serial = term.SerialNumber,
                                  fiscal = term.FiscalNumber
                              };

                foreach (var line in lingVar)
                {

                    List<string> lineList = new List<string>();
                    lineList.Add(line.dep);
                    lineList.Add(line.addr);
                    lineList.Add(line.serial);
                    lineList.Add(line.fiscal);

                    outList.Add(lineList);
                }

            }
            return outList;
            #endregion
        }
    }
}
