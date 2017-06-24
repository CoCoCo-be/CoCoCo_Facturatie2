using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Cococo_Facturatie
{
    public class Partij
    {
        public String AanspreekTitel { get; set; }
        public String Naam { get; set; }
        public String Adres { get; set; }
        public String Adres2 { get; set; }
    }
    public class KostenSchema
    {
        [Key]
        public int Id { get; set; }
        public String Naam { get; set; }
        public Decimal Prestaties { get; set; }
        public Decimal Wacht { get; set; }
        public Decimal Verplaatsing { get; set; }
        public Decimal Mail { get; set; }
        public Decimal Fotokopie { get; set; }
        public Decimal Dactylo { get; set; }
        public Boolean Archive { get; set; }
        public Decimal BTW { get; set; }
    }

    public class Provisies
    {   
        [Key]
        public int Id { get; set; }
        public DateTime Tijd { get; set; }
        public String Wie { get; set; }
        public String DossierNummer { get; set; }
        public String DossierNaam { get; set; }
        public Partij Partij { get; set; }

    }
}
