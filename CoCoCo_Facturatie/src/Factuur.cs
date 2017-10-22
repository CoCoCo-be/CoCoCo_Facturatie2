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

        internal abstract void PrintText(Selection selection);
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
                    KostenSchema = ereloonNota.KostenSchema;
                else if (KostenSchema != ereloonNota.KostenSchema)
                    throw new NotImplementedException("Factuur voor ereloonNotas met verschillende kostenschemas");
            }

            if (Totaal != _totaal)
                throw new Exception("Totaal komt niet overeen, factuur niet gemaakt");
        }

        internal override void PrintText(Selection selection)
        {
            throw new NotImplementedException();
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

        internal override void PrintText(Selection selection)
        {
            Document document = selection.Application.Documents.Add(Properties.Settings.Default.FactuurTemplate);
            AddHeader(document, GetFactuurNummer());

            var table = document.Tables[1];
            table.Range.ParagraphFormat.KeepWithNext = -1;


            //subtotal_ExVAT = AddWages(table:= table, kind:= "provisie")
            //subtotal_NoVAT = AddLitigation(table:= table, kind:= "provisie")

            // Remove border of second row
            table.Rows[2].Borders[WdBorderType.wdBorderBottom].Visible = false;

            // Add Total
            var bottomRow = table.Rows.Add();

            //insert if for not empty
            bottomRow.Cells.Borders[WdBorderType.wdBorderVertical].Visible = false;
            bottomRow.Cells.Borders[WdBorderType.wdBorderBottom].Visible = false;
            bottomRow.Cells.Borders[WdBorderType.wdBorderLeft].Visible = false;
            bottomRow.Cells.Borders[WdBorderType.wdBorderRight].Visible = false;
            bottomRow.Range.ParagraphFormat.KeepWithNext = -1;

            //        If(subtotal_ExVAT <> 0) Then
            //            With table.Rows.Add
            //                .Cells(2).Merge(MergeTo:= .Cells(5))
            //                .Cells(2).Range.InsertAfter(Text:= "Subtotaal excl Btw")
            //                .Cells(2).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft
            //                .Cells(3).Range.InsertAfter(Text:= Format(Expression:= subtotal_ExVAT, Style:= GlobalValues.NumberFormat))
            //                .Range.ParagraphFormat.KeepWithNext = True
            //            End With

            //            With table.Rows.Add
            //                .Cells(2).Range.InsertAfter(Text:= "Subtotaal Btw")
            //                .Cells(3).Range.InsertAfter(Text:= Format(Expression:= Math.Round(subtotal_ExVAT * (1 + VAT), 2) - subtotal_ExVAT, Style:= GlobalValues.NumberFormat))
            //                .Range.ParagraphFormat.KeepWithNext = True
            //            End With
            //        End If

            //        If(subtotal_NoVAT <> 0) Then
            //            With table.Rows.Add
            //                .Cells(2).Range.InsertAfter(Text:= "Subtotaal derden en gerechtskosten")
            //                .Cells(3).Range.InsertAfter(Text:= Format(Expression:= subtotal_NoVAT, Style:= GlobalValues.NumberFormat))
            //                .Range.ParagraphFormat.KeepWithNext = True
            //            End With
            //        End If

            //        If(subtotal_NoVAT <> 0) Or(subtotal_ExVAT <> 0) Then
            //            With table.Rows.Add
            //                .Cells(2).Range.InsertAfter(Text:= "Totaal")
            //                .Cells(2).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter
            //                .Cells(3).Range.InsertAfter(Text:= Format(Expression:= subtotal_ExVAT * (1 + VAT) + subtotal_NoVAT, Style:= GlobalValues.NumberFormat))
            //                .Cells(3).Borders(WdBorderType.wdBorderTop).Visible = True
            //                .Cells(2).Range.Font.Bold = True
            //                .Cells(3).Range.Font.Bold = True
            //                .Range.ParagraphFormat.KeepWithNext = True
            //            End With
            //        End If

            //        'add border under table
            //        Dim newTable As Table
            //        newTable = table.Split(bottomRow.Index + 1)
            //        bottomRow.Borders(WdBorderType.wdBorderTop).Visible = True
            //        bottomRow.Delete()
            //        table.Columns.SetWidth(ColumnWidth:= ObjExcel.CentimetersToPoints(2.25), RulerStyle:= WdRulerStyle.wdAdjustNone)
            //        table.Columns(1).SetWidth(ColumnWidth:= ObjExcel.CentimetersToPoints(5.25), RulerStyle:= WdRulerStyle.wdAdjustNone)
            //        table.Columns(2).SetWidth(ColumnWidth:= ObjExcel.CentimetersToPoints(1.5), RulerStyle:= WdRulerStyle.wdAdjustNone)
            //        table.Columns(6).SetWidth(ColumnWidth:= ObjExcel.CentimetersToPoints(3), RulerStyle:= WdRulerStyle.wdAdjustNone)

            //        newTable.Columns.SetWidth(ColumnWidth:= ObjExcel.CentimetersToPoints(1.47), RulerStyle:= WdRulerStyle.wdAdjustNone)
            //        newTable.Columns(2).SetWidth(ColumnWidth:= ObjExcel.CentimetersToPoints(9.5), RulerStyle:= WdRulerStyle.wdAdjustNone)
            //        newTable.Columns(3).SetWidth(ColumnWidth:= ObjExcel.CentimetersToPoints(5.25), RulerStyle:= WdRulerStyle.wdAdjustNone)


            //Final:
            //        'Log invoice
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
            throw new NotImplementedException();
        }

        private void AddHeader(Document document, int v)
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
    }
}
