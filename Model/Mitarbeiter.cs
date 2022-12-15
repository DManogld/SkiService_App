using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiService_App.Model
{
    /// <summary>
    /// Egenschaften von Mittarbeiter
    /// </summary>
    public class Mitarbeiter
    {
        public string Kürzel { get; set; }
        public string Name { get; set; }
        public int MitarbeiterNummer { get; set; }
        public string Title { get; set; }
        public string ApiKey { get; set; }
    }

    
}
