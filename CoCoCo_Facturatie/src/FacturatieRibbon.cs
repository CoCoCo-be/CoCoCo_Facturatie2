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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "wil")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "voor")]
        private void ProvisieNota_Click(object sender, RibbonControlEventArgs e)
        {
            Boolean einde = false;
            Provisie provisie = null;
            ProvisieNotaForm form = new ProvisieNotaForm();

            while (!einde)
            {
                form.ShowDialog();

                if (form.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    Double Totaal = form.Totaal;
                    DialogResult Bevestigd = MessageBox.Show("Klopt het dat je een Provisie voor " + Totaal.ToString("C", Variabelen.Cultuur) + " wil invoegen?",
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

            using (var context = new FacturatieModel())
            {
                provisie = new Provisie(Convert.ToDecimal(form.Ereloon), Convert.ToDecimal(form.BTW),
                    Convert.ToDecimal(form.Gerechtskosten), Convert.ToDecimal(form.Totaal), form.IC);

                context.Provisies.Add(provisie);
                context.SaveChanges();
            }
        }
    }
}
