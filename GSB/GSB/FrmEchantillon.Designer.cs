
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvVisites = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEchantillons)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisites)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitre
            // 
            this.lblTitre.Size = new System.Drawing.Size(1450, 64);
            // 
            // dgvEchantillons
            // 
            this.dgvEchantillons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEchantillons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEchantillons.Location = new System.Drawing.Point(3, 3);
            this.dgvEchantillons.Name = "dgvEchantillons";
            this.dgvEchantillons.RowHeadersWidth = 51;
            this.dgvEchantillons.RowTemplate.Height = 24;
            this.dgvEchantillons.Size = new System.Drawing.Size(527, 570);
            this.dgvEchantillons.TabIndex = 13;
            this.dgvEchantillons.SelectionChanged += new System.EventHandler(this.dgvEchantillons_SelectionChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvEchantillons);
            this.panel2.Location = new System.Drawing.Point(8, 128);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(530, 598);
            this.panel2.TabIndex = 14;
            // 
            // dgvVisites
            // 
            this.dgvVisites.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVisites.Location = new System.Drawing.Point(3, 3);
            this.dgvVisites.Name = "dgvVisites";
            this.dgvVisites.RowHeadersWidth = 51;
            this.dgvVisites.RowTemplate.Height = 24;
            this.dgvVisites.Size = new System.Drawing.Size(894, 571);
            this.dgvVisites.TabIndex = 14;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvVisites);
            this.panel3.Location = new System.Drawing.Point(541, 127);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(909, 599);
            this.panel3.TabIndex = 15;
            // 
            // FrmEchantillon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1450, 801);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "FrmEchantillon";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmEchantillon_Load);
            this.Controls.SetChildIndex(this.lblTitre, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEchantillons)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisites)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEchantillons;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvVisites;
        private System.Windows.Forms.Panel panel3;
    }
}