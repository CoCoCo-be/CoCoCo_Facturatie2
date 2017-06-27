using System.Data.Entity;
using CoCoCo_Facturatie.Migrations;

namespace CoCoCo_Facturatie
{
    public partial class CoCoCo_Facturatie_Plugin
    {
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<FacturatieModel, Configuration>());
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
