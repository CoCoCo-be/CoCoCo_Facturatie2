using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using System.Windows.Forms;

namespace CoCoCo_Facturatie
{
    public partial class FacturatieRibbon
    {
        private void FacturatieRibbon_Load(object sender, RibbonUIEventArgs e)
        {
        }

        private void ProvisieNota_Click(object sender, RibbonControlEventArgs e)
        {
            Boolean einde = false;
            Provisie provisie = null;
            ProvisieNotaForm form = new ProvisieNotaForm();

            #region Bevestiging
            while (!einde)
            {
                form.ShowDialog();

                if (form.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    Double Totaal = form.Totaal;
                    DialogResult Bevestigd = MessageBox.Show("Klopt het dat je een provisie voor " + Totaal.ToString("C", Variabelen.Cultuur) + " wil invoegen?",
                        "Bevestiging", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (Bevestigd == DialogResult.Yes)
                    {
                        einde = true;
                        form.Hide();
                    }
                }
                else
                {
                    form.Dispose();
                    return;
                }
            }
            #endregion

            #region Vul text in en bewaar provisie
            using (var context = new FacturatieModel())
            {
                provisie = new Provisie(Convert.ToDecimal(form.Ereloon), Convert.ToDecimal(form.BTW),
                    Convert.ToDecimal(form.Gerechtskosten), Convert.ToDecimal(form.Totaal), form.IC);

                context.Provisies.Add(provisie);
                provisie.PrintText(Globals.CoCoCo_Facturatie_Plugin.Application.Selection);
                context.SaveChanges();
            }
            #endregion
        }

        private void EreloonNota_Click(object sender, RibbonControlEventArgs e)
        {
            Boolean einde = false;
            //EreloonNota ereloonNota = null;
            EreloonNotaForm form = new EreloonNotaForm();

            #region Bevestiging
            while (!einde)
            {
                form.ShowDialog();

                if (form.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    Double Totaal = form.Totaal;
                    DialogResult Bevestigd = MessageBox.Show("Klopt het dat je een ereloon nota voor " + Totaal.ToString("C", Variabelen.Cultuur) + " wil invoegen?",
                        "Bevestiging", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (Bevestigd == DialogResult.Yes)
                    {
                        einde = true;
                        form.Hide();
                    }
                }
                else
                {
                    form.Dispose();
                    return;
                }
            }
            #endregion
        }

        private void LeesCSV_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                if (!Variabelen.LeesCSV())
                    ToggleKnoppen(false);
                else
                    ToggleKnoppen(true);
                MessageBox.Show("Partij-informatie goed ingelezen.", "Partij-informatie goed ingelezen.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                String FoutMelding = "Fout bij het inlezen van de partij-informatie\n" + ex.ToString();
                MessageBox.Show(FoutMelding, "Fout bij inlezen partij-informatie", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ToggleKnoppen(false);
            }
        }

        public void ToggleKnoppen(Boolean Waarde)
        {
            ProvisieNota.Enabled = Waarde;
            EreloonNota.Enabled = Waarde;
            DerdenGeldenNota.Enabled = Waarde;
            Facturen.Enabled = Waarde;
        }
    }
}
