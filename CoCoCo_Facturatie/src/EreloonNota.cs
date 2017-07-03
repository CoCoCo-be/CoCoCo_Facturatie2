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
        public Decimal Derden { get; set; } // Bedragen al ontvangen van derden (Niet in Totaal).
        public Decimal Totaal { get; set; } // Totaal zonder rekening te houden met derden en provisies.
        public Boolean Betaald { get; set; }
        public String OGMNummer { get; set; }
        public Int16 Status { get; set; }
        public Boolean InterCompany { get; set; }
    #endregion

    #region foreignKeys
        [Required]
        public virtual KostenSchema KostenSchema { get; set; }

        public virtual ICollection<Provisie> Provisies { get; }
        public virtual ICollection<Factuur> Facturen { get; }
        public virtual ICollection<Aanmaning> Aanmaningen { get; }
    #endregion

        internal EreloonNota()
        {
            Partij = Variabelen.Partij;
            DossierNummer = Variabelen.DossierNummer;
            DossierNaam = Variabelen.DossierNaam;
            Wie = Variabelen.Wie;
            Dactylo = Fotokopie = Fax = Verplaatsing = 0;
            BijkomendeKosten = Forfait = BTW = Rolzetting = Dagvaarding = Betekening = Uitvoering = Anderen = Derden = Totaal = 0;
            EreloonUren = WachtUren = new TimeSpan(0);
            OGMNummer = "+++000/0000/00000+++";
            Status = 0;
            Betaald = InterCompany = false;
            KostenSchema = null;
        }

        public void Berekenen()
        {
            if (null == KostenSchema)
            {
                return;
            }
            Totaal = Dactylo * KostenSchema.Dactylo + Fotokopie * KostenSchema.Fotokopie + Fax * KostenSchema.Fotokopie +
                Verplaatsing * KostenSchema.Verplaatsing + BijkomendeKosten + Forfait + (Decimal)EreloonUren.TotalHours * KostenSchema.Prestaties +
                (Decimal)WachtUren.TotalHours * KostenSchema.Wacht;
            BTW = Totaal * KostenSchema.BTW;
            Totaal += BTW + (Rolzetting + Dagvaarding + Betekening + Uitvoering + Anderen);
        }
    }

}
