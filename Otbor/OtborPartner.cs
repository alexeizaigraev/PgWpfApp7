using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PgWpfApp7
{
    internal class OtborPartner : Papa
    {
        internal static void MainOtborPartner(string partnerChoise)
        {

            List<List<string>> outVec = new List<List<string>>();
            List<string> keys = new List<string>();
            var count = 0;
            var arr = GetTermDepOnPartner(partnerChoise);
            foreach (var item in arr)
            {
                string term = item[0];
                if (term == "") continue;

                if (keys.Contains(term)) { continue; }
                else
                {
                    keys.Add(term);
                    outVec.Add(item);
                    count++;
                }

            }

            DbOtborMet.AddOtborArrTermDep(outVec);
            info = $"{count}";
        }

        public static List<List<string>> GetTermDepOnPartner(string parStr)
        {
            #region
            List<List<string>> outList = new List<List<string>>();
            using (var context = new postgresContext())
            {
                var department = context.Departments;
                var terminal = context.Terminals;

                var lingVar = from dep in department
                              join term in terminal on dep.Department1 equals term.Department
                              where dep.Partner == parStr
                              select
                              new
                              {
                                  terminal = term.Termial,
                                  department = dep.Department1
                              };

                foreach (var item in lingVar)
                {
                    List<string> vec = new List<string>();

                    vec.Add(item.terminal);
                    vec.Add(item.department);

                    outList.Add(vec);
                }
            };
            return outList;
            #endregion
        }
    }
}
