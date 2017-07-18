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
        List<String> OGMCodes;
        #endregion

        public FacturatieForm1()
        {
            InitializeComponent();
        }

        private void FacturatieForm1_Load(object sender, EventArgs e)
        {
            List<String> EreloonOGMNumbers, ProvisieOGMNumbers;
            using (var context = new FacturatieModel())
            {
                EreloonOGMNumbers = context.EreloonNotas.Select(p => p.OGMNummer).Distinct().ToList();
                ProvisieOGMNumbers = context.Provisies.Select(p => p.OGMNummer).Distinct().ToList();
                OGMCodes = EreloonOGMNumbers.Union(ProvisieOGMNumbers).ToList();
            }

            CBOgmCode.DataSource = OGMCodes;
        }
    }
}
