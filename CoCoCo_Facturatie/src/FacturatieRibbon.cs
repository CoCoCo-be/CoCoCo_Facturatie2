using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;

namespace CoCoCo_Facturatie
{
    public partial class FacturatieRibbon
    {
        private void FacturatieRibbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void ProvisieNota_Click(object sender, RibbonControlEventArgs e)
        {
            ProvisieNotaForm form = new ProvisieNotaForm();
            form.Show();
        }
    }
}
