using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CoCoCo_Facturatie
{
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
}
