using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Office.Interop.Word;

namespace CoCoCo_Facturatie
{
    [Table("DerdenGelden")]
    public class DerdenGeld
    {
        private decimal v1;
        private decimal v2;
        private decimal v3;

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
        public Decimal SchadeloosStelling { get; set; }
        public Decimal Gerechtskosten { get; set; }
        public Decimal Totaal { get; set; }
        public Boolean Betaald { get; set; }
        public String OGMNummer { get; set; }
        public Decimal SchadeloosStellingBetaald { set; get; }
        public Decimal GerechtskostenBetaald { get; set; }
        public Decimal TotaalBetaald { get; set; }
        public Int16 Status { get; set; }
        #endregion

    #region ForeignKeys
        public virtual ICollection<Aanmaning> Aanmaningen { get; }
    #endregion 

        public DerdenGeld(decimal _schadeloosStelling, decimal _gerechtsKosten, decimal _Totaal)
        {
            Tijd = DateTime.Now;
            Wie = Variabelen.Wie;
            DossierNummer = Variabelen.DossierNummer;
            DossierNaam = Variabelen.DossierNaam;
            Partij = Variabelen.Partij;
            SchadeloosStelling = _schadeloosStelling;
            Gerechtskosten = _gerechtsKosten;
            Totaal = _Totaal;
            Betaald = false;
            OGMNummer = new OGMNummer(DossierNummer, true).ToString();
            SchadeloosStellingBetaald = 0;
            GerechtskostenBetaald = 0;
            Status = 0;
        }

        internal void PrintText(Selection selection)
        {
            String Text = null;

            if ((SchadeloosStelling == 0 ) && (Gerechtskosten != 0))
            {
                Text = "Mag ik u vragen om de gerechtskosten ter waarde van " +
                    Gerechtskosten.ToString("C", Variabelen.Cultuur) +
                    " te betalen.";
            }
            else if (Gerechtskosten != 0)
            {
                Text = "Mag ik u vragen een bedrag van " + Totaal.ToString("C", Variabelen.Cultuur) + 
                    " te betalen." + Environment.NewLine + 
                    "Dit bedrag is als volgt samengesteld: Schadeloosstelling " +
                    SchadeloosStelling.ToString("C", Variabelen.Cultuur) + " en gerechtskosten " + 
                    Gerechtskosten.ToString("C", Variabelen.Cultuur);
            }
            else
            {
                Text = "Mag ik u vragen om een schadeloosstelling ter waarde van " +
                    SchadeloosStelling.ToString("C", Variabelen.Cultuur) +
                    " te betalen.";
            }

            Text += Environment.NewLine + "U kunt dit bedrag overmaken op rekeningnummer BE96 0012 4751 7505 met als mededeling: " +
                OGMNummer + ".";

            selection.TypeText(Text);
        }
    }
}