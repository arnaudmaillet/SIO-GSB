
namespace GSB
{
    partial class FrmPraticien
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
            this.zoneFiche = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvEchantillons = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.lblMotif = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBilan = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lstMedicament = new System.Windows.Forms.ListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblSpecialite = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblTelephone = new System.Windows.Forms.Label();
            this.lblRue = new System.Windows.Forms.Label();
            this.lblPraticien = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvVisites = new System.Windows.Forms.DataGridView();
            this.message = new System.Windows.Forms.Label();
            this.zoneFiche.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEchantillons)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisites)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitre
            // 
            this.lblTitre.Size = new System.Drawing.Size(1651, 79);
            // 
            // zoneFiche
            // 
            this.zoneFiche.AutoScroll = true;
            this.zoneFiche.Controls.Add(this.panel4);
            this.zoneFiche.Controls.Add(this.panel3);
            this.zoneFiche.Dock = System.Windows.Forms.DockStyle.Left;
            this.zoneFiche.Location = new System.Drawing.Point(611, 107);
            this.zoneFiche.Margin = new System.Windows.Forms.Padding(4);
            this.zoneFiche.Name = "zoneFiche";
            this.zoneFiche.Size = new System.Drawing.Size(1085, 880);
            this.zoneFiche.TabIndex = 20;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.dgvEchantillons);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.lblMotif);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.lblBilan);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.lstMedicament);
            this.panel4.Location = new System.Drawing.Point(21, 327);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1024, 492);
            this.panel4.TabIndex = 112;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(17, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 39);
            this.label2.TabIndex = 109;
            this.label2.Text = "Motif";
            // 
            // dgvEchantillons
            // 
            this.dgvEchantillons.BackgroundColor = System.Drawing.Color.White;
            this.dgvEchantillons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEchantillons.Location = new System.Drawing.Point(636, 62);
            this.dgvEchantillons.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.dgvEchantillons.Name = "dgvEchantillons";
            this.dgvEchantillons.RowHeadersWidth = 51;
            this.dgvEchantillons.RowTemplate.Height = 28;
            this.dgvEchantillons.Size = new System.Drawing.Size(341, 385);
            this.dgvEchantillons.TabIndex = 111;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(631, 21);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(391, 39);
            this.label4.TabIndex = 100;
            this.label4.Text = "Echantillons fournis";
            // 
            // lblMotif
            // 
            this.lblMotif.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMotif.Location = new System.Drawing.Point(199, 21);
            this.lblMotif.Name = "lblMotif";
            this.lblMotif.Size = new System.Drawing.Size(304, 25);
            this.lblMotif.TabIndex = 110;
            this.lblMotif.Text = "Motif";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 24);
            this.label1.TabIndex = 69;
            this.label1.Text = "Bilan de la visite";
            // 
            // lblBilan
            // 
            this.lblBilan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBilan.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBilan.Location = new System.Drawing.Point(17, 96);
            this.lblBilan.Name = "lblBilan";
            this.lblBilan.Size = new System.Drawing.Size(594, 226);
            this.lblBilan.TabIndex = 97;
            this.lblBilan.Text = "Bilan";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(17, 337);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(300, 39);
            this.label3.TabIndex = 99;
            this.label3.Text = "Médicaments présentés";
            // 
            // lstMedicament
            // 
            this.lstMedicament.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstMedicament.FormattingEnabled = true;
            this.lstMedicament.ItemHeight = 24;
            this.lstMedicament.Location = new System.Drawing.Point(23, 380);
            this.lstMedicament.Margin = new System.Windows.Forms.Padding(4);
            this.lstMedicament.Name = "lstMedicament";
            this.lstMedicament.Size = new System.Drawing.Size(299, 52);
            this.lstMedicament.TabIndex = 101;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblSpecialite);
            this.panel3.Controls.Add(this.lblType);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.lblEmail);
            this.panel3.Controls.Add(this.lblTelephone);
            this.panel3.Controls.Add(this.lblRue);
            this.panel3.Controls.Add(this.lblPraticien);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Location = new System.Drawing.Point(21, 87);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(977, 212);
            this.panel3.TabIndex = 102;
            // 
            // lblSpecialite
            // 
            this.lblSpecialite.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpecialite.Location = new System.Drawing.Point(644, 97);
            this.lblSpecialite.Name = "lblSpecialite";
            this.lblSpecialite.Size = new System.Drawing.Size(316, 71);
            this.lblSpecialite.TabIndex = 110;
            this.lblSpecialite.Text = "Spécialité";
            // 
            // lblType
            // 
            this.lblType.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(644, 11);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(317, 25);
            this.lblType.TabIndex = 109;
            this.lblType.Text = "Type";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(463, 97);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 24);
            this.label11.TabIndex = 107;
            this.label11.Text = "Spécialité";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(463, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(137, 24);
            this.label10.TabIndex = 106;
            this.label10.Text = "Type praticien";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(153, 133);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(63, 24);
            this.lblEmail.TabIndex = 104;
            this.lblEmail.Text = "Email";
            // 
            // lblTelephone
            // 
            this.lblTelephone.AutoSize = true;
            this.lblTelephone.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelephone.Location = new System.Drawing.Point(153, 95);
            this.lblTelephone.Name = "lblTelephone";
            this.lblTelephone.Size = new System.Drawing.Size(104, 24);
            this.lblTelephone.TabIndex = 103;
            this.lblTelephone.Text = "Téléphone";
            // 
            // lblRue
            // 
            this.lblRue.AutoSize = true;
            this.lblRue.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRue.Location = new System.Drawing.Point(153, 54);
            this.lblRue.Name = "lblRue";
            this.lblRue.Size = new System.Drawing.Size(46, 24);
            this.lblRue.TabIndex = 102;
            this.lblRue.Text = "Rue";
            // 
            // lblPraticien
            // 
            this.lblPraticien.AutoSize = true;
            this.lblPraticien.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPraticien.Location = new System.Drawing.Point(153, 11);
            this.lblPraticien.Name = "lblPraticien";
            this.lblPraticien.Size = new System.Drawing.Size(90, 24);
            this.lblPraticien.TabIndex = 101;
            this.lblPraticien.Text = "Praticien";
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(25, 11);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(111, 25);
            this.label14.TabIndex = 100;
            this.label14.Text = "Praticien";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(25, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 24);
            this.label6.TabIndex = 99;
            this.label6.Text = "Téléphone";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(25, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 25);
            this.label7.TabIndex = 98;
            this.label7.Text = "Rue";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(25, 135);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 25);
            this.label8.TabIndex = 97;
            this.label8.Text = "Email";
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.dgvVisites);
            this.panel2.Controls.Add(this.message);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 107);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(611, 880);
            this.panel2.TabIndex = 19;
            // 
            // dgvVisites
            // 
            this.dgvVisites.AllowUserToAddRows = false;
            this.dgvVisites.AllowUserToDeleteRows = false;
            this.dgvVisites.AllowUserToOrderColumns = true;
            this.dgvVisites.AllowUserToResizeColumns = false;
            this.dgvVisites.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvVisites.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvVisites.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVisites.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvVisites.Location = new System.Drawing.Point(21, 87);
            this.dgvVisites.Margin = new System.Windows.Forms.Padding(267, 2, 3, 2);
            this.dgvVisites.Name = "dgvVisites";
            this.dgvVisites.RowHeadersWidth = 62;
            this.dgvVisites.RowTemplate.Height = 24;
            this.dgvVisites.Size = new System.Drawing.Size(587, 960);
            this.dgvVisites.TabIndex = 17;
            // 
            // message
            // 
            this.message.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.message.Location = new System.Drawing.Point(16, 25);
            this.message.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(516, 26);
            this.message.TabIndex = 15;
            this.message.Text = "Sélectionner la visite pour afficher le détail";
            // 
            // FrmPraticien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1651, 1055);
            this.Controls.Add(this.zoneFiche);
            this.Controls.Add(this.panel2);
            this.Name = "FrmPraticien";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmPraticien_Load);
            this.Controls.SetChildIndex(this.lblTitre, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.zoneFiche, 0);
            this.zoneFiche.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEchantillons)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisites)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel zoneFiche;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvEchantillons;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblMotif;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBilan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstMedicament;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblSpecialite;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblTelephone;
        private System.Windows.Forms.Label lblRue;
        private System.Windows.Forms.Label lblPraticien;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvVisites;
        private System.Windows.Forms.Label message;
    }
}