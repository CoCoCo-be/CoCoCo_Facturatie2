namespace CoCoCo_Facturatie
{
    partial class FacturatieRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public FacturatieRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Facturatietab1 = this.Factory.CreateRibbonTab();
            this.FacturatieGroep1 = this.Factory.CreateRibbonGroup();
            this.FacturatieGroep2 = this.Factory.CreateRibbonGroup();
            this.ProvisieNota = this.Factory.CreateRibbonButton();
            this.EreloonNota = this.Factory.CreateRibbonButton();
            this.DerdenGeldenNota = this.Factory.CreateRibbonButton();
            this.Facturen = this.Factory.CreateRibbonButton();
            this.BetalingsOverzicht = this.Factory.CreateRibbonButton();
            this.Facturatietab1.SuspendLayout();
            this.FacturatieGroep1.SuspendLayout();
            this.FacturatieGroep2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Facturatietab1
            // 
            this.Facturatietab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.Facturatietab1.Groups.Add(this.FacturatieGroep1);
            this.Facturatietab1.Groups.Add(this.FacturatieGroep2);
            this.Facturatietab1.Label = "Advogenk";
            this.Facturatietab1.Name = "Facturatietab1";
            // 
            // FacturatieGroep1
            // 
            this.FacturatieGroep1.Items.Add(this.ProvisieNota);
            this.FacturatieGroep1.Items.Add(this.EreloonNota);
            this.FacturatieGroep1.Items.Add(this.DerdenGeldenNota);
            this.FacturatieGroep1.Label = "Invoegen";
            this.FacturatieGroep1.Name = "FacturatieGroep1";
            // 
            // FacturatieGroep2
            // 
            this.FacturatieGroep2.Items.Add(this.Facturen);
            this.FacturatieGroep2.Items.Add(this.BetalingsOverzicht);
            this.FacturatieGroep2.Label = "Overzichten";
            this.FacturatieGroep2.Name = "FacturatieGroep2";
            // 
            // ProvisieNota
            // 
            this.ProvisieNota.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.ProvisieNota.Image = global::CoCoCo_Facturatie.Properties.Resources.provisie;
            this.ProvisieNota.Label = "Provisie Nota";
            this.ProvisieNota.Name = "ProvisieNota";
            this.ProvisieNota.ShowImage = true;
            this.ProvisieNota.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ProvisieNota_Click);
            // 
            // EreloonNota
            // 
            this.EreloonNota.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.EreloonNota.Image = global::CoCoCo_Facturatie.Properties.Resources.ereloon;
            this.EreloonNota.Label = "Ereloon Nota";
            this.EreloonNota.Name = "EreloonNota";
            this.EreloonNota.ShowImage = true;
            // 
            // DerdenGeldenNota
            // 
            this.DerdenGeldenNota.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.DerdenGeldenNota.Image = global::CoCoCo_Facturatie.Properties.Resources.derdengelden;
            this.DerdenGeldenNota.Label = "Derden Gelden Nota";
            this.DerdenGeldenNota.Name = "DerdenGeldenNota";
            this.DerdenGeldenNota.ShowImage = true;
            // 
            // Facturen
            // 
            this.Facturen.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.Facturen.Image = global::CoCoCo_Facturatie.Properties.Resources.factuur;
            this.Facturen.Label = "Maken Factuur";
            this.Facturen.Name = "Facturen";
            this.Facturen.ShowImage = true;
            // 
            // BetalingsOverzicht
            // 
            this.BetalingsOverzicht.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.BetalingsOverzicht.Image = global::CoCoCo_Facturatie.Properties.Resources.overzicht;
            this.BetalingsOverzicht.Label = "Betalings Overzicht";
            this.BetalingsOverzicht.Name = "BetalingsOverzicht";
            this.BetalingsOverzicht.ShowImage = true;
            // 
            // FacturatieRibbon
            // 
            this.Name = "FacturatieRibbon";
            this.RibbonType = "Microsoft.Word.Document";
            this.Tabs.Add(this.Facturatietab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.FacturatieRibbon_Load);
            this.Facturatietab1.ResumeLayout(false);
            this.Facturatietab1.PerformLayout();
            this.FacturatieGroep1.ResumeLayout(false);
            this.FacturatieGroep1.PerformLayout();
            this.FacturatieGroep2.ResumeLayout(false);
            this.FacturatieGroep2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab Facturatietab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup FacturatieGroep1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton ProvisieNota;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton EreloonNota;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton DerdenGeldenNota;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup FacturatieGroep2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Facturen;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton BetalingsOverzicht;
    }

    partial class ThisRibbonCollection
    {
        internal FacturatieRibbon FacturatieRibbon
        {
            get { return this.GetRibbon<FacturatieRibbon>(); }
        }
    }
}
