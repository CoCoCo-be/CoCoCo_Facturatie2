using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Office.Interop.Word;
using System.Linq;

namespace CoCoCo_Facturatie
{
    public class EreloonNota
    {
        #region Not mapped properties
        [NotMapped]
        public decimal TotaalProvisiesErelonen { get; }
        [NotMapped]
        public decimal TotaalProvisiesBTW { get; }
        [NotMapped]
        public decimal TotaalProvisiesGerechtskosten { get; }

        private decimal totaalBTW, totaalNietBTW;
        #endregion

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
        public Int16 Dactylo { get; set; }
        public Int16 Fotokopie { get; set; }
        public Int16 Fax { get; set; }
        public Int16 Verplaatsing { get; set; }
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
            OGMNummer = new OGMNummer(DossierNummer).ToString();
            Status = 0;
            Betaald = InterCompany = false;
            KostenSchema = null;
            using (var context = new FacturatieModel())
            {
                IQueryable<Provisie> provisies = context.Provisies.Where(p => (p.Betaald == false) && (p.DossierNummer == DossierNummer));
                if (provisies.Count() > 0)
                {
                    TotaalProvisiesErelonen = provisies.Sum(p => p.Ereloon) - provisies.Sum(p => p.EreloonBetaald);
                    TotaalProvisiesBTW = provisies.Sum(p => p.BTW) - provisies.Sum(p => p.BTWBetaald);
                    TotaalProvisiesGerechtskosten = provisies.Sum(p => p.Gerechtskosten) - provisies.Sum(p => p.GerechtskostenBetaald);
                }
            }
        }

        internal void Berekenen()
        {
            if (null == KostenSchema)
            {
                return;
            }
            totaalBTW = Dactylo * KostenSchema.Dactylo + Fotokopie * KostenSchema.Fotokopie + Fax * KostenSchema.Fotokopie +
                Verplaatsing * KostenSchema.Verplaatsing + BijkomendeKosten + Forfait + (Decimal)EreloonUren.TotalHours * KostenSchema.Prestaties +
                (Decimal)WachtUren.TotalHours * KostenSchema.Wacht;
            BTW = totaalBTW * KostenSchema.BTW;
            totaalNietBTW = Rolzetting + Dagvaarding + Betekening + Uitvoering + Anderen;
            Totaal = totaalBTW + BTW + totaalNietBTW;
        }

        internal void PrintText(Selection selection)
        {
            Berekenen();
            var text = "Ik stelde de eindafrekening in dit dossier op. Het overzicht vindt u hieronder." + Environment.NewLine;
            selection.TypeText(text);

            var tabel = selection.Tables.Add(selection.Range, 1, 7, WdDefaultTableBehavior.wdWord9TableBehavior);

            var rij1 = tabel.Rows[1];
            rij1.Borders.Enable = (int)WdLineStyle.wdLineStyleNone;

            InsertErelonenBureelKosten(tabel);


            InsertGerechtsKosten(tabel);


            var provisies = TotaalProvisiesErelonen + TotaalProvisiesBTW + TotaalProvisiesGerechtskosten;
            if (provisies > 0)
                InsertKostRij(tabel, "ontvangen provisies", -provisies);

            if (Derden > 0)
                InsertKostRij(tabel, "ontvangen van derden", -Derden);

            var totaalBedrag = Totaal - provisies - Derden;
            if (decimal.Round(totaalBedrag, 2) > 0)
            {
                InsertKostRij(tabel, "te betalen saldo", totaalBedrag);
                text = Environment.NewLine + "U kunt dit bedrag overmaken op rekeningnummer BE96 0012 4751 7505 met als mededeling: " +
                    OGMNummer + ".";
            }
            else if (decimal.Round(totaalBedrag, 2) < 0 )
            {
                InsertKostRij(tabel, "uit te keren saldo", totaalBedrag);
                text = Environment.NewLine + "Dit bedrag zal overgemaakt worden op uw rekening binnen de 3 maanden.";
            } else
            {
                InsertKostRij(tabel, "Totaal", totaalBedrag);
                text = Environment.NewLine;
            }

            tabel.Rows.Last.Range.Font.Bold = 1;
            tabel.Rows.Last.Borders[WdBorderType.wdBorderTop].Visible = true;

            tabel.Select();
            selection.EndOf(WdUnits.wdTable, WdMovementType.wdMove);
            selection.Move(WdUnits.wdCharacter, 1);
            selection.TypeText(text);
        }

        private void InsertGerechtsKosten(Table tabel)
        {
            if (Rolzetting > 0)    InsertKostRij(tabel, "gerechtskosten(Rolzetting)", Rolzetting);
            if (Dagvaarding > 0)  InsertKostRij(tabel, "gerechtskosten(Dagvaarding)", Dagvaarding);
            if (Betekening > 0) InsertKostRij(tabel, "gerechtskosten(Betekening)", Betekening);
            if (Uitvoering > 0) InsertKostRij(tabel, "gerechtskosten(Uitvoering)", Uitvoering);
            if (Anderen > 0) InsertKostRij(tabel, "gerechtskosten(Anderen)", Anderen);

            if (totaalNietBTW > 0)
            {
                InsertKostRij(tabel, "algemeen totaal", Totaal);
                tabel.Rows.Last.Range.Font.Bold = 1;
                tabel.Rows.Last.Borders[WdBorderType.wdBorderTop].Visible = true;
            }

        }

        private void InsertErelonenBureelKosten(Table tabel)
        {
            var cels = tabel.Rows[1].Cells;
            cels[1].Range.Text = "Bureel kosten en Erelonen";
            cels[1].Borders[WdBorderType.wdBorderBottom].LineStyle = WdLineStyle.wdLineStyleSingle;
            cels[1].SetWidth(Globals.CoCoCo_Facturatie_Plugin.Application.CentimetersToPoints(7.5F), WdRulerStyle.wdAdjustNone);
            cels[2].SetWidth(Globals.CoCoCo_Facturatie_Plugin.Application.CentimetersToPoints(1.3F), WdRulerStyle.wdAdjustNone);
            cels[3].SetWidth(Globals.CoCoCo_Facturatie_Plugin.Application.CentimetersToPoints(1.3F), WdRulerStyle.wdAdjustNone);
            cels[4].SetWidth(Globals.CoCoCo_Facturatie_Plugin.Application.CentimetersToPoints(0.5F), WdRulerStyle.wdAdjustNone);
            cels[5].SetWidth(Globals.CoCoCo_Facturatie_Plugin.Application.CentimetersToPoints(2.0F), WdRulerStyle.wdAdjustNone);
            cels[6].SetWidth(Globals.CoCoCo_Facturatie_Plugin.Application.CentimetersToPoints(0.5F), WdRulerStyle.wdAdjustNone);
            cels[7].SetWidth(Globals.CoCoCo_Facturatie_Plugin.Application.CentimetersToPoints(3.0F), WdRulerStyle.wdAdjustNone);

            if (Dactylo > 0)    InsertKostRij(tabel, "- pagina's", Dactylo, KostenSchema.Dactylo, "pag.");
            if (Fotokopie > 0)  InsertKostRij(tabel, "- fotokopies", Fotokopie, KostenSchema.Fotokopie, "kop.");
            if (Fax > 0) InsertKostRij(tabel, "- inkomende mails/fax", Fax, KostenSchema.Mail, "");
            if (Verplaatsing > 0) InsertKostRij(tabel, "- verplaatsingen", Verplaatsing, KostenSchema.Verplaatsing, "km.");
            if (BijkomendeKosten > 0) InsertKostRij(tabel, "- bijkomende kosten", BijkomendeKosten);
            if (Forfait > 0) InsertKostRij(tabel, "- dossierkosten", Forfait);
            if (EreloonUren.Ticks > 0) InsertKostRij(tabel, "- verplaatsingen", EreloonUren, KostenSchema.Prestaties, "uren");
            if (WachtUren.Ticks > 0) InsertKostRij(tabel, "- verplaatsingen/wachtuur", WachtUren, KostenSchema.Wacht, "uren");

            cels.Merge();
            cels[1].Range.Font.Bold = 1;
            cels.Borders[WdBorderType.wdBorderBottom].Visible = true;

            if (totaalBTW > 0)
            {
                InsertKostRij(tabel, "Subtotaal", totaalBTW);
                tabel.Rows.Last.Range.Font.Bold = 1;
                tabel.Rows.Last.Borders[WdBorderType.wdBorderTop].Visible = true;
                if (BTW > 0)
                {
                    InsertKostRij(tabel, " - " + KostenSchema.BTW.ToString("P", Variabelen.Cultuur) + " BTW", BTW);
                    tabel.Rows.Last.Range.Font.Bold = 0;
                }
            }

        }

        private void InsertKostRij(Table tabel, string omschrijving, decimal bedrag)
        {
            var rij = tabel.Rows.Add();
            rij.Cells[1].Range.Text = omschrijving;
            rij.Cells[7].Range.Text = bedrag.ToString("C", Variabelen.Cultuur);
            rij.Cells[7].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
            rij.Borders.Enable = (int)WdLineStyle.wdLineStyleNone;
        }

        private void InsertKostRij(Table tabel, string omschrijving, short hoeveelheid, decimal bedrag, string eenheid)
        {
            var rij = tabel.Rows.Add();
            rij.Cells[1].Range.Text = omschrijving;

            rij.Cells[2].Range.Text = hoeveelheid.ToString();
            rij.Cells[2].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;

            rij.Cells[3].Range.Text = eenheid;
            rij.Cells[3].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;

            rij.Cells[4].Range.Text = "x";

            rij.Cells[5].Range.Text = bedrag.ToString("C", Variabelen.Cultuur);
            rij.Cells[5].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;

            rij.Cells[6].Range.Text = "=";

            rij.Cells[7].Range.Text = (hoeveelheid * bedrag).ToString("C", Variabelen.Cultuur);
            rij.Cells[7].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;

            rij.Borders.Enable = (int)WdLineStyle.wdLineStyleNone;
        }

        private void InsertKostRij(Table tabel, string omschrijving, TimeSpan hoeveelheid, decimal bedrag, string eenheid)
        {
            var rij = tabel.Rows.Add();
            rij.Cells[1].Range.Text = omschrijving;

            rij.Cells[2].Range.Text = Decimal.Truncate((decimal)hoeveelheid.TotalHours).ToString("###0") +":" + hoeveelheid.ToString(@"mm");
            rij.Cells[2].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;

            rij.Cells[3].Range.Text = eenheid;
            rij.Cells[3].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;

            rij.Cells[4].Range.Text = "x";

            rij.Cells[5].Range.Text = bedrag.ToString("C", Variabelen.Cultuur);
            rij.Cells[5].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;

            rij.Cells[6].Range.Text = "=";

            rij.Cells[7].Range.Text = ((decimal)hoeveelheid.TotalHours * bedrag).ToString("C", Variabelen.Cultuur);
            rij.Cells[7].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;

            rij.Borders.Enable = (int)WdLineStyle.wdLineStyleNone;
        }
    }

}
