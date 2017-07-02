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
    public partial class ProvisieNotaForm : Form
    {
        #region Variables
        private static CultureInfo Culture = Variabelen.Cultuur;
        public double Gerechtskosten = 0, Ereloon = 0, BTW = 0, Totaal = 0;
        public Boolean IC = false;
        private static NumberStyles Style = Variabelen.NummerStijl;
        #endregion

        public ProvisieNotaForm()
        {
            InitializeComponent();
        }

        private void ProvisieNotaForm_Load(object sender, EventArgs e)
        {
            ProvisieNotaForm_Validated(sender, e);
        }

        private void InterCompany_CheckedChanged(object sender, EventArgs e)
        {
            IC = InterCompany.Checked;
            if (IC)
            {
                BTWBedrag.Hide();
                BTWTotaal.Hide();
            } else
            {
                BTWBedrag.Show();
                BTWTotaal.Show();
            }
            ProvisieNotaForm_Validated(sender, e);
        }

        private void ProvisieNotaForm_Validated(object sender, EventArgs e)
        {
            if (IC)
                BTW = 0;
            else
                BTW = Ereloon * 0.21;
            EreloonBedrag.Text = Ereloon.ToString("C", Culture);
            BTWBedrag.Text = BTW.ToString("C", Culture);
            BTWTotaal.Text = BTWBedrag.Text;
            EreloonTotaal.Text = (BTW + Ereloon).ToString("C", Culture);
            GerechtskostenBedrag.Text = Gerechtskosten.ToString("C", Culture);
            GerechtskostenTotaal.Text = GerechtskostenBedrag.Text;
            BedragTotaal.Text = (Gerechtskosten + Ereloon).ToString("C");
            Totaal = Gerechtskosten + BTW + Ereloon;
            TotaalBedrag.Text = (Totaal.ToString("C"));
        }

        private void EreloonBedrag_Validating(object sender, CancelEventArgs e)
        {
            if (! Double.TryParse(EreloonBedrag.Text, Style, Culture, out Ereloon))
            {
                MessageBox.Show("Waarde in veld is geen getal of bedrag.", "Foutieve Waarde", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EreloonBedrag.Text = Ereloon.ToString("C", Culture);
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
