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
    public partial class KostenSchemaForm : Form
    {
        private static CultureInfo Culture = Variabelen.Cultuur;
        public System.Data.Entity.DbSet<KostenSchema> KostenSchemaLijst { get; set; }
        Decimal BTW = 0;

        public KostenSchemaForm()
        {
            InitializeComponent();
        }

        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
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
            
        }

        private void Toevoegen_kostenschema(object sender, EventArgs e)
        {
            this.splitContainer2.Panel2Collapsed = false;
        }

        private void Verwijder_knop(object sender, EventArgs e)
        {
            this.splitContainer2.Panel2Collapsed = true;
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
            this.splitContainer2.Panel2Collapsed = true;
            KostenSchema schema = new KostenSchema();
            schema.Naam = KSNaam.Text;
            schema.Prestaties = decimal.Parse(KSPrestaties.Text, NumberStyles.Currency, Culture);
            schema.Wacht = decimal.Parse(KSWacht.Text, NumberStyles.Currency, Culture);
            schema.Verplaatsing = decimal.Parse(KSVerplaatsing.Text, NumberStyles.Currency, Culture);
            schema.Mail= decimal.Parse(KSMail.Text, NumberStyles.Currency, Culture);
            schema.Fotokopie = decimal.Parse(KSFotokopie.Text, NumberStyles.Currency, Culture);
            schema.Dactylo = decimal.Parse(KSDactylo.Text, NumberStyles.Currency, Culture);
            schema.BTW = BTW;
            schema.Archive = false;
            KostenSchemaLijst.Add(schema);
            this.splitContainer2.Panel2Collapsed = true;
        }
    }
}
