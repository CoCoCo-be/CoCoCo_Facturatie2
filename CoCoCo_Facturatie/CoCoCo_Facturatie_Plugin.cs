using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Word;
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace CoCoCo_Facturatie
{
    public partial class CoCoCo_Facturatie_Plugin
    {
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            
            using (var db = new FacturatieModel())
            {
                //Create and save a new KostenModel
                var kostenSchema1 = new KostenSchema { Id = 1 };
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
