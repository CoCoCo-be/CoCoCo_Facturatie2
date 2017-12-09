using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace CoCoCo_Facturatie
{
    public partial class BetalingsOverzichtForm : Form
    {
        private static CultureInfo Culture = Variabelen.Cultuur;

        public List<OverzichtBetalingen> OverzichtSource { get; set; }

        public BetalingsOverzichtForm()
        {
            InitializeComponent();
        }

        private void BetalingsOverzichtForm_Load(object sender, EventArgs e)
        {
            BetalingsGridView.DataSource = OverzichtSource;
            BetalingsGridView.DefaultCellStyle.Format = "C";
            BetalingsGridView.Columns["Tijd"].DefaultCellStyle.Format = "g";
        }

        private void BetalingsGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //get the current column details
            string strColumnName = BetalingsGridView.Columns[e.ColumnIndex].Name;
            SortOrder strSortOrder = getSortOrder(e.ColumnIndex);

            OverzichtSource.Sort(new OverzichBetalingenComparer(strColumnName, strSortOrder));
            BetalingsOverzichtForm_Load(sender, e);
            BetalingsGridView.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = strSortOrder;
            BetalingsGridView.Refresh();
        }


        private SortOrder getSortOrder(int columnIndex)
        {
            if (BetalingsGridView.Columns[columnIndex].HeaderCell.SortGlyphDirection == SortOrder.None ||
                BetalingsGridView.Columns[columnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending)
            {
                BetalingsGridView.Columns[columnIndex].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                return SortOrder.Ascending;
            }
            else
            {
                BetalingsGridView.Columns[columnIndex].HeaderCell.SortGlyphDirection = SortOrder.Descending;
                return SortOrder.Descending;
            }
        }
    }
}
