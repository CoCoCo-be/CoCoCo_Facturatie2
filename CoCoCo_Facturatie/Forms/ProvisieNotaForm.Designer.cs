namespace CoCoCo_Facturatie
{
    partial class ProvisieNotaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EreloonNota));
            this.LabelEreloon = new System.Windows.Forms.Label();
            this.LabelGerechtskosten = new System.Windows.Forms.Label();
            this.EreloonBedrag = new System.Windows.Forms.TextBox();
            this.GerechtskostenBedrag = new System.Windows.Forms.TextBox();
            this.BTWBedrag = new System.Windows.Forms.TextBox();
            this.EreloonTotaal = new System.Windows.Forms.TextBox();
            this.GerechtskostenTotaal = new System.Windows.Forms.TextBox();
            this.TotaalBedrag = new System.Windows.Forms.TextBox();
            this.BTWTotaal = new System.Windows.Forms.TextBox();
            this.BedragTotaal = new System.Windows.Forms.TextBox();
            this.LabelTotaal = new System.Windows.Forms.Label();
            this.LabelLine = new System.Windows.Forms.Label();
            this.CancelButton1 = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.LabelBTW = new System.Windows.Forms.Label();
            this.LabelBedrag = new System.Windows.Forms.Label();
            this.LabelTotaal2 = new System.Windows.Forms.Label();
            this.InterCompany = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // LabelEreloon
            // 
            this.LabelEreloon.AutoSize = true;
            this.LabelEreloon.CausesValidation = false;
            this.LabelEreloon.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelEreloon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LabelEreloon.Location = new System.Drawing.Point(12, 39);
            this.LabelEreloon.Name = "LabelEreloon";
            this.LabelEreloon.Size = new System.Drawing.Size(275, 22);
            this.LabelEreloon.TabIndex = 0;
            this.LabelEreloon.Text = "Provisie op erelonen en bureelkosten";
            // 
            // LabelGerechtskosten
            // 
            this.LabelGerechtskosten.AutoSize = true;
            this.LabelGerechtskosten.CausesValidation = false;
            this.LabelGerechtskosten.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelGerechtskosten.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LabelGerechtskosten.Location = new System.Drawing.Point(12, 73);
            this.LabelGerechtskosten.Name = "LabelGerechtskosten";
            this.LabelGerechtskosten.Size = new System.Drawing.Size(202, 22);
            this.LabelGerechtskosten.TabIndex = 0;
            this.LabelGerechtskosten.Text = "Provisie op gerechtskosten";
            // 
            // EreloonBedrag
            // 
            this.EreloonBedrag.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EreloonBedrag.Location = new System.Drawing.Point(328, 36);
            this.EreloonBedrag.Name = "EreloonBedrag";
            this.EreloonBedrag.Size = new System.Drawing.Size(100, 26);
            this.EreloonBedrag.TabIndex = 1;
            this.EreloonBedrag.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.EreloonBedrag.Validating += new System.ComponentModel.CancelEventHandler(this.EreloonBedrag_Validating);
            this.EreloonBedrag.Validated += new System.EventHandler(this.ProvisieNotaForm_Validated);
            // 
            // GerechtskostenBedrag
            // 
            this.GerechtskostenBedrag.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GerechtskostenBedrag.Location = new System.Drawing.Point(328, 70);
            this.GerechtskostenBedrag.Name = "GerechtskostenBedrag";
            this.GerechtskostenBedrag.Size = new System.Drawing.Size(100, 26);
            this.GerechtskostenBedrag.TabIndex = 2;
            this.GerechtskostenBedrag.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.GerechtskostenBedrag.Validating += new System.ComponentModel.CancelEventHandler(this.GerechtskostenBedrag_Validating);
            this.GerechtskostenBedrag.Validated += new System.EventHandler(this.ProvisieNotaForm_Validated);
            // 
            // BTWBedrag
            // 
            this.BTWBedrag.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.BTWBedrag.CausesValidation = false;
            this.BTWBedrag.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTWBedrag.Location = new System.Drawing.Point(469, 36);
            this.BTWBedrag.Name = "BTWBedrag";
            this.BTWBedrag.ReadOnly = true;
            this.BTWBedrag.Size = new System.Drawing.Size(100, 19);
            this.BTWBedrag.TabIndex = 1;
            this.BTWBedrag.TabStop = false;
            this.BTWBedrag.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // EreloonTotaal
            // 
            this.EreloonTotaal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EreloonTotaal.CausesValidation = false;
            this.EreloonTotaal.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EreloonTotaal.Location = new System.Drawing.Point(610, 36);
            this.EreloonTotaal.Name = "EreloonTotaal";
            this.EreloonTotaal.ReadOnly = true;
            this.EreloonTotaal.Size = new System.Drawing.Size(100, 19);
            this.EreloonTotaal.TabIndex = 1;
            this.EreloonTotaal.TabStop = false;
            this.EreloonTotaal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // GerechtskostenTotaal
            // 
            this.GerechtskostenTotaal.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.GerechtskostenTotaal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GerechtskostenTotaal.CausesValidation = false;
            this.GerechtskostenTotaal.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GerechtskostenTotaal.Location = new System.Drawing.Point(610, 70);
            this.GerechtskostenTotaal.Name = "GerechtskostenTotaal";
            this.GerechtskostenTotaal.ReadOnly = true;
            this.GerechtskostenTotaal.Size = new System.Drawing.Size(100, 19);
            this.GerechtskostenTotaal.TabIndex = 1;
            this.GerechtskostenTotaal.TabStop = false;
            this.GerechtskostenTotaal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TotaalBedrag
            // 
            this.TotaalBedrag.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TotaalBedrag.CausesValidation = false;
            this.TotaalBedrag.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotaalBedrag.Location = new System.Drawing.Point(610, 122);
            this.TotaalBedrag.Name = "TotaalBedrag";
            this.TotaalBedrag.ReadOnly = true;
            this.TotaalBedrag.Size = new System.Drawing.Size(100, 19);
            this.TotaalBedrag.TabIndex = 1;
            this.TotaalBedrag.TabStop = false;
            this.TotaalBedrag.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // BTWTotaal
            // 
            this.BTWTotaal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.BTWTotaal.CausesValidation = false;
            this.BTWTotaal.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTWTotaal.Location = new System.Drawing.Point(469, 122);
            this.BTWTotaal.Name = "BTWTotaal";
            this.BTWTotaal.ReadOnly = true;
            this.BTWTotaal.Size = new System.Drawing.Size(100, 19);
            this.BTWTotaal.TabIndex = 1;
            this.BTWTotaal.TabStop = false;
            this.BTWTotaal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // BedragTotaal
            // 
            this.BedragTotaal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.BedragTotaal.CausesValidation = false;
            this.BedragTotaal.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BedragTotaal.Location = new System.Drawing.Point(328, 122);
            this.BedragTotaal.Name = "BedragTotaal";
            this.BedragTotaal.ReadOnly = true;
            this.BedragTotaal.Size = new System.Drawing.Size(100, 19);
            this.BedragTotaal.TabIndex = 1;
            this.BedragTotaal.TabStop = false;
            this.BedragTotaal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LabelTotaal
            // 
            this.LabelTotaal.AutoSize = true;
            this.LabelTotaal.CausesValidation = false;
            this.LabelTotaal.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTotaal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LabelTotaal.Location = new System.Drawing.Point(12, 125);
            this.LabelTotaal.Name = "LabelTotaal";
            this.LabelTotaal.Size = new System.Drawing.Size(69, 22);
            this.LabelTotaal.TabIndex = 0;
            this.LabelTotaal.Text = "TOTAAL";
            // 
            // LabelLine
            // 
            this.LabelLine.BackColor = System.Drawing.SystemColors.WindowText;
            this.LabelLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LabelLine.CausesValidation = false;
            this.LabelLine.Location = new System.Drawing.Point(16, 109);
            this.LabelLine.Name = "LabelLine";
            this.LabelLine.Size = new System.Drawing.Size(694, 2);
            this.LabelLine.TabIndex = 2;
            // 
            // CancelButton1
            // 
            this.CancelButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton1.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton1.Location = new System.Drawing.Point(608, 176);
            this.CancelButton1.Name = "CancelButton1";
            this.CancelButton1.Size = new System.Drawing.Size(100, 32);
            this.CancelButton1.TabIndex = 4;
            this.CancelButton1.Text = "Cancel";
            this.CancelButton1.UseVisualStyleBackColor = true;
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OKButton.Location = new System.Drawing.Point(469, 177);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(100, 32);
            this.OKButton.TabIndex = 3;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            // 
            // LabelBTW
            // 
            this.LabelBTW.CausesValidation = false;
            this.LabelBTW.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelBTW.Location = new System.Drawing.Point(469, 9);
            this.LabelBTW.Name = "LabelBTW";
            this.LabelBTW.Size = new System.Drawing.Size(100, 22);
            this.LabelBTW.TabIndex = 0;
            this.LabelBTW.Text = "BTW";
            this.LabelBTW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelBedrag
            // 
            this.LabelBedrag.CausesValidation = false;
            this.LabelBedrag.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelBedrag.Location = new System.Drawing.Point(328, 9);
            this.LabelBedrag.Name = "LabelBedrag";
            this.LabelBedrag.Size = new System.Drawing.Size(100, 22);
            this.LabelBedrag.TabIndex = 0;
            this.LabelBedrag.Text = "Bedrag";
            this.LabelBedrag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelTotaal2
            // 
            this.LabelTotaal2.CausesValidation = false;
            this.LabelTotaal2.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTotaal2.Location = new System.Drawing.Point(610, 9);
            this.LabelTotaal2.Name = "LabelTotaal2";
            this.LabelTotaal2.Size = new System.Drawing.Size(100, 22);
            this.LabelTotaal2.TabIndex = 0;
            this.LabelTotaal2.Text = "Totaal";
            this.LabelTotaal2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InterCompany
            // 
            this.InterCompany.AutoSize = true;
            this.InterCompany.Location = new System.Drawing.Point(488, 56);
            this.InterCompany.Name = "InterCompany";
            this.InterCompany.Size = new System.Drawing.Size(91, 17);
            this.InterCompany.TabIndex = 5;
            this.InterCompany.Text = "InterCompany";
            this.InterCompany.UseVisualStyleBackColor = true;
            this.InterCompany.CheckedChanged += new System.EventHandler(this.InterCompany_CheckedChanged);
            this.InterCompany.Validated += new System.EventHandler(this.ProvisieNotaForm_Validated);
            // 
            // ProvisieNotaForm
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.CancelButton1;
            this.ClientSize = new System.Drawing.Size(734, 221);
            this.Controls.Add(this.InterCompany);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.CancelButton1);
            this.Controls.Add(this.LabelLine);
            this.Controls.Add(this.GerechtskostenBedrag);
            this.Controls.Add(this.BedragTotaal);
            this.Controls.Add(this.BTWTotaal);
            this.Controls.Add(this.TotaalBedrag);
            this.Controls.Add(this.GerechtskostenTotaal);
            this.Controls.Add(this.EreloonTotaal);
            this.Controls.Add(this.BTWBedrag);
            this.Controls.Add(this.EreloonBedrag);
            this.Controls.Add(this.LabelTotaal);
            this.Controls.Add(this.LabelGerechtskosten);
            this.Controls.Add(this.LabelBedrag);
            this.Controls.Add(this.LabelTotaal2);
            this.Controls.Add(this.LabelBTW);
            this.Controls.Add(this.LabelEreloon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProvisieNotaForm";
            this.Text = "ProvisieNotaForm";
            this.Load += new System.EventHandler(this.ProvisieNotaForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelEreloon;
        private System.Windows.Forms.Label LabelGerechtskosten;
        private System.Windows.Forms.TextBox EreloonBedrag;
        private System.Windows.Forms.TextBox GerechtskostenBedrag;
        private System.Windows.Forms.TextBox BTWBedrag;
        private System.Windows.Forms.TextBox EreloonTotaal;
        private System.Windows.Forms.TextBox GerechtskostenTotaal;
        private System.Windows.Forms.TextBox TotaalBedrag;
        private System.Windows.Forms.TextBox BTWTotaal;
        private System.Windows.Forms.TextBox BedragTotaal;
        private System.Windows.Forms.Label LabelTotaal;
        private System.Windows.Forms.Label LabelLine;
        private System.Windows.Forms.Button CancelButton1;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Label LabelBTW;
        private System.Windows.Forms.Label LabelBedrag;
        private System.Windows.Forms.Label LabelTotaal2;
        private System.Windows.Forms.CheckBox InterCompany;
    }
}