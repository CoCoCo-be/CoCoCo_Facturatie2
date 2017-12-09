namespace CoCoCo_Facturatie
{
    partial class BetalingsOverzichtForm
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
            this.BetalingsGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.BetalingsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // BetalingsGridView
            // 
            this.BetalingsGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BetalingsGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.BetalingsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BetalingsGridView.Location = new System.Drawing.Point(12, 12);
            this.BetalingsGridView.Name = "BetalingsGridView";
            this.BetalingsGridView.ReadOnly = true;
            this.BetalingsGridView.Size = new System.Drawing.Size(564, 375);
            this.BetalingsGridView.TabIndex = 0;
            this.BetalingsGridView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.BetalingsGridView_ColumnHeaderMouseClick);
            // 
            // BetalingsOverzichtForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 399);
            this.Controls.Add(this.BetalingsGridView);
            this.Name = "BetalingsOverzichtForm";
            this.Text = "Overzicht openstaande betalingen";
            this.Load += new System.EventHandler(this.BetalingsOverzichtForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BetalingsGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView BetalingsGridView;
    }
}