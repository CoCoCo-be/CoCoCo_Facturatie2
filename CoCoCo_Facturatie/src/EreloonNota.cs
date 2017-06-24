using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoCoCo_Facturatie
{
    public class EreloonNota
    {
    #region Fields
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EreloonNotaId { get; set; }
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
        public UInt16 Dactylo { get; set; }
        public UInt16 Fotokopie { get; set; }
        public UInt16 Fax { get; set; }
        public UInt16 Verplaatsing { get; set; }
        public Decimal BijkomendeKosten { get; set; }
        public Decimal Forfait { get; set; }
        public TimeSpan EreloonUren { get; set; }
        public TimeSpan WachtUren { get; set; }
        public Decimal BTW { get; set; }
        public Decimal Rolzetting { get; set; }
        public Decimal Dagvaarding { get; set; }
        public Decimal Betekening { get; set; }
        public Decimal Uitvoering { get; set; }
        public Decimal Anderen { get; set; }
        public Decimal Derden { get; set; }
        public Decimal Totaal { get; set; }
        public Boolean Betaald { get; set; }
        public String OGMNummer { get; set; }
        public Int16 Status { get; set; }
        public Boolean InterCompany { get; set; }
    #endregion

    #region foreignKeys
        [Required]
        public virtual KostenSchema KostenSchema { get; set; }

        public virtual ICollection<Provisie> Provisies { get; set; }
        public virtual ICollection<Factuur> Facturen { get; set; }
        public virtual ICollection<Aanmaning> Aanmaningen { get; set; }
    #endregion
    }

}
