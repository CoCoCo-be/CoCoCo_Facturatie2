using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoCoCo_Facturatie
{
    public partial class FacturatieForm1 : Form
    {
        #region Variables
        List<String> DossierNummers;
        public OGMNummer OGM { get; set; }
        public String DossierNummer { get; set; }
        public int Tab { get; set; }
        public Decimal OGM_Bedrag { get; set; }
        public Decimal Dossier_Bedrag { get; set; }
        #endregion

        public FacturatieForm1()
        {
            InitializeComponent();
        }

        private void FacturatieForm1_Load(object sender, EventArgs e)
        {
            List<String> EreloonDossierNummers, ProvisieDossierNummers;
            using (var context = new FacturatieModel())
            {
                EreloonDossierNummers = context.EreloonNotas.Select(p => p.DossierNummer).Distinct().ToList();
                ProvisieDossierNummers = context.Provisies.Select(p => p.DossierNummer).Distinct().ToList();
                DossierNummers = EreloonDossierNummers.Union(ProvisieDossierNummers).OrderByDescending(p => p).ToList();
                CBDossier.DataSource = DossierNummers;
                CBDossier.SelectedIndex = -1;
            }
            Tab = tabControl1.SelectedIndex;
        }

        private void OGMCode_Validating(object sender, CancelEventArgs e)
        {
            Boolean Geldig = true;

            errorProvider1.Clear();

            if (OGMCode1.TextLength != 3 || !int.TryParse(OGMCode1.Text, out int Number))
            {
                if (OGMCode1.TextLength != 0)
                    errorProvider1.SetError(OGMCode1, "waarde ongeldig");
                Geldig = false;
            }

            if (OGMCode2.TextLength != 4 || !int.TryParse(OGMCode2.Text, out Number))
            {
                if (OGMCode2.TextLength != 0)
                    errorProvider1.SetError(OGMCode2, "waarde ongeldig");
                Geldig = false;
            }

            if (OGMCode3.TextLength != 5 || !int.TryParse(OGMCode3.Text, out Number))
            {
                if (OGMCode3.TextLength != 0)
                    errorProvider1.SetError(OGMCode3, "waarde ongeldig");
                Geldig = false;
            }

            if (Geldig)
            {
                OGM = new OGMNummer(OGMCode1.Text, OGMCode2.Text, OGMCode3.Text);
                if (!OGM.Geldig())
                {
                    errorProvider1.SetError(OGMCode3, "OGM code is niet geldig");
                    DossierNaam.Text = "";
                }
                else
                    using (var context = new FacturatieModel())
                    {
                        String OGMString = OGM.ToString();
                        String DossierNaamString;
                        IQueryable<object> result = context.EreloonNotas
                            .Where(p => p.OGMNummer == OGMString);
                        if (result.Count() != 0)
                            DossierNaamString = ((EreloonNota)result.First()).DossierNaam;
                        else
                        {
                            result = context.Provisies
                                .Where(p => p.OGMNummer == OGMString);
                            if (result.Count() != 0)
                                DossierNaamString = ((Provisie)result.First()).DossierNaam;
                            else
                            {
                                result = context.DerdenGelden
                                    .Where(p => p.OGMNummer == OGMString);
                                if (result.Count() != 0)
                                    DossierNaamString = ((DerdenGeld)result.First()).DossierNaam;
                                else
                                    DossierNaamString = "Niet gevonden";
                            }
                        }
                        DossierNaam.Text = DossierNaamString;
                    }
            }
            else
                DossierNaam.Text = "";
        }

        private void OGMCode_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox box = (TextBox)sender;
            if (box.TextLength == box.MaxLength && box.SelectionLength == 0 && box.SelectionStart == box.MaxLength )
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void OGMCode_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void CBDossier_Validated(object sender, EventArgs e)
        {
            using (var context = new FacturatieModel())
            {
                DossierNummer = (String)CBDossier.SelectedItem;
                String DossierNaamString;
                IQueryable<object> result = context.EreloonNotas
                    .Where(p => p.DossierNummer == DossierNummer);
                if (result.Count() != 0)
                    DossierNaamString = ((EreloonNota)result.First()).DossierNaam;
                else
                {
                    result = context.Provisies
                        .Where(p => p.DossierNummer == DossierNummer);
                    if (result.Count() != 0)
                        DossierNaamString = ((Provisie)result.First()).DossierNaam;
                    else
                    {
                        result = context.DerdenGelden
                            .Where(p => p.DossierNummer == DossierNummer);
                        if (result.Count() != 0)
                            DossierNaamString = ((DerdenGeld)result.First()).DossierNaam;
                        else
                            DossierNaamString = "Niet gevonden";
                    }
                }
                LDossierNaam.Text = DossierNaamString;
            }
        }

        private void ETabIndexChanged(object sender, EventArgs e)
        {
            Tab = tabControl1.SelectedIndex;
        }

        private void OGMBedrag_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.Clear();
            if (!Decimal.TryParse(OGMBedrag.Text, out var bedrag))
                errorProvider1.SetError(OGMBedrag, "Geen bedrag");
            else
                OGM_Bedrag = bedrag;
        }

        private void DossierBedrag_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.Clear();
            if (!Decimal.TryParse(DossierBedrag.Text, out var bedrag))
                errorProvider1.SetError(DossierBedrag, "Geen bedrag");
            else
                Dossier_Bedrag = bedrag;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            Tab = tabControl1.SelectedIndex;
        }
    }
}
