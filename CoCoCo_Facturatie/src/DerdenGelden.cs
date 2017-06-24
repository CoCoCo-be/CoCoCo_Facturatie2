using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoCoCo_Facturatie
{
    [Table("DerdenGelden")]
    public class DerdenGeld
    {
    #region Fields
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DerdenGeldId { get; set; }
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
        public Decimal Totaal { get; set; }
        public Boolean Betaald { get; set; }
        public String OGMNummer { get; set; }
        public Decimal TotaalBetaald { get; set; }
        public Int16 Status { get; set; }
        public Boolean InterCompany { get; set; }
        #endregion

    #region ForeignKeys
        public virtual ICollection<Aanmaning> Aanmaningen { get; set; }
    #endregion 
    }
}