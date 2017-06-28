using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoCoCo_Facturatie
{
    public class Provisie
    {
    #region Fields
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProvisieId { get; set; }
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
        public Decimal Ereloon { get; set; }
        public Decimal BTW { get; set; }
        public Decimal Gerechtskosten { get; set; }
        public Decimal Totaal { get; set; }
        public Boolean Betaald { get; set; }
        public String OGMNummer { get; set; }
        public Decimal EreloonBetaald { get; set; }
        public Decimal BTWBetaald { get; set; }
        public Decimal GerechtskostenBetaald { get; set; }
        public Int16 Status { get; set; }
        public Boolean InterCompany { get; set; }
    #endregion

    #region ForeignKeys
        public virtual ICollection<Factuur> Facturen { get; }
        public virtual ICollection<Aanmaning> Aanmaningen { get; }
    #endregion

        public Provisie(Decimal _Ereloon, Decimal _BTW, Decimal _Gerechtskosten, Decimal _Totaal, Boolean _InterCompany)
        {
            Tijd = DateTime.Now;
            Wie = Properties.Settings.Default.GebruikerInitialen;
            DossierNummer = Variabelen.DossierNummer;
            DossierNaam = Variabelen.DossierName;
            Partij = Variabelen.Partij;
            Ereloon = _Ereloon;
            BTW = _BTW;
            Gerechtskosten = _Gerechtskosten;
            Totaal = _Totaal;
            Betaald = false;
            //OGMNummer = GenereerVolgendOGMNummer();
            EreloonBetaald = 0;
            BTWBetaald = 0;
            GerechtskostenBetaald = 0;
            Status = 0;
            InterCompany = _InterCompany;
        }
    }
}