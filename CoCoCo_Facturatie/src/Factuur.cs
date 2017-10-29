using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.Office.Interop.Word;

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
        [Required]
        public Decimal Totaal { get; set; }
        #endregion

        [NotMapped]
        internal Decimal subtotal_ExVAT { get; set; } = 0;
        [NotMapped]
        internal Decimal Subtotal_NoVat { get; set; } = 0;
        [NotMapped]
        internal Decimal BTW { get; set; }

        public Factuur(string wie, string dossierNummer, string dossierNaam, Partij partij, Decimal totaal)
        {
            Wie = wie;
            DossierNummer = dossierNummer;
            DossierNaam = dossierNaam;
            Partij = partij;
            Totaal = totaal;
        }

        public int GetFactuurNummer()
        {
            return int.Parse(FactuurJaar.ToString() + FactuurID.ToString());
        }

        internal void AddHeader(Document document)
        {
            // Fill header
            document.CustomDocumentProperties("AdresBlok").Value = Partij.AanspreekTitel + " " + Partij.Naam + Environment.NewLine +
                Partij.Adres + Environment.NewLine + Partij.Adres2;
            document.CustomDocumentProperties("FactuurNummer").Value = GetFactuurNummer();
            document.CustomDocumentProperties("FactuurDatum").Value = DateTime.Now.ToString("d MMMM yyyy");
            document.CustomDocumentProperties("Vervaldatum").Value = DateTime.Now.AddMonths(1).ToString("d MMMM yyyy");
            document.CustomDocumentProperties("Dossier").Value = DossierNaam;
            document.CustomDocumentProperties("DossierNummer").Value = DossierNummer;

            // Update fields
            document.Fields.Update();
        }

        internal abstract void AddWages(Table table);

        internal abstract void AddLitigation(Table table);

        internal void PrintText(Selection selection)
        {
            Document document = selection.Application.Documents.Add(Properties.Settings.Default.FactuurTemplate);
            Application app = selection.Application;
            AddHeader(document);

            var table = document.Tables[2];
            table.Range.ParagraphFormat.KeepWithNext = -1;

            AddWages(table);
            AddLitigation(table);
            //AddProvision(table);

            // Remove border of second row
            table.Rows[2].Borders[WdBorderType.wdBorderBottom].Visible = false;

            // Add Total
            Row newRow = table.Rows.Add();
            Row BottomRow = newRow;

            //insert if for not empty
            newRow.Cells.Borders[WdBorderType.wdBorderVertical].Visible = false;
            newRow.Cells.Borders[WdBorderType.wdBorderBottom].Visible = false;
            newRow.Cells.Borders[WdBorderType.wdBorderLeft].Visible = false;
            newRow.Cells.Borders[WdBorderType.wdBorderRight].Visible = false;
            newRow.Range.ParagraphFormat.KeepWithNext = -1;

            if (subtotal_ExVAT != 0)
            {
                newRow = table.Rows.Add();
                newRow.Cells[2].Merge(newRow.Cells[5]);
                newRow.Cells[2].Range.InsertAfter("Subtotaal excl Btw");
                newRow.Cells[2].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                newRow.Cells[3].Range.InsertAfter(Subtotal_NoVat.ToString("C", Variabelen.Cultuur));
                newRow.Range.ParagraphFormat.KeepWithNext = -1;

                newRow = table.Rows.Add();
                newRow.Cells[2].Range.InsertAfter("Subtotaal Btw");
                newRow.Cells[3].Range.InsertAfter((Subtotal_NoVat * BTW).ToString("C", Variabelen.Cultuur));
                newRow.Range.ParagraphFormat.KeepWithNext = -1;
            }

            if (Subtotal_NoVat != 0)
            {
                newRow = table.Rows.Add();
                newRow.Cells[2].Range.InsertAfter("Subtotaal derden en gerechtskosten");
                newRow.Cells[3].Range.InsertAfter(Subtotal_NoVat.ToString("C", Variabelen.Cultuur));
                newRow.Range.ParagraphFormat.KeepWithNext = -1;
            }

            if (Subtotal_NoVat != 0 || subtotal_ExVAT != 0)
            {
                newRow = table.Rows.Add(); ;
                newRow.Cells[2].Range.InsertAfter("Totaal");
                newRow.Cells[2].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                newRow.Cells[3].Range.InsertAfter(Totaal.ToString("C", Variabelen.Cultuur));
                newRow.Cells[3].Borders[WdBorderType.wdBorderTop].Visible = true;
                newRow.Cells[2].Range.Font.Bold = -1;
                newRow.Cells[3].Range.Font.Bold = -1;
                newRow.Range.ParagraphFormat.KeepWithNext = -1;
            }

            // add border under table
            var newTable = table.Split(BottomRow);
            BottomRow.Borders[WdBorderType.wdBorderTop].Visible = true;
            BottomRow.Delete();
            table.Columns.SetWidth(app.CentimetersToPoints(2.25f), WdRulerStyle.wdAdjustNone);
            table.Columns[1].SetWidth(app.CentimetersToPoints(5.25f), WdRulerStyle.wdAdjustNone);
            table.Columns[2].SetWidth(app.CentimetersToPoints(1.5f), WdRulerStyle.wdAdjustNone);
            table.Columns[6].SetWidth(app.CentimetersToPoints(3f), WdRulerStyle.wdAdjustNone);

            newTable.Columns.SetWidth(app.CentimetersToPoints(1.47f), WdRulerStyle.wdAdjustNone);
            newTable.Columns[2].SetWidth(app.CentimetersToPoints(9.5f), WdRulerStyle.wdAdjustNone);
            newTable.Columns[3].SetWidth(app.CentimetersToPoints(5.25f), WdRulerStyle.wdAdjustNone);

            // Log invoice
            //        logInvoice(provisie:= True)

            //        objWord.Visible = True
            //        Document.PrintPreview()
            //        MsgBox("Kijk de factuur na")
            //        Workbook1.Close(SaveChanges:= vbYes)

            //        Document.SaveAs2(FileName:= GlobalValues.InvoicePath + Factuurnummer)
            //        objWord.ActivePrinter = "Standaard"
            //        Document.PrintOut(Background:= True)
            //        objWord.ActivePrinter = "Standaard"
            //        On Error GoTo closeWord
            //        If objWord.Documents.Count > 1 Then
            //            Document.Close(SaveChanges:= True)
            //        Else
            //            objWord.Quit(SaveChanges:= True)
            //        End If
            //closeWord:
            //        objWord = Nothing
            //        globalvalues.Dispose()
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Table("Facturen")]
    public class EreloonNotaFactuur : Factuur
    {
        #region Fields
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
        public Decimal Derden { get; set; }
        #endregion

        #region ForeignKeys
        [Required]
        public virtual KostenSchema KostenSchema { get; set; }
        #endregion

        public EreloonNotaFactuur(IQueryable<EreloonNota> _ereloonNotas, decimal _totaal) :
            base(_ereloonNotas.First().Wie, _ereloonNotas.First().DossierNummer, _ereloonNotas.First().DossierNaam,
                _ereloonNotas.First().Partij, 0)
        {
            foreach (var ereloonNota in _ereloonNotas)
            {
                Dactylo += (short)(ereloonNota.Dactylo - ereloonNota.Facturen.Sum(f => f.Dactylo));
                Fotokopie += (short)(ereloonNota.Fotokopie - ereloonNota.Facturen.Sum(f => f.Fotokopie));
                Fax += (short)(ereloonNota.Fax - ereloonNota.Facturen.Sum(f => f.Fax));
                Verplaatsing += (short)(ereloonNota.Verplaatsing - ereloonNota.Facturen.Sum(f => f.Verplaatsing));
                BijkomendeKosten += ereloonNota.BijkomendeKosten - ereloonNota.Facturen.Sum(f => f.BijkomendeKosten);
                EreloonUren += ereloonNota.EreloonUren - TimeSpan.FromHours(ereloonNota.Facturen.Sum(f => f.EreloonUren.TotalHours));
                WachtUren += ereloonNota.WachtUren - TimeSpan.FromHours(ereloonNota.Facturen.Sum(f => f.WachtUren.TotalHours));
                BTW = ereloonNota.BTW - ereloonNota.Facturen.Sum(f => f.BTW);
                Rolzetting += ereloonNota.Rolzetting - ereloonNota.Facturen.Sum(f => f.Rolzetting);
                Dagvaarding += ereloonNota.Dagvaarding - ereloonNota.Facturen.Sum(f => f.Dagvaarding);
                Betekening += ereloonNota.Betekening - ereloonNota.Facturen.Sum(f => f.Betekening);
                Uitvoering += ereloonNota.Uitvoering - ereloonNota.Facturen.Sum(f => f.Uitvoering);
                Anderen += ereloonNota.Anderen - ereloonNota.Facturen.Sum(f => f.Anderen);
                Derden += ereloonNota.Derden - ereloonNota.Facturen.Sum(f => f.Derden);
                Totaal += ereloonNota.Totaal - ereloonNota.Facturen.Sum(f => f.Totaal);

                if (KostenSchema is null)
                {
                    KostenSchema = ereloonNota.KostenSchema;
                    BTW = KostenSchema.BTW;
                }
                else if (KostenSchema != ereloonNota.KostenSchema)
                    throw new NotImplementedException("Factuur voor ereloonNotas met verschillende kostenschemas");
            }

            if (Totaal != _totaal)
                throw new Exception("Totaal komt niet overeen, factuur niet gemaakt");
        }

        internal void AddRowLit(Row _Row, String _text, Decimal _amount)
        {
            _Row.Borders[WdBorderType.wdBorderTop].Visible = false;
            _Row.Cells[1].Range.InsertAfter(_text);
            _Row.Cells[6].Range.InsertAfter(_amount.ToString("C", Variabelen.Cultuur));
            _Row.Range.ParagraphFormat.KeepWithNext = -1;
            Subtotal_NoVat += _amount;
        }

        internal override void AddLitigation(Table table)
        {
            if (Dagvaarding != 0)
                AddRowLit(table.Rows.Add(), "- dagvaardingen:", Dagvaarding);
            if (Betekening != 0)
                AddRowLit(table.Rows.Add(), "- betekeningen:", Betekening);
            if (Uitvoering != 0)
                AddRowLit(table.Rows.Add(), "- uitvoeringen:", Uitvoering);
            if (Anderen != 0)
                AddRowLit(table.Rows.Add(), "- andereen:", Anderen);
        }

        internal void AddRowWag(Row _row, String _text, Decimal _amount, TimeSpan _time = new TimeSpan(), Decimal _tarief = 0)
        {
            _row.Borders[WdBorderType.wdBorderTop].Visible = false;
            _row.Cells[1].Range.InsertAfter(_text);
            if (!_time.Equals(TimeSpan.Zero))
            {
                _row.Cells[2].Range.InsertAfter($"{Math.Floor(_time.TotalHours):00}.{_time.Minutes:00}");
                _row.Cells[3].Range.InsertAfter(_tarief.ToString("C", Variabelen.Cultuur));
            }
            _row.Cells[4].Range.InsertAfter(_amount.ToString("C", Variabelen.Cultuur));
            _row.Cells[5].Range.InsertAfter((_amount * BTW).ToString("C", Variabelen.Cultuur));
            _row.Cells[6].Range.InsertAfter((_amount * (1 + BTW)).ToString("C", Variabelen.Cultuur));
            _row.Range.ParagraphFormat.KeepWithNext = -1;
            subtotal_ExVAT += _amount;
        }

        internal override void AddWages(Table table)
        {
            Row titleRow = table.Rows.Add();

            Decimal Wages = ((Decimal) EreloonUren.TotalHours) * KostenSchema.Prestaties;
            if (Wages != 0)
                AddRowWag(table.Rows.Add(), "- erelonen:", Wages, EreloonUren, KostenSchema.Prestaties);
            Decimal Wait = ((Decimal) WachtUren.TotalHours) * KostenSchema.Wacht;
            if (Wait != 0)
                AddRowWag(table.Rows.Add(), "- verplaatsingen/wachttijden:", Wait, WachtUren, KostenSchema.Wacht);

            if (Subtotal_NoVat != 0)
            {

            }

        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ProvisieFactuur : Factuur
    {
        #region Fields
        [Required]
        public Decimal ProvisieErelonen { get; set; }
        [Required]
        public Decimal ProvisieBTW { get; set; }
        [Required]
        public Decimal ProvisiegerechtsKosten { get; set; }
        //[Required]
        //public Decimal BTW { get; set; }
        #endregion

        public ProvisieFactuur(IQueryable<Provisie> _provisies, decimal _totaal) :
            base(_provisies.First().Wie, _provisies.First().DossierNummer, _provisies.First().DossierNaam,
                _provisies.First().Partij, 0)
        {
            foreach (var provisie in _provisies)
            {
                ProvisieErelonen += provisie.Ereloon;
                ProvisieBTW += provisie.BTW;
                ProvisiegerechtsKosten += provisie.Gerechtskosten;
                BTW = 0.21;
                Totaal += provisie.Totaal ;
                if (provisie.Facturen != null)
                {
                    ProvisieBTW -= provisie.Facturen.Sum(f => f.ProvisieBTW);
                    ProvisieErelonen -= provisie.Facturen.Sum(f => f.ProvisieErelonen);
                    ProvisiegerechtsKosten -= provisie.Facturen.Sum(f => f.ProvisiegerechtsKosten);
                    Totaal -= provisie.Facturen.Sum(f => f.Totaal);
                }
            }
            
            if (Totaal != _totaal)
                throw new Exception("Totaal komt niet overeen, factuur niet gemaakt");
        }

        internal override void AddWages(Table table)
        {
            Row titleRow = table.Rows.Add();

            if (ProvisieErelonen != 0)
            {
                Row row = table.Rows.Add();
                row.Borders[WdBorderType.wdBorderTop].Visible = true;
                row.Cells[1].Range.InsertAfter("- Provisie erelonen:");
                row.Cells[4].Range.InsertAfter(ProvisieErelonen.ToString("C", Variabelen.Cultuur));
                row.Cells[5].Range.InsertAfter(ProvisieBTW.ToString("C", Variabelen.Cultuur));
                row.Cells[6].Range.InsertAfter((ProvisieErelonen + ProvisieBTW).ToString("C", Variabelen.Cultuur));
                row.Range.ParagraphFormat.KeepWithNext = -1;
                subtotal_ExVAT += ProvisieErelonen;
            }

        }

        internal override void AddLitigation(Table table)
        {
            Row titleRow = table.Rows.Add();

            if (ProvisiegerechtsKosten != 0)
            {
                Row row = table.Rows.Add();
                row.Borders[WdBorderType.wdBorderTop].Visible = true;
                row.Cells[1].Range.InsertAfter("- Gerechtskosten:");
                row.Cells[6].Range.InsertAfter(ProvisiegerechtsKosten.ToString("C", Variabelen.Cultuur));
                row.Range.ParagraphFormat.KeepWithNext = -1;
                Subtotal_NoVat += ProvisiegerechtsKosten;
            }
        }

    }
}
