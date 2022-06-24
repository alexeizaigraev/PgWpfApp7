using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PgWpfApp7
{
    internal class DbComonDataMeth
    {

        public static List<List<string>> GetAllComonData()
        {
            #region
            var outList = new List<List<string>>();
            using (var context = new postgresContext())
            {
                var comonData = context.ComonData;
                var w = comonData.ToList();
                foreach (var line in w)
                {
                    var lineVec = new List<string> { 
                        line.Partner,
                        line.Code,
                        line.KassOwner,
                        line.Email,
                        line.Gdrive,
                        line.Regime,
                        line.TermOwner,
                        line.TermShablon,
                        line.SoftVersion,
                        line.LimitKass
                    };
                    outList.Add(lineVec);
                }

            }
            return outList;
            #endregion
        }

        public static string MkKassOwner(string cod)
        {
            #region
            string rez = "";
            using (var context = new postgresContext())
            {
                var koko = context.ComonData;
                var lingVar = from ko in koko
                              where ko.Code == cod
                              select
                              new
                              {
                                  ko.KassOwner
                              };

                foreach (var line in lingVar)
                {
                    rez = line.KassOwner;
                    break;
                }

            }
            return rez;
            #endregion
        }

        public static string MkKassEnail(string cod)
        {
            #region
            string rez = "";
            using (var context = new postgresContext())
            {
                var koko = context.ComonData;
                var lingVar = from ko in koko
                              where ko.Code == cod
                              select
                              new
                              {
                                  ko.Email
                              };

                foreach (var line in lingVar)
                {
                    rez = line.Email;
                    break;
                }

            }
            return rez;
            #endregion
        }

    }
}
