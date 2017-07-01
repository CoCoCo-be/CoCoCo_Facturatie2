using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoCoCo_Facturatie
{
    [Table("Facturen")]
    public abstract class Factuur
    {
    #region Fields
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None), Column(Order = 1)]
        public int FactuurJaar { get; set; }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column(Order = 2), Index(IsUnique = true)]
        public int FactuurID { get; set; }
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Tijd { get; set; }
        [Required, StringLength(2)]
        public String Wie { get; set; }
        [Required]
        public String DossierNummer { get; set; }
        [Required]
        public String DossierNaam { get; set; }
        [Required]
        public Partij Partij { get; set; }
    #endregion

        public int GetFactuurNummer()
        {
            return int.Parse(FactuurJaar.ToString() + FactuurID.ToString());
        }
    }

    [Table("Facturen")]
    public class EreloonNotaFactuur : Factuur
    {
    #region Fields
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
        [Required]
        public Decimal Totaal { get; set; }
    #endregion

    #region ForeignKeys
        [Required]
        public virtual KostenSchema KostenSchema { get; set; }
    #endregion
    }


    public class ProvisieFactuur : Factuur
    {
    #region Fields
        [Required]
        public Decimal ProvisieErelonen { get; set; }
        [Required]
        public Decimal ProvisieBTW { get; set; }
        [Required]
        public Decimal ProvisiegerechtsKosten { get; set; }
        [Required]
        public Decimal Totaal { get; set; }
    #endregion

    }
}
