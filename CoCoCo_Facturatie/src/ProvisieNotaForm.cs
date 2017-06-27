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
        private static CultureInfo Culture = new CultureInfo("nl-BE");
        private double Gerechtskosten = 0, Ereloon = 0, BTW = 0;
        private static NumberStyles Style = NumberStyles.Currency ;
        #endregion

        public ProvisieNotaForm()
        {
            InitializeComponent();
        }

        private void ProvisieNotaForm_Load(object sender, EventArgs e)
        {
            ProvisieNotaForm_Validated(sender, e);
        }

        private void ProvisieNotaForm_Validated(object sender, EventArgs e)
        {
            EreloonBedrag.Text = Ereloon.ToString("C", Culture);
            BTWBedrag.Text = BTW.ToString("C", Culture);
            BTWTotaal.Text = BTWBedrag.Text;
            EreloonTotaal.Text = (BTW + Ereloon).ToString("C", Culture);
            GerechtskostenBedrag.Text = Gerechtskosten.ToString("C", Culture);
            GerechtskostenTotaal.Text = GerechtskostenBedrag.Text;
            BedragTotaal.Text = (Gerechtskosten + Ereloon).ToString("C");
            Totaal.Text = (Gerechtskosten + BTW + Ereloon).ToString("C");
        }

        private void EreloonBedrag_Validating(object sender, CancelEventArgs e)
        {
            if (! Double.TryParse(EreloonBedrag.Text, Style, Culture, out Ereloon))
            {
                MessageBox.Show("Waarde in veld is geen getal of bedrag.", "Foutieve Waarde", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EreloonBedrag.Text = Ereloon.ToString("C", Culture);
            }
            BTW = Ereloon * 0.21;
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
