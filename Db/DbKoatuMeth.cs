using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PgWpfApp7
{
    internal class DbKoatuMeth
    {

        public static string MkKoatu2(string city, string distrCity, string koatu)
        {
            #region
            string rez = "";
            using (var context = new postgresContext())
            {
                var koko = context.KoatuSprs;
                var lingVar = from ko in koko
                              where (ko.KoatuOld == koatu
                              && (ko.Place == city || ko.Place == distrCity)
                              )
                              select
                              new
                              {
                                  ko2 = ko.Koatu2
                              };

                foreach (var line in lingVar)
                {
                    rez = line.ko2;
                    break;
                }

            }
            return rez;
            #endregion
        }

    }
}
