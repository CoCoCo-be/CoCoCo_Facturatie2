using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCoCo_Facturatie
{
    public class OverzichtBetalingen
    {
        public DateTime Tijd { get; set; }
        public String Wie { get; set; }
        public String DossierNummer { get; set; }
        public String DossierNaam { get; set; }
        public Partij Partij { get; set; }
        public Decimal BTW { get; set; }
        public Decimal Totaal { get; set; }
        public Decimal Betaald { get; set; }
    }
}
