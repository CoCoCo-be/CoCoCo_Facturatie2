using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoCoCo_Facturatie
{
    [ComplexType] 
    public class Partij
    {
        [Required]
        public String AanspreekTitel { get; set; }
        [Required]
        public String Naam { get; set; }
        [Required]
        public String Adres { get; set; }
        [Required]
        public String Adres2 { get; set; }
    }
    
 
}
