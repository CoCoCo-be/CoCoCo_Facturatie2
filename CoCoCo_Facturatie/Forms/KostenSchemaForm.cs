using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace CoCoCo_Facturatie
{
    public partial class KostenSchemaForm : Form
    {
        private static CultureInfo Culture = Variabelen.Cultuur;
        Decimal BTW = 0;

        public List<KostenSchema> KostenSchemaSource { get; set; }
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
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = KostenSchemaSource;
            dataGridView1.DefaultCellStyle.Format = "C";
            dataGridView1.Columns["BTW"].DefaultCellStyle.Format = "G";
            dataGridView1.Columns["KostenSchemaId"].Visible = false;
            dataGridView1.Columns["Naam"].DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
            dataGridView1.Columns["Archive"].SortMode = DataGridViewColumnSortMode.Programmatic;

            foreach (DataGridViewColumn dc in dataGridView1.Columns)
            {
                dc.ReadOnly = true;
            }
            dataGridView1.Columns["Archive"].ReadOnly = false;

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
            if (((TextBox)sender).Text.Trim().Length == 0)
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
            SplitContainer.Panel2.Show();
            SplitContainer.Panel2Collapsed = false;
            SplitContainer.Panel2.Refresh();
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
            if (null == Schemas)
                Schemas = new List<KostenSchema>();
            var NieuwKostenSchema = new KostenSchema
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
            };
            KostenSchemaSource.Add(NieuwKostenSchema);
            Schemas.Add(NieuwKostenSchema);
            KostenSchemaForm_Load(sender, e);
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //get the current column details
            string strColumnName = dataGridView1.Columns[e.ColumnIndex].Name;
            SortOrder strSortOrder = getSortOrder(e.ColumnIndex);

            KostenSchemaSource.Sort(new KostenSchemaComparer(strColumnName, strSortOrder));
            KostenSchemaForm_Load(sender, e);
            dataGridView1.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = strSortOrder;
        }

        private SortOrder getSortOrder(int columnIndex)
        {
            if (dataGridView1.Columns[columnIndex].HeaderCell.SortGlyphDirection == SortOrder.None ||
                dataGridView1.Columns[columnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending)
            {
                dataGridView1.Columns[columnIndex].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                return SortOrder.Ascending;
            }
            else
            {
                dataGridView1.Columns[columnIndex].HeaderCell.SortGlyphDirection = SortOrder.Descending;
                return SortOrder.Descending;
            }
        }
    }
}
