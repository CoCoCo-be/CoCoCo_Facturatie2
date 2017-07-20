namespace CoCoCo_Facturatie
{
    partial class FacturatieForm1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FacturatieForm1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.OGMBedrag = new System.Windows.Forms.TextBox();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.OGMCode1 = new System.Windows.Forms.TextBox();
            this.OGMCode2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.OGMCode3 = new System.Windows.Forms.TextBox();
            this.DossierNaam = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.OGMPage = new System.Windows.Forms.TabPage();
            this.DossierPage = new System.Windows.Forms.TabPage();
            this.DossierBedrag = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.LDossierNaam = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.CBDossier = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.OGMPage.SuspendLayout();
            this.DossierPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "OGM-Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.label2.Location = new System.Drawing.Point(12, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "FactuurBedrag";
            // 
            // OGMBedrag
            // 
            this.OGMBedrag.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.OGMBedrag.Location = new System.Drawing.Point(12, 146);
            this.OGMBedrag.Name = "OGMBedrag";
            this.OGMBedrag.Size = new System.Drawing.Size(264, 26);
            this.OGMBedrag.TabIndex = 4;
            this.OGMBedrag.Validating += new System.ComponentModel.CancelEventHandler(this.OGMBedrag_Validating);
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OKButton.Location = new System.Drawing.Point(44, 238);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(104, 32);
            this.OKButton.TabIndex = 7;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            // 
            // CancelButton1
            // 
            this.CancelButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton1.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton1.Location = new System.Drawing.Point(183, 237);
            this.CancelButton1.Name = "CancelButton1";
            this.CancelButton1.Size = new System.Drawing.Size(101, 32);
            this.CancelButton1.TabIndex = 8;
            this.CancelButton1.Text = "Cancel";
            this.CancelButton1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.label3.Location = new System.Drawing.Point(12, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 22);
            this.label3.TabIndex = 1;
            this.label3.Text = "+++";
            // 
            // OGMCode1
            // 
            this.OGMCode1.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.OGMCode1.Location = new System.Drawing.Point(46, 42);
            this.OGMCode1.MaxLength = 3;
            this.OGMCode1.Name = "OGMCode1";
            this.OGMCode1.Size = new System.Drawing.Size(40, 26);
            this.OGMCode1.TabIndex = 1;
            this.OGMCode1.Enter += new System.EventHandler(this.OGMCode_Enter);
            this.OGMCode1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OGMCode_KeyUp);
            this.OGMCode1.Validating += new System.ComponentModel.CancelEventHandler(this.OGMCode_Validating);
            // 
            // OGMCode2
            // 
            this.OGMCode2.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.OGMCode2.Location = new System.Drawing.Point(100, 42);
            this.OGMCode2.MaxLength = 4;
            this.OGMCode2.Name = "OGMCode2";
            this.OGMCode2.Size = new System.Drawing.Size(56, 26);
            this.OGMCode2.TabIndex = 2;
            this.OGMCode2.Enter += new System.EventHandler(this.OGMCode_Enter);
            this.OGMCode2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OGMCode_KeyUp);
            this.OGMCode2.Validating += new System.ComponentModel.CancelEventHandler(this.OGMCode_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.label4.Location = new System.Drawing.Point(236, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 22);
            this.label4.TabIndex = 1;
            this.label4.Text = "+++";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.label5.Location = new System.Drawing.Point(156, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 22);
            this.label5.TabIndex = 1;
            this.label5.Text = "/";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.label6.Location = new System.Drawing.Point(84, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 22);
            this.label6.TabIndex = 1;
            this.label6.Text = "/";
            // 
            // OGMCode3
            // 
            this.OGMCode3.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.OGMCode3.Location = new System.Drawing.Point(172, 42);
            this.OGMCode3.MaxLength = 5;
            this.OGMCode3.Name = "OGMCode3";
            this.OGMCode3.Size = new System.Drawing.Size(64, 26);
            this.OGMCode3.TabIndex = 3;
            this.OGMCode3.Enter += new System.EventHandler(this.OGMCode_Enter);
            this.OGMCode3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OGMCode_KeyUp);
            this.OGMCode3.Validating += new System.ComponentModel.CancelEventHandler(this.OGMCode_Validating);
            // 
            // DossierNaam
            // 
            this.DossierNaam.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DossierNaam.Location = new System.Drawing.Point(12, 82);
            this.DossierNaam.Name = "DossierNaam";
            this.DossierNaam.Size = new System.Drawing.Size(264, 22);
            this.DossierNaam.TabIndex = 1;
            this.DossierNaam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.OGMPage);
            this.tabControl1.Controls.Add(this.DossierPage);
            this.tabControl1.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.tabControl1.Location = new System.Drawing.Point(8, 8);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(296, 224);
            this.tabControl1.TabIndex = 9;
            this.tabControl1.TabIndexChanged += new System.EventHandler(this.ETabIndexChanged);
            // 
            // OGMPage
            // 
            this.OGMPage.BackColor = System.Drawing.SystemColors.Control;
            this.OGMPage.Controls.Add(this.OGMCode2);
            this.OGMPage.Controls.Add(this.label1);
            this.OGMPage.Controls.Add(this.label3);
            this.OGMPage.Controls.Add(this.OGMCode3);
            this.OGMPage.Controls.Add(this.label4);
            this.OGMPage.Controls.Add(this.label5);
            this.OGMPage.Controls.Add(this.OGMCode1);
            this.OGMPage.Controls.Add(this.label6);
            this.OGMPage.Controls.Add(this.OGMBedrag);
            this.OGMPage.Controls.Add(this.label2);
            this.OGMPage.Controls.Add(this.DossierNaam);
            this.OGMPage.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.OGMPage.Location = new System.Drawing.Point(4, 31);
            this.OGMPage.Name = "OGMPage";
            this.OGMPage.Size = new System.Drawing.Size(288, 189);
            this.OGMPage.TabIndex = 0;
            this.OGMPage.Text = "OGM";
            // 
            // DossierPage
            // 
            this.DossierPage.BackColor = System.Drawing.SystemColors.Control;
            this.DossierPage.Controls.Add(this.DossierBedrag);
            this.DossierPage.Controls.Add(this.label8);
            this.DossierPage.Controls.Add(this.LDossierNaam);
            this.DossierPage.Controls.Add(this.label7);
            this.DossierPage.Controls.Add(this.CBDossier);
            this.DossierPage.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.DossierPage.Location = new System.Drawing.Point(4, 31);
            this.DossierPage.Name = "DossierPage";
            this.DossierPage.Size = new System.Drawing.Size(288, 189);
            this.DossierPage.TabIndex = 0;
            this.DossierPage.Text = "Dossier";
            // 
            // DossierBedrag
            // 
            this.DossierBedrag.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.DossierBedrag.Location = new System.Drawing.Point(16, 152);
            this.DossierBedrag.Name = "DossierBedrag";
            this.DossierBedrag.Size = new System.Drawing.Size(264, 26);
            this.DossierBedrag.TabIndex = 1;
            this.DossierBedrag.Validating += new System.ComponentModel.CancelEventHandler(this.DossierBedrag_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.label8.Location = new System.Drawing.Point(16, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 22);
            this.label8.TabIndex = 5;
            this.label8.Text = "FactuurBedrag";
            // 
            // LDossierNaam
            // 
            this.LDossierNaam.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.LDossierNaam.Location = new System.Drawing.Point(16, 80);
            this.LDossierNaam.Name = "LDossierNaam";
            this.LDossierNaam.Size = new System.Drawing.Size(256, 22);
            this.LDossierNaam.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.label7.Location = new System.Drawing.Point(16, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 22);
            this.label7.TabIndex = 2;
            this.label7.Text = "Dossier nummer";
            // 
            // CBDossier
            // 
            this.CBDossier.FormattingEnabled = true;
            this.CBDossier.Location = new System.Drawing.Point(16, 40);
            this.CBDossier.Name = "CBDossier";
            this.CBDossier.Size = new System.Drawing.Size(256, 30);
            this.CBDossier.TabIndex = 0;
            this.CBDossier.Validated += new System.EventHandler(this.CBDossier_Validated);
            // 
            // FacturatieForm1
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CancelButton = this.CancelButton1;
            this.ClientSize = new System.Drawing.Size(309, 278);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.CancelButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FacturatieForm1";
            this.Text = "OGM betaling";
            this.Load += new System.EventHandler(this.FacturatieForm1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.OGMPage.ResumeLayout(false);
            this.OGMPage.PerformLayout();
            this.DossierPage.ResumeLayout(false);
            this.DossierPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox OGMBedrag;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelButton1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox OGMCode1;
        private System.Windows.Forms.TextBox OGMCode2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox OGMCode3;
        private System.Windows.Forms.Label DossierNaam;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage OGMPage;
        private System.Windows.Forms.TabPage DossierPage;
        private System.Windows.Forms.TextBox DossierBedrag;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label LDossierNaam;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CBDossier;
    }
}