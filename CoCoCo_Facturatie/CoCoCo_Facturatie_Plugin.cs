using System.Data.Entity;
using CoCoCo_Facturatie.Migrations;
using System;
using System.Windows.Forms;

namespace CoCoCo_Facturatie
{

    public partial class CoCoCo_Facturatie_Plugin
    {

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<FacturatieModel, Configuration>());

            try
            {
                if (! Variabelen.LeesCSV())
                {
                    var ribbon = Globals.Ribbons.FacturatieRibbon;
                    ribbon.ProvisieNota.Enabled = false;
                    ribbon.EreloonNota.Enabled = false;
                    ribbon.DerdenGeldenNota.Enabled = false;
                    ribbon.Facturen.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                String FoutMelding = "Fout bij opstarten van Plugin\n" + ex.ToString();
                MessageBox.Show(FoutMelding, "Fout bij opstarten Facturatie", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ThisAddIn_Shutdown(sender, e);
            }
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
