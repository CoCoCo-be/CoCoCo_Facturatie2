using System.Data.Entity;
using CoCoCo_Facturatie.Migrations;

namespace CoCoCo_Facturatie
{
    public partial class CoCoCo_Facturatie_Plugin
    {
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<FacturatieModel, Configuration>());

            using (var db = new FacturatieModel())
            {
                //Create and save a new KostenModel
                var kostenSchema1 = new KostenSchema { Archive = false, BTW = 0, Dactylo = 0, Fotokopie = 0, Mail = 0, Naam = "0 = eerste test", Prestaties = 0, Verplaatsing = 0, Wacht = 0 };
                db.KostenSchemas.Add(kostenSchema1);
                db.SaveChanges();
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
