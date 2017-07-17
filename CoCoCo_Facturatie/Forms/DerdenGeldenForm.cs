using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoCoCo_Facturatie
{
    public partial class DerdenGeldenForm : Form
    {
        #region Variables
        private static CultureInfo Culture = Variabelen.Cultuur;
        public double Gerechtskosten = 0, SchadeloosStelling = 0, Totaal = 0;
        private static NumberStyles Style = Variabelen.NummerStijl;
        #endregion

        public DerdenGeldenForm()
        {
            InitializeComponent();
        }

        private void DerdenGeldenForm_Load(object sender, EventArgs e)
        {
            DerdenGeldenForm_Validated(sender, e);
        }

        private void DerdenGeldenForm_Validated(object sender, EventArgs e)
        {
            Totaal = Gerechtskosten + SchadeloosStelling;
            SchadeloosStellingBedrag.Text = SchadeloosStelling.ToString("C", Culture);
            GerechtskostenBedrag.Text = Gerechtskosten.ToString("C", Culture);
            TotaalBedrag.Text = (Gerechtskosten + SchadeloosStelling).ToString("C");
        }

        private void EreloonBedrag_Validating(object sender, CancelEventArgs e)
        {
            if (! Double.TryParse(SchadeloosStellingBedrag.Text, Style, Culture, out SchadeloosStelling))
            {
                MessageBox.Show("Waarde in veld is geen getal of bedrag.", "Foutieve Waarde", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SchadeloosStellingBedrag.Text = SchadeloosStelling.ToString("C", Culture);
            }
        }

        private void GerechtskostenBedrag_Validating(object sender, CancelEventArgs e)
        {
            if (!Double.TryParse(GerechtskostenBedrag.Text, Style, Culture, out Gerechtskosten))
            {
                MessageBox.Show("Waarde in veld is geen getal of bedrag.", "Foutieve Waarde", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GerechtskostenBedrag.Text = Gerechtskosten.ToString("C", Culture);
            }
        }
    }
}
