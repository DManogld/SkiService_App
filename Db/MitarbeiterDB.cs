using SkiService_App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiService_App.Db
{
    public class MitarbeiterDB
    {
        public static List<Mitarbeiter> GetMitarbeiter()
        {
            List<Mitarbeiter> mitarbeiters = new List<Mitarbeiter>()
            {
                new Mitarbeiter() {Kürzel="DMA", MitarbeiterNummer=220, Name="David Mangold", Title="Mitarbeiter"},
                new Mitarbeiter() {Kürzel="SST", MitarbeiterNummer=220, Name="Simon Staufer", Title="Mitarbeiter"},
                new Mitarbeiter() {Kürzel="AER", MitarbeiterNummer=220, Name="Alexander Ernst", Title="Abteil Leiter"},
                new Mitarbeiter() {Kürzel="RHU", MitarbeiterNummer=220, Name="Raphael Hug", Title="Mitarbeiter"}
            };

            Mitarbeiter DMA = new Mitarbeiter();
            DMA.Kürzel = "DMA";
            DMA.MitarbeiterNummer = 220;
            DMA.Name = "David MAngold";


            return mitarbeiters;
        }
    }
}
