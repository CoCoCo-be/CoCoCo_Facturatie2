namespace CoCoCo_Facturatie
{
    partial class SetupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupForm));
            this.PartijFileLabel = new System.Windows.Forms.Label();
            this.PartijFileText = new System.Windows.Forms.TextBox();
            this.GebruikersInitialenLabel = new System.Windows.Forms.Label();
            this.GebruikersInitialenText = new System.Windows.Forms.TextBox();
            this.FactuurTemplateLabel = new System.Windows.Forms.Label();
            this.FactuurTemplateText = new System.Windows.Forms.TextBox();
            this.InvoicePathLabel = new System.Windows.Forms.Label();
            this.InvoicePathText = new System.Windows.Forms.TextBox();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton1 = new System.Windows.Forms.Button();
            this.openPartijFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.openFactuurFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.factuurFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // PartijFileLabel
            // 
            this.PartijFileLabel.AutoSize = true;
            this.PartijFileLabel.Location = new System.Drawing.Point(13, 13);
            this.PartijFileLabel.Name = "PartijFileLabel";
            this.PartijFileLabel.Size = new System.Drawing.Size(46, 13);
            this.PartijFileLabel.TabIndex = 0;
            this.PartijFileLabel.Text = "PartijFile";
            // 
            // PartijFileText
            // 
            this.PartijFileText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PartijFileText.Location = new System.Drawing.Point(140, 10);
            this.PartijFileText.Name = "PartijFileText";
            this.PartijFileText.Size = new System.Drawing.Size(380, 20);
            this.PartijFileText.TabIndex = 1;
            this.PartijFileText.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PartijFileText_MouseClick);
            this.PartijFileText.Validated += new System.EventHandler(this.Text_Validated);
            // 
            // GebruikersInitialenLabel
            // 
            this.GebruikersInitialenLabel.AutoSize = true;
            this.GebruikersInitialenLabel.Location = new System.Drawing.Point(13, 39);
            this.GebruikersInitialenLabel.Name = "GebruikersInitialenLabel";
            this.GebruikersInitialenLabel.Size = new System.Drawing.Size(97, 13);
            this.GebruikersInitialenLabel.TabIndex = 0;
            this.GebruikersInitialenLabel.Text = "Gebruikers Initialen";
            // 
            // GebruikersInitialenText
            // 
            this.GebruikersInitialenText.Location = new System.Drawing.Point(140, 36);
            this.GebruikersInitialenText.MaxLength = 2;
            this.GebruikersInitialenText.Name = "GebruikersInitialenText";
            this.GebruikersInitialenText.Size = new System.Drawing.Size(23, 20);
            this.GebruikersInitialenText.TabIndex = 1;
            this.GebruikersInitialenText.Validated += new System.EventHandler(this.Text_Validated);
            // 
            // FactuurTemplateLabel
            // 
            this.FactuurTemplateLabel.AutoSize = true;
            this.FactuurTemplateLabel.Location = new System.Drawing.Point(13, 65);
            this.FactuurTemplateLabel.Name = "FactuurTemplateLabel";
            this.FactuurTemplateLabel.Size = new System.Drawing.Size(90, 13);
            this.FactuurTemplateLabel.TabIndex = 0;
            this.FactuurTemplateLabel.Text = "Factuur Template";
            // 
            // FactuurTemplateText
            // 
            this.FactuurTemplateText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FactuurTemplateText.Location = new System.Drawing.Point(140, 62);
            this.FactuurTemplateText.MaxLength = 2;
            this.FactuurTemplateText.Name = "FactuurTemplateText";
            this.FactuurTemplateText.Size = new System.Drawing.Size(380, 20);
            this.FactuurTemplateText.TabIndex = 1;
            this.FactuurTemplateText.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FactuurTemplateText_MouseClick);
            this.FactuurTemplateText.Validated += new System.EventHandler(this.Text_Validated);
            // 
            // InvoicePathLabel
            // 
            this.InvoicePathLabel.AutoSize = true;
            this.InvoicePathLabel.Location = new System.Drawing.Point(13, 91);
            this.InvoicePathLabel.Name = "InvoicePathLabel";
            this.InvoicePathLabel.Size = new System.Drawing.Size(67, 13);
            this.InvoicePathLabel.TabIndex = 0;
            this.InvoicePathLabel.Text = "Factuur path";
            // 
            // InvoicePathText
            // 
            this.InvoicePathText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InvoicePathText.Location = new System.Drawing.Point(140, 88);
            this.InvoicePathText.MaxLength = 2;
            this.InvoicePathText.Name = "InvoicePathText";
            this.InvoicePathText.Size = new System.Drawing.Size(380, 20);
            this.InvoicePathText.TabIndex = 1;
            this.InvoicePathText.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TextBox1_MouseClick);
            this.InvoicePathText.Validated += new System.EventHandler(this.Text_Validated);
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OKButton.Location = new System.Drawing.Point(281, 127);
            this.OKButton.MaximumSize = new System.Drawing.Size(107, 32);
            this.OKButton.MinimumSize = new System.Drawing.Size(107, 32);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(107, 32);
            this.OKButton.TabIndex = 7;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            // 
            // CancelButton1
            // 
            this.CancelButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton1.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton1.Location = new System.Drawing.Point(416, 127);
            this.CancelButton1.MaximumSize = new System.Drawing.Size(104, 32);
            this.CancelButton1.MinimumSize = new System.Drawing.Size(104, 32);
            this.CancelButton1.Name = "CancelButton1";
            this.CancelButton1.Size = new System.Drawing.Size(104, 32);
            this.CancelButton1.TabIndex = 8;
            this.CancelButton1.Text = "Cancel";
            this.CancelButton1.UseVisualStyleBackColor = true;
            // 
            // openPartijFileDialog
            // 
            this.openPartijFileDialog.FileName = "openPartijFileDialog";
            // 
            // openFactuurFileDialog
            // 
            this.openFactuurFileDialog.FileName = "openFactuurFileDialog";
            // 
            // SetupForm
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelButton1;
            this.ClientSize = new System.Drawing.Size(532, 171);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.CancelButton1);
            this.Controls.Add(this.InvoicePathText);
            this.Controls.Add(this.InvoicePathLabel);
            this.Controls.Add(this.FactuurTemplateText);
            this.Controls.Add(this.FactuurTemplateLabel);
            this.Controls.Add(this.GebruikersInitialenText);
            this.Controls.Add(this.GebruikersInitialenLabel);
            this.Controls.Add(this.PartijFileText);
            this.Controls.Add(this.PartijFileLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SetupForm";
            this.Text = "Setup";
            this.Load += new System.EventHandler(this.Setup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PartijFileLabel;
        private System.Windows.Forms.TextBox PartijFileText;
        private System.Windows.Forms.Label GebruikersInitialenLabel;
        private System.Windows.Forms.TextBox GebruikersInitialenText;
        private System.Windows.Forms.Label FactuurTemplateLabel;
        private System.Windows.Forms.TextBox FactuurTemplateText;
        private System.Windows.Forms.Label InvoicePathLabel;
        private System.Windows.Forms.TextBox InvoicePathText;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelButton1;
        private System.Windows.Forms.OpenFileDialog openPartijFileDialog;
        private System.Windows.Forms.OpenFileDialog openFactuurFileDialog;
        private System.Windows.Forms.FolderBrowserDialog factuurFolderDialog;
    }
}