using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCoCo_Facturatie
{
    [Table("Aanmaningen")]
    public class Aanmaning
    {
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AanmaningId { get; set; }
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Tijd { get; set; }
        [Required, StringLength(2)]
        public String Wie { get; set; }
        [Required]
        public String DossierNummer { get; set; }
        [Required]
        public String DossierNaam { get; set; }
        [Required]
        public Partij Partij { get; set; }
        [Required]
        public Byte AanmaningVersie { get; set; }
    }
}
