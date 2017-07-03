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
    public partial class EreloonNotaForm : Form
    {
        #region Variables
        private static CultureInfo Culture = Variabelen.Cultuur;
        private static NumberStyles Style = Variabelen.NummerStijl;
        public decimal Totaal = 0;
        public decimal provisiesErelonen, provisiesGerechtsKosten = 0;
        IList<KostenSchema> kostenSchemasLijst;
        EreloonNota ereloonNota = new EreloonNota();
        #endregion

        public EreloonNotaForm()
        {
            InitializeComponent();
        }

        private void EreloonNotaForm_Load(object sender, EventArgs e)
        {
            using (var context = new FacturatieModel())
            {
                kostenSchemasLijst = context.KostenSchemas.Where(c => c.Archive==true).ToList();
                KostenSchemaCB.DataSource = kostenSchemasLijst;
                KostenSchemaCB.ValueMember = "KostenSchemaId";
                KostenSchemaCB.DisplayMember = "Naam";
            }
        }

        private void EreloonNotaForm_IntValidating(object sender, CancelEventArgs e)
        {
            ushort waarde;
            if (UInt16.TryParse(((TextBox)sender).Text, NumberStyles.Integer, Culture, out waarde))
            {
                switch (((TextBox)sender).Name)
                {
                    case "DactyloAantal":
                        ereloonNota.Dactylo = waarde;
                        break;
                    case "FotokopiesAantal":
                        ereloonNota.Fotokopie = waarde;
                        break;
                    case "MailAantal":
                        ereloonNota.Fax = waarde;
                        break;
                    case "VerplaatsingAantal":
                        ereloonNota.Verplaatsing = waarde;
                        break;
                }
            }
            else
            {
                errorProvider1.SetError((TextBox)sender,"Alleen getallen");
                e.Cancel = true;
            }
        }

        private void EreloonNotaForm_Validated(object sender, EventArgs e)
        {
            ereloonNota.Berekenen();
            Totaal = ereloonNota.Totaal - provisiesErelonen - provisiesGerechtsKosten - ereloonNota.Derden;

            TeBetalenBedrag.Text = ereloonNota.Totaal.ToString("C", Culture);
            ProvisieErelonenBedrag.Text = provisiesErelonen.ToString("C", Culture);
            ProvisieGerechtskostenBedrag.Text = provisiesGerechtsKosten.ToString("C", Culture);
            TotaalBedrag.Text = Totaal.ToString("C", Culture);
        }

        private void OKButton_Click(object sender, EventArgs e)
        {

        }

        private void KostenSchemaButton_Click(object sender, EventArgs e)
        {
            AlgemeenDataGrid form = new AlgemeenDataGrid();

            form.AlgemeenDG.DataSource = kostenSchemasLijst;
            form.AlgemeenDG.MultiSelect = false;
            form.AlgemeenDG.DefaultCellStyle.Format = "C";
            form.AlgemeenDG.Columns["Archive"].Visible = false;
            form.AlgemeenDG.Columns["KostenSchemaId"].Visible = false;
            form.AlgemeenDG.Columns["Naam"].DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
            form.AlgemeenDG.Columns["BTW"].DefaultCellStyle.Format = "P0";
            form.AlgemeenDG.CurrentCell = form.AlgemeenDG.Rows[KostenSchemaCB.SelectedIndex].Cells[1];

            form.ShowDialog();

            if (form.AlgemeenDG.SelectedRows.Count > 0 )
                KostenSchemaCB.SelectedIndex = form.AlgemeenDG.SelectedRows[0].Index;

        }
    }
}
