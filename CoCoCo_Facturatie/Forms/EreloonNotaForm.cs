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
        public double Totaal = 0;
        IList<KostenSchema> kostenSchemasLijst;
        #endregion

        public EreloonNotaForm()
        {
            InitializeComponent();
        }

        private void EreloonNotaForm_Load(object sender, EventArgs e)
        {
            using (var context = new FacturatieModel())
            {
                kostenSchemasLijst = context.KostenSchemas.Where(c => c.Archive==true).ToArray();
                KostenSchemaCB.DataSource = kostenSchemasLijst;
                KostenSchemaCB.ValueMember = "KostenSchemaId";
                KostenSchemaCB.DisplayMember = "Naam";
            }
        }

        private void EreloonNotaForm_Validated(object sender, EventArgs e)
        {

        }

        private void OKButton_Click(object sender, EventArgs e)
        {

        }

        private void KostenSchemaButton_Click(object sender, EventArgs e)
        {
            AlgemeenDataGrid form = new AlgemeenDataGrid();
            form.AlgemeenDG.DataSource = kostenSchemasLijst;
            form.AlgemeenDG.Columns["Archive"].Visible = false;
            form.AlgemeenDG.Columns["KostenSchemaId"].Visible = false;
            form.AlgemeenDG.DefaultCellStyle.Format = "C";
            form.AlgemeenDG.Columns["Naam"].DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
            form.AlgemeenDG.Columns["BTW"].DefaultCellStyle.Format = "P0";
            form.Show();
        }
    }
}
