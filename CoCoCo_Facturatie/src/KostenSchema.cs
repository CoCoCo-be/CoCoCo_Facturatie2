using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoCoCo_Facturatie
{
    public class KostenSchema
    {
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KostenSchemaId { get; set; }
        [Required]
        public String Naam { get; set; }
        [Required]
        public Decimal Prestaties { get; set; }
        [Required]
        public Decimal Wacht { get; set; }
        [Required]
        public Decimal Verplaatsing { get; set; }
        [Required]
        public Decimal Mail { get; set; }
        [Required]
        public Decimal Fotokopie { get; set; }
        [Required]
        public Decimal Dactylo { get; set; }
        [Required]
        public Boolean Archive { get; set; }
        [Required]
        public Decimal BTW { get; set; }
    }

}
