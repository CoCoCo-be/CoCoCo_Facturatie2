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
        public int ereloonUrenWaarde, ereloonMinutenWaarde, verplaatsingUrenWaarde, verplaatsingMinutenWaarde = 0;
        IList<KostenSchema> kostenSchemasLijst;
        public EreloonNota EreloonNota { get; } = new EreloonNota();
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
                EreloonNota.KostenSchema = (KostenSchema)KostenSchemaCB.SelectedItem;
            }
            ProvisieGerechtskostenBedrag.Text = EreloonNota.TotaalProvisiesGerechtskosten.ToString("C", Culture);
            ProvisieErelonenBedrag.Text = (EreloonNota.TotaalProvisiesGerechtskosten + EreloonNota.TotaalProvisiesBTW).ToString("C", Culture);
        }

        private void EreloonNotaForm_CurrentValidation(object sender, CancelEventArgs e)
        {
            if ((((TextBox)sender).Text.Length != 0) && (decimal.TryParse(((TextBox)sender).Text, NumberStyles.Currency, Culture, out decimal waarde)))
            {
                errorProvider1.Clear();
                switch (((TextBox)sender).Name)
                {
                    case "BijkomendeKostenBedrag":
                        EreloonNota.BijkomendeKosten = waarde;
                        break;
                    case "ForfaitBedrag":
                        EreloonNota.Forfait = waarde;
                        break;
                    case "RolzettingBedrag":
                        EreloonNota.Rolzetting = waarde;
                        break;
                    case "DagvaardingBedrag":
                        EreloonNota.Dagvaarding = waarde;
                        break;
                    case "BetekeningBedrag":
                        EreloonNota.Betekening = waarde;
                        break;
                    case "UitvoeringBedrag":
                        EreloonNota.Uitvoering = waarde;
                        break;
                    case "AndereBedrag":
                        EreloonNota.Anderen = waarde;
                        break;
                    case "DerdenBedrag":
                        EreloonNota.Derden = waarde;
                        break;
                }
                ((TextBox)sender).Text = waarde.ToString("C", Culture);
            }
            else if (((TextBox)sender).Text.Length != 0)
            {
                errorProvider1.SetError((TextBox)sender,"Alleen getallen");
                e.Cancel = true;
            }
        }

        private void KostenSchemaCB_Validating(object sender, CancelEventArgs e)
        {
            EreloonNota.KostenSchema = (KostenSchema)KostenSchemaCB.SelectedItem;
        }

        private void EreloonNotaForm_IntValidating(object sender, CancelEventArgs e)
        {
            if ((((TextBox)sender).Text.Length != 0) && (UInt16.TryParse(((TextBox)sender).Text, NumberStyles.Integer, Culture, out ushort waarde)))
            {
                errorProvider1.Clear();
                switch (((TextBox)sender).Name)
                {
                    case "DactyloAantal":
                        EreloonNota.Dactylo = waarde;
                        break;
                    case "FotokopiesAantal":
                        EreloonNota.Fotokopie = waarde;
                        break;
                    case "MailAantal":
                        EreloonNota.Fax = waarde;
                        break;
                    case "VerplaatsingAantal":
                        EreloonNota.Verplaatsing = waarde;
                        break;
                    case "EreloonUren":
                        ereloonUrenWaarde = waarde;
                        EreloonNota.EreloonUren = new TimeSpan(ereloonUrenWaarde, ereloonMinutenWaarde, 0);
                        break;
                    case "EreloonMinuten":
                        ereloonMinutenWaarde = waarde;
                        EreloonNota.EreloonUren = new TimeSpan(ereloonUrenWaarde, ereloonMinutenWaarde, 0);
                        break;
                    case "VerplaatsingUren":
                        verplaatsingUrenWaarde = waarde;
                        EreloonNota.WachtUren = new TimeSpan(verplaatsingUrenWaarde, verplaatsingMinutenWaarde, 0);
                        break;
                    case "VerplaatsingMinuten":
                        verplaatsingMinutenWaarde = waarde;
                        EreloonNota.WachtUren = new TimeSpan(verplaatsingUrenWaarde, verplaatsingMinutenWaarde, 0);
                        break;
                }
            }
            else if (((TextBox)sender).Text.Length != 0)
            {
                errorProvider1.SetError((TextBox)sender,"Alleen getallen");
                e.Cancel = true;
            }
        }

        private void EreloonNotaForm_Validated(object sender, EventArgs e)
        {
            EreloonNota.Berekenen();
            Totaal = EreloonNota.Totaal - EreloonNota.TotaalProvisiesBTW - EreloonNota.TotaalProvisiesErelonen 
                - EreloonNota.TotaalProvisiesGerechtskosten - EreloonNota.Derden;
            TeBetalenBedrag.Text = EreloonNota.Totaal.ToString("C", Culture);
            TotaalBedrag.Text = Totaal.ToString("C", Culture);
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
