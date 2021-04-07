
namespace GSB
{
    partial class FrmEchantillon
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
            this.dgvEchantillons = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEchantillons)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitre
            // 
            this.lblTitre.Dock = System.Windows.Forms.DockStyle.None;
            this.lblTitre.Location = new System.Drawing.Point(0, 21);
            this.lblTitre.Size = new System.Drawing.Size(1136, 55);
            // 
            // dgvEchantillons
            // 
            this.dgvEchantillons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEchantillons.Location = new System.Drawing.Point(8, 115);
            this.dgvEchantillons.Name = "dgvEchantillons";
            this.dgvEchantillons.RowHeadersWidth = 51;
            this.dgvEchantillons.RowTemplate.Height = 24;
            this.dgvEchantillons.Size = new System.Drawing.Size(1128, 427);
            this.dgvEchantillons.TabIndex = 13;
            // 
            // FrmEchantillon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 750);
            this.Controls.Add(this.dgvEchantillons);
            this.Name = "FrmEchantillon";
            this.Text = "Form1";
            this.Controls.SetChildIndex(this.lblTitre, 0);
            this.Controls.SetChildIndex(this.dgvEchantillons, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEchantillons)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEchantillons;
    }
}