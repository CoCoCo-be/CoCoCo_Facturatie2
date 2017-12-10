using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoCoCo_Facturatie
{
    public partial class SetupForm : Form
    {
        public String PartijFile { get; set; }
        public String GebruikersInitialen { get; set; }
        public String FactuurTemplate { get; set; }
        public String FactuurDirectory { get; set; }

        public SetupForm()
        {
            InitializeComponent();
        }

        private void Setup_Load(object sender, EventArgs e)
        {
            PartijFileText.Text = PartijFile;
            GebruikersInitialenText.Text = GebruikersInitialen;
            FactuurTemplateText.Text = FactuurTemplate;
            InvoicePathText.Text = FactuurDirectory;
        }

        private void PartijFileText_MouseClick(object sender, MouseEventArgs e)
        {
            openPartijFileDialog.FileName = PartijFileText.Text;
            if (openPartijFileDialog.ShowDialog() == DialogResult.OK)
                PartijFileText.Text = openPartijFileDialog.FileName;
        }

        private void FactuurTemplateText_MouseClick(object sender, MouseEventArgs e)
        {
            openFactuurFileDialog.FileName = FactuurTemplateText.Text;
            if (openFactuurFileDialog.ShowDialog() == DialogResult.OK)
                FactuurTemplateText.Text = openFactuurFileDialog.FileName; 
        }

        private void TextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            factuurFolderDialog.SelectedPath = InvoicePathText.Text;
            if (factuurFolderDialog.ShowDialog() == DialogResult.OK)
                InvoicePathText.Text = factuurFolderDialog.SelectedPath;
        }

        private void Text_Validated(object sender, EventArgs e)
        {
            PartijFile = PartijFileText.Text;
            GebruikersInitialen = GebruikersInitialenText.Text;
            FactuurTemplate = FactuurTemplateText.Text;
            FactuurDirectory = InvoicePathText.Text;
        }
    }
}
