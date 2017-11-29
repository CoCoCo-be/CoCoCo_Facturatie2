using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Office.Tools.Ribbon;
using System.Windows.Forms;
using System.Drawing;

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

            form.Dispose();
        }

        private void EreloonNota_Click(object sender, RibbonControlEventArgs e)
        {
            Boolean einde = false;
            EreloonNota ereLoonNota = null;
            EreloonNotaForm form = new EreloonNotaForm();

            #region Bevestiging
            while (!einde)
            {
                form.ShowDialog();

                if (form.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    Decimal Totaal = form.Totaal;
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

            #region Vul text in en bewaar ereloon
            using (var context = new FacturatieModel())
            {
                ereLoonNota = form.EreloonNota;
                context.Entry(ereLoonNota.KostenSchema).State = System.Data.Entity.EntityState.Unchanged;
                context.EreloonNotas.Add(ereLoonNota);
                ereLoonNota.PrintText(Globals.CoCoCo_Facturatie_Plugin.Application.Selection);
                context.SaveChanges();
            }
            #endregion

            form.Dispose();
        }

        private void DerdenGeldNota_Klick(object sender, RibbonControlEventArgs e)
        {
            Boolean einde = false;
            DerdenGeld derdengeld = null;
            DerdenGeldenForm form = new DerdenGeldenForm();

            #region Bevestiging
            while (!einde)
            {
                form.ShowDialog();

                if (form.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    Double Totaal = form.Totaal;
                    DialogResult Bevestigd = MessageBox.Show("Klopt het dat je een derdengeld voor " + Totaal.ToString("C", Variabelen.Cultuur) + " wil invoegen?",
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

            #region Vul text in en bewaar derdengeld
            using (var context = new FacturatieModel())
            {
                derdengeld = new DerdenGeld(Convert.ToDecimal(form.SchadeloosStelling), Convert.ToDecimal(form.Gerechtskosten),
                    Convert.ToDecimal(form.Totaal));

                context.DerdenGelden.Add(derdengeld);
                derdengeld.PrintText(Globals.CoCoCo_Facturatie_Plugin.Application.Selection);
                context.SaveChanges();
            }
            #endregion

            form.Dispose();
        }

        private void Factuur_Klick(object sender, RibbonControlEventArgs e)
        {
            FacturatieForm1 form = new FacturatieForm1();
            FactuurModel FactuurModel = null;
            Factuur Factuur;
            decimal Bedrag;

            form.ShowDialog();

            if (form.DialogResult != System.Windows.Forms.DialogResult.OK)
                return;

            #region Vul text in en bewaar factuur
            using (var context = new FacturatieModel())
            {
                switch (form.Tab)
                {
                    case 0:
                        var OGMCode = form.OGM;
                        Bedrag = form.OGM_Bedrag;
                        FactuurModel = new FactuurModel(Bedrag, EreloonNota.EreloonNotaOGM(OGMCode.ToString(), context ),
                            Provisie.ProvisieOGM(OGMCode.ToString(), context), context);
                        break;
                    case 1:
                        var DossierNummer = form.DossierNummer;
                        Bedrag = form.Dossier_Bedrag;
                        FactuurModel = new FactuurModel(Bedrag, EreloonNota.EreloonNotaDossierNr(DossierNummer, context),
                            Provisie.ProvisieDossierNr(DossierNummer, context), context);
                        break;
                    default:
                        throw new NotImplementedException("Factuur maken, zonder dat er Ereloon of Provisie voor bestaat is nog niet gemaakt!");

                }

                Factuur = FactuurModel.Genereer();
                context.SaveChanges();
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
            BtEreloonNota.Enabled = Waarde;
            DerdenGeldenNota.Enabled = Waarde;
            //Facturen.Enabled = Waarde;
        }

        private void KostenSchemaEdit_Click(object sender, RibbonControlEventArgs e)
        {
            KostenSchemaForm form = new KostenSchemaForm();


            using (var context = new FacturatieModel())
            {
                form.KostenSchemaSource = context.KostenSchemas.ToList();

                form.ShowDialog();

                List<KostenSchema> Lijst = form.Schemas;
                if (null != Lijst)
                    foreach(var schema in Lijst)
                        context.KostenSchemas.Add(schema);

                context.SaveChanges();
            }
        }
    }
}
