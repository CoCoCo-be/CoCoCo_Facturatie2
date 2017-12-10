namespace CoCoCo_Facturatie
{
    partial class AlgemeenDataGrid
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
            this.AlgemeenDG = new System.Windows.Forms.DataGridView();
            this.OKButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.AlgemeenDG)).BeginInit();
            this.SuspendLayout();
            // 
            // AlgemeenDG
            // 
            this.AlgemeenDG.AllowUserToAddRows = false;
            this.AlgemeenDG.AllowUserToDeleteRows = false;
            this.AlgemeenDG.AllowUserToOrderColumns = true;
            this.AlgemeenDG.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AlgemeenDG.BackgroundColor = System.Drawing.SystemColors.Control;
            this.AlgemeenDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AlgemeenDG.Location = new System.Drawing.Point(8, 16);
            this.AlgemeenDG.Name = "AlgemeenDG";
            this.AlgemeenDG.ReadOnly = true;
            this.AlgemeenDG.Size = new System.Drawing.Size(580, 265);
            this.AlgemeenDG.TabIndex = 0;
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OKButton.Location = new System.Drawing.Point(484, 289);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(100, 32);
            this.OKButton.TabIndex = 4;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // AlgemeenDataGrid
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 330);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.AlgemeenDG);
            this.Name = "AlgemeenDataGrid";
            this.Text = "AlgemeenDataGrid";
            ((System.ComponentModel.ISupportInitialize)(this.AlgemeenDG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button OKButton;
        internal System.Windows.Forms.DataGridView AlgemeenDG;
    }
}