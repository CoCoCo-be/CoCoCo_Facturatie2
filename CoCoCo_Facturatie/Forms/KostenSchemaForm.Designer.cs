namespace CoCoCo_Facturatie
{
    partial class KostenSchemaForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.KostenSchemaOverzicht = new System.Windows.Forms.DataGridView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton1 = new System.Windows.Forms.Button();
            this.KSBTW = new System.Windows.Forms.TextBox();
            this.KSFotokopie = new System.Windows.Forms.TextBox();
            this.KSDactylo = new System.Windows.Forms.TextBox();
            this.KSMail = new System.Windows.Forms.TextBox();
            this.KSWacht = new System.Windows.Forms.TextBox();
            this.KSVerplaatsing = new System.Windows.Forms.TextBox();
            this.KSPrestaties = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.KSNaam = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Label0 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KostenSchemaOverzicht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.KostenSchemaOverzicht);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(927, 346);
            this.splitContainer1.SplitterDistance = 238;
            this.splitContainer1.TabIndex = 14;
            // 
            // KostenSchemaOverzicht
            // 
            this.KostenSchemaOverzicht.AllowUserToAddRows = false;
            this.KostenSchemaOverzicht.AllowUserToDeleteRows = false;
            this.KostenSchemaOverzicht.AllowUserToOrderColumns = true;
            this.KostenSchemaOverzicht.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.KostenSchemaOverzicht.BackgroundColor = System.Drawing.SystemColors.Control;
            this.KostenSchemaOverzicht.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.KostenSchemaOverzicht.Location = new System.Drawing.Point(0, 3);
            this.KostenSchemaOverzicht.Name = "KostenSchemaOverzicht";
            this.KostenSchemaOverzicht.ReadOnly = true;
            this.KostenSchemaOverzicht.Size = new System.Drawing.Size(927, 209);
            this.KostenSchemaOverzicht.TabIndex = 2;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(12, 12);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dataGridView1);
            this.splitContainer2.Panel1.Controls.Add(this.button1);
            this.splitContainer2.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer2.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer2_Panel1_Paint);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.AccessibleName = "Pannel_KostenSchema";
            this.splitContainer2.Panel2.Controls.Add(this.CancelButton1);
            this.splitContainer2.Panel2.Controls.Add(this.OKButton);
            this.splitContainer2.Panel2.Controls.Add(this.KSBTW);
            this.splitContainer2.Panel2.Controls.Add(this.KSFotokopie);
            this.splitContainer2.Panel2.Controls.Add(this.KSDactylo);
            this.splitContainer2.Panel2.Controls.Add(this.KSMail);
            this.splitContainer2.Panel2.Controls.Add(this.KSWacht);
            this.splitContainer2.Panel2.Controls.Add(this.KSVerplaatsing);
            this.splitContainer2.Panel2.Controls.Add(this.KSPrestaties);
            this.splitContainer2.Panel2.Controls.Add(this.label7);
            this.splitContainer2.Panel2.Controls.Add(this.label5);
            this.splitContainer2.Panel2.Controls.Add(this.KSNaam);
            this.splitContainer2.Panel2.Controls.Add(this.label6);
            this.splitContainer2.Panel2.Controls.Add(this.label4);
            this.splitContainer2.Panel2.Controls.Add(this.label2);
            this.splitContainer2.Panel2.Controls.Add(this.label3);
            this.splitContainer2.Panel2.Controls.Add(this.label1);
            this.splitContainer2.Panel2.Controls.Add(this.Label0);
            this.splitContainer2.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer2.Panel2Collapsed = true;
            this.splitContainer2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer2.Size = new System.Drawing.Size(927, 346);
            this.splitContainer2.SplitterDistance = 206;
            this.splitContainer2.TabIndex = 14;
            this.splitContainer2.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer2_SplitterMoved);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(0, 3);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(927, 302);
            this.dataGridView1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(3, 311);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 32);
            this.button1.TabIndex = 2;
            this.button1.Text = "Toevoegen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Toevoegen_kostenschema);
            // 
            // OKButton
            // 
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OKButton.Location = new System.Drawing.Point(817, 31);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(107, 32);
            this.OKButton.TabIndex = 13;
            this.OKButton.Text = "Toevoegen";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.Toevoeg_knop);
            // 
            // CancelButton1
            // 
            this.CancelButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton1.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton1.Location = new System.Drawing.Point(817, 85);
            this.CancelButton1.Name = "CancelButton1";
            this.CancelButton1.Size = new System.Drawing.Size(107, 32);
            this.CancelButton1.TabIndex = 14;
            this.CancelButton1.Text = "Verwijderen";
            this.CancelButton1.UseVisualStyleBackColor = true;
            this.CancelButton1.Click += new System.EventHandler(this.Verwijder_knop);
            // 
            // KSBTW
            // 
            this.KSBTW.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KSBTW.Location = new System.Drawing.Point(654, 104);
            this.KSBTW.Name = "KSBTW";
            this.KSBTW.Size = new System.Drawing.Size(100, 26);
            this.KSBTW.TabIndex = 12;
            this.KSBTW.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.KSBTW.Validating += new System.ComponentModel.CancelEventHandler(this.KSBTW_Validating);
            // 
            // KSFotokopie
            // 
            this.KSFotokopie.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KSFotokopie.Location = new System.Drawing.Point(654, 42);
            this.KSFotokopie.Name = "KSFotokopie";
            this.KSFotokopie.Size = new System.Drawing.Size(100, 26);
            this.KSFotokopie.TabIndex = 10;
            this.KSFotokopie.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.KSFotokopie.Validating += new System.ComponentModel.CancelEventHandler(this.KSCurrency_Validating);
            // 
            // KSDactylo
            // 
            this.KSDactylo.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KSDactylo.Location = new System.Drawing.Point(654, 72);
            this.KSDactylo.Name = "KSDactylo";
            this.KSDactylo.Size = new System.Drawing.Size(100, 26);
            this.KSDactylo.TabIndex = 11;
            this.KSDactylo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.KSDactylo.Validating += new System.ComponentModel.CancelEventHandler(this.KSCurrency_Validating);
            // 
            // KSMail
            // 
            this.KSMail.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KSMail.Location = new System.Drawing.Point(654, 10);
            this.KSMail.Name = "KSMail";
            this.KSMail.Size = new System.Drawing.Size(100, 26);
            this.KSMail.TabIndex = 9;
            this.KSMail.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.KSMail.Validating += new System.ComponentModel.CancelEventHandler(this.KSCurrency_Validating);
            // 
            // KSWacht
            // 
            this.KSWacht.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KSWacht.Location = new System.Drawing.Point(214, 72);
            this.KSWacht.Name = "KSWacht";
            this.KSWacht.Size = new System.Drawing.Size(100, 26);
            this.KSWacht.TabIndex = 7;
            this.KSWacht.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.KSWacht.Validating += new System.ComponentModel.CancelEventHandler(this.KSCurrency_Validating);
            // 
            // KSVerplaatsing
            // 
            this.KSVerplaatsing.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KSVerplaatsing.Location = new System.Drawing.Point(214, 106);
            this.KSVerplaatsing.Name = "KSVerplaatsing";
            this.KSVerplaatsing.Size = new System.Drawing.Size(100, 26);
            this.KSVerplaatsing.TabIndex = 8;
            this.KSVerplaatsing.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.KSVerplaatsing.Validating += new System.ComponentModel.CancelEventHandler(this.KSCurrency_Validating);
            // 
            // KSPrestaties
            // 
            this.KSPrestaties.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KSPrestaties.Location = new System.Drawing.Point(214, 40);
            this.KSPrestaties.Name = "KSPrestaties";
            this.KSPrestaties.Size = new System.Drawing.Size(100, 26);
            this.KSPrestaties.TabIndex = 6;
            this.KSPrestaties.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.KSPrestaties.Validating += new System.ComponentModel.CancelEventHandler(this.KSCurrency_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.CausesValidation = false;
            this.label7.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label7.Location = new System.Drawing.Point(443, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(168, 22);
            this.label7.TabIndex = 17;
            this.label7.Text = "BTW tarief (b.v. 0,21)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.CausesValidation = false;
            this.label5.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(443, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 22);
            this.label5.TabIndex = 17;
            this.label5.Text = "Prijs fotokopie";
            // 
            // KSNaam
            // 
            this.KSNaam.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KSNaam.Location = new System.Drawing.Point(214, 8);
            this.KSNaam.Name = "KSNaam";
            this.KSNaam.Size = new System.Drawing.Size(100, 26);
            this.KSNaam.TabIndex = 5;
            this.KSNaam.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.KSNaam.Validating += new System.ComponentModel.CancelEventHandler(this.KSString_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.CausesValidation = false;
            this.label6.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Location = new System.Drawing.Point(443, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 22);
            this.label6.TabIndex = 18;
            this.label6.Text = "Prijs dactylo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.CausesValidation = false;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(443, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 22);
            this.label4.TabIndex = 18;
            this.label4.Text = "Prijs mail";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.CausesValidation = false;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(3, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 22);
            this.label2.TabIndex = 17;
            this.label2.Text = "Wachtvergoeding prijs/uur";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.CausesValidation = false;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(3, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 22);
            this.label3.TabIndex = 19;
            this.label3.Text = "Verplaatsing prijs/uur";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.CausesValidation = false;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(3, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 22);
            this.label1.TabIndex = 18;
            this.label1.Text = "Prestaties prijs/uur";
            // 
            // Label0
            // 
            this.Label0.AutoSize = true;
            this.Label0.CausesValidation = false;
            this.Label0.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label0.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Label0.Location = new System.Drawing.Point(3, 9);
            this.Label0.Name = "Label0";
            this.Label0.Size = new System.Drawing.Size(49, 22);
            this.Label0.TabIndex = 19;
            this.Label0.Text = "Naam";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // KostenSchemaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 370);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.splitContainer1);
            this.Name = "KostenSchemaForm";
            this.Text = "KostenSchemaForm";
            this.Load += new System.EventHandler(this.KostenSchemaForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.KostenSchemaOverzicht)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        internal System.Windows.Forms.DataGridView KostenSchemaOverzicht;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelButton1;
        private System.Windows.Forms.TextBox KSWacht;
        private System.Windows.Forms.TextBox KSPrestaties;
        private System.Windows.Forms.TextBox KSNaam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Label0;
        private System.Windows.Forms.TextBox KSBTW;
        private System.Windows.Forms.TextBox KSFotokopie;
        private System.Windows.Forms.TextBox KSDactylo;
        private System.Windows.Forms.TextBox KSMail;
        private System.Windows.Forms.TextBox KSVerplaatsing;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        public System.Windows.Forms.DataGridView dataGridView1;
    }
}