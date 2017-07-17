namespace CoCoCo_Facturatie
{
    partial class DerdenGeldenForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DerdenGeldenForm));
            this.LabelEreloon = new System.Windows.Forms.Label();
            this.LabelGerechtskosten = new System.Windows.Forms.Label();
            this.SchadeloosStellingBedrag = new System.Windows.Forms.TextBox();
            this.GerechtskostenBedrag = new System.Windows.Forms.TextBox();
            this.TotaalBedrag = new System.Windows.Forms.TextBox();
            this.LabelTotaal = new System.Windows.Forms.Label();
            this.LabelLine = new System.Windows.Forms.Label();
            this.LabelTotaal2 = new System.Windows.Forms.Label();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton1 = new System.Windows.Forms.Button();
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
            this.LabelEreloon.Size = new System.Drawing.Size(144, 22);
            this.LabelEreloon.TabIndex = 0;
            this.LabelEreloon.Text = "Schadeloos stelling";
            // 
            // LabelGerechtskosten
            // 
            this.LabelGerechtskosten.AutoSize = true;
            this.LabelGerechtskosten.CausesValidation = false;
            this.LabelGerechtskosten.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelGerechtskosten.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LabelGerechtskosten.Location = new System.Drawing.Point(12, 73);
            this.LabelGerechtskosten.Name = "LabelGerechtskosten";
            this.LabelGerechtskosten.Size = new System.Drawing.Size(120, 22);
            this.LabelGerechtskosten.TabIndex = 0;
            this.LabelGerechtskosten.Text = "Gerechtskosten";
            // 
            // SchadeloosStellingBedrag
            // 
            this.SchadeloosStellingBedrag.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SchadeloosStellingBedrag.Location = new System.Drawing.Point(328, 36);
            this.SchadeloosStellingBedrag.Name = "SchadeloosStellingBedrag";
            this.SchadeloosStellingBedrag.Size = new System.Drawing.Size(100, 26);
            this.SchadeloosStellingBedrag.TabIndex = 1;
            this.SchadeloosStellingBedrag.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.SchadeloosStellingBedrag.Validating += new System.ComponentModel.CancelEventHandler(this.EreloonBedrag_Validating);
            this.SchadeloosStellingBedrag.Validated += new System.EventHandler(this.DerdenGeldenForm_Validated);
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
            this.GerechtskostenBedrag.Validated += new System.EventHandler(this.DerdenGeldenForm_Validated);
            // 
            // TotaalBedrag
            // 
            this.TotaalBedrag.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TotaalBedrag.CausesValidation = false;
            this.TotaalBedrag.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotaalBedrag.Location = new System.Drawing.Point(328, 122);
            this.TotaalBedrag.Name = "TotaalBedrag";
            this.TotaalBedrag.ReadOnly = true;
            this.TotaalBedrag.Size = new System.Drawing.Size(100, 19);
            this.TotaalBedrag.TabIndex = 1;
            this.TotaalBedrag.TabStop = false;
            this.TotaalBedrag.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.LabelLine.Size = new System.Drawing.Size(410, 2);
            this.LabelLine.TabIndex = 2;
            // 
            // LabelTotaal2
            // 
            this.LabelTotaal2.CausesValidation = false;
            this.LabelTotaal2.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTotaal2.Location = new System.Drawing.Point(328, 9);
            this.LabelTotaal2.Name = "LabelTotaal2";
            this.LabelTotaal2.Size = new System.Drawing.Size(100, 22);
            this.LabelTotaal2.TabIndex = 0;
            this.LabelTotaal2.Text = "Totaal";
            this.LabelTotaal2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OKButton.Location = new System.Drawing.Point(184, 176);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(107, 32);
            this.OKButton.TabIndex = 5;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            // 
            // CancelButton1
            // 
            this.CancelButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton1.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton1.Location = new System.Drawing.Point(323, 175);
            this.CancelButton1.Name = "CancelButton1";
            this.CancelButton1.Size = new System.Drawing.Size(104, 32);
            this.CancelButton1.TabIndex = 6;
            this.CancelButton1.Text = "Cancel";
            this.CancelButton1.UseVisualStyleBackColor = true;
            // 
            // DerdenGeldenForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(443, 221);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.CancelButton1);
            this.Controls.Add(this.LabelLine);
            this.Controls.Add(this.GerechtskostenBedrag);
            this.Controls.Add(this.TotaalBedrag);
            this.Controls.Add(this.SchadeloosStellingBedrag);
            this.Controls.Add(this.LabelTotaal);
            this.Controls.Add(this.LabelGerechtskosten);
            this.Controls.Add(this.LabelTotaal2);
            this.Controls.Add(this.LabelEreloon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DerdenGeldenForm";
            this.Text = "DerdenGeldenForm";
            this.Load += new System.EventHandler(this.DerdenGeldenForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelEreloon;
        private System.Windows.Forms.Label LabelGerechtskosten;
        private System.Windows.Forms.TextBox SchadeloosStellingBedrag;
        private System.Windows.Forms.TextBox GerechtskostenBedrag;
        private System.Windows.Forms.TextBox TotaalBedrag;
        private System.Windows.Forms.Label LabelTotaal;
        private System.Windows.Forms.Label LabelLine;
        private System.Windows.Forms.Label LabelTotaal2;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelButton1;
    }
}