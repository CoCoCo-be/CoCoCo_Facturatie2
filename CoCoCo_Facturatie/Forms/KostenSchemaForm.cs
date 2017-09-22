using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace CoCoCo_Facturatie
{
    public partial class KostenSchemaForm : Form
    {
        private static CultureInfo Culture = Variabelen.Cultuur;
        Decimal BTW = 0;

        public List<KostenSchema> Schemas { get; private set; }

        public KostenSchemaForm()
        {
            InitializeComponent();
        }

        private void splitContainer_SplitterMoved(object sender, SplitterEventArgs e)
        {
        }

        private void splitContainer_Panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void KostenSchemaForm_Load(object sender, EventArgs e)
        {
        }

        
        private void KSCurrency_Validating(object sender, CancelEventArgs e)
        {
            if ((((TextBox)sender).Text.Length != 0) && (decimal.TryParse(((TextBox)sender).Text, NumberStyles.Currency, Culture, out decimal waarde)))
            {
                errorProvider1.Clear();
                ((TextBox)sender).Text = waarde.ToString("C", Culture);
            }
            else if (((TextBox)sender).Text.Length != 0)
            {
                errorProvider1.SetError((TextBox)sender, "Alleen getallen");
                e.Cancel = true;
            }
        }

        private void KSBTW_Validating(object sender, CancelEventArgs e)
        {
            if ((((TextBox)sender).Text.Length != 0) && (decimal.TryParse(((TextBox)sender).Text, NumberStyles.Number, Culture, out decimal waarde)))
            {
                errorProvider1.Clear();
                BTW = waarde;
                ((TextBox)sender).Text = waarde.ToString("P", Culture);
            }
            else if (((TextBox)sender).Text.Length != 0)
            {
                errorProvider1.SetError((TextBox)sender, "Alleen getallen");
                e.Cancel = true;
            }
        }

        private void KSString_Validating(object sender, CancelEventArgs e)
        {
            if(((TextBox)sender).Text.Trim().Length == 0 ) 
            {
                errorProvider1.SetError((TextBox)sender, "Mag niet leeg zijn");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.Clear();
            }

        }

        private void Toevoegen_kostenschema(object sender, EventArgs e)
        {
            SplitContainer.Panel2Collapsed = !SplitContainer.Panel2Collapsed;
        }

        private void Verwijder_knop(object sender, EventArgs e)
        {
            SplitContainer.Panel2Collapsed = true;
            KSNaam.Clear();
            KSPrestaties.Clear();
            KSWacht.Clear();
            KSVerplaatsing.Clear();
            KSMail.Clear();
            KSFotokopie.Clear();
            KSDactylo.Clear();
            KSBTW.Clear();
        }

        private void Toevoeg_knop(object sender, EventArgs e)
        {
            this.SplitContainer.Panel2Collapsed = true;
            Schemas.Add(new KostenSchema
            {
                Naam = KSNaam.Text,
                Prestaties = decimal.Parse(KSPrestaties.Text, NumberStyles.Currency, Culture),
                Wacht = decimal.Parse(KSWacht.Text, NumberStyles.Currency, Culture),
                Verplaatsing = decimal.Parse(KSVerplaatsing.Text, NumberStyles.Currency, Culture),
                Mail = decimal.Parse(KSMail.Text, NumberStyles.Currency, Culture),
                Fotokopie = decimal.Parse(KSFotokopie.Text, NumberStyles.Currency, Culture),
                Dactylo = decimal.Parse(KSDactylo.Text, NumberStyles.Currency, Culture),
                BTW = BTW,
                Archive = false
            }
            );

        }
    }
}
