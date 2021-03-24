namespace GSB
{
    partial class FrmAjout
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
            this.lblVisiteur = new System.Windows.Forms.Label();
            this.zoneSaisie = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvVisites = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbxPraticien = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxMotif = new System.Windows.Forms.ComboBox();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.zoneSaisie.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisites)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitre
            // 
            this.lblTitre.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.lblTitre.Size = new System.Drawing.Size(1274, 49);
            // 
            // lblVisiteur
            // 
            this.lblVisiteur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVisiteur.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVisiteur.Location = new System.Drawing.Point(0, 0);
            this.lblVisiteur.Name = "lblVisiteur";
            this.lblVisiteur.Size = new System.Drawing.Size(1472, 47);
            this.lblVisiteur.TabIndex = 1;
            this.lblVisiteur.Text = "Visiteur";
            // 
            // zoneSaisie
            // 
            this.zoneSaisie.AutoSize = true;
            this.zoneSaisie.Controls.Add(this.label5);
            this.zoneSaisie.Controls.Add(this.dgvVisites);
            this.zoneSaisie.Dock = System.Windows.Forms.DockStyle.Left;
            this.zoneSaisie.Location = new System.Drawing.Point(0, 73);
            this.zoneSaisie.Name = "zoneSaisie";
            this.zoneSaisie.Size = new System.Drawing.Size(589, 684);
            this.zoneSaisie.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 2);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(305, 39);
            this.label5.TabIndex = 18;
            this.label5.Text = "Liste des rendez-vous déjà enregistrés";
            // 
            // dgvVisites
            // 
            this.dgvVisites.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVisites.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvVisites.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVisites.Enabled = false;
            this.dgvVisites.Location = new System.Drawing.Point(15, 43);
            this.dgvVisites.Margin = new System.Windows.Forms.Padding(2);
            this.dgvVisites.Name = "dgvVisites";
            this.dgvVisites.RowHeadersWidth = 62;
            this.dgvVisites.RowTemplate.Height = 24;
            this.dgvVisites.Size = new System.Drawing.Size(572, 750);
            this.dgvVisites.TabIndex = 17;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(589, 73);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(471, 684);
            this.panel4.TabIndex = 22;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.cbxPraticien);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.cbxMotif);
            this.panel3.Controls.Add(this.btnAjouter);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.dtpDate);
            this.panel3.Location = new System.Drawing.Point(18, 43);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(380, 310);
            this.panel3.TabIndex = 14;
            // 
            // cbxPraticien
            // 
            this.cbxPraticien.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxPraticien.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxPraticien.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxPraticien.FormattingEnabled = true;
            this.cbxPraticien.Location = new System.Drawing.Point(127, 67);
            this.cbxPraticien.Name = "cbxPraticien";
            this.cbxPraticien.Size = new System.Drawing.Size(246, 26);
            this.cbxPraticien.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 14);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(266, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Nouveau rendez vous";
            // 
            // cbxMotif
            // 
            this.cbxMotif.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxMotif.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxMotif.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxMotif.FormattingEnabled = true;
            this.cbxMotif.Location = new System.Drawing.Point(127, 122);
            this.cbxMotif.Name = "cbxMotif";
            this.cbxMotif.Size = new System.Drawing.Size(246, 26);
            this.cbxMotif.TabIndex = 1;
            // 
            // btnAjouter
            // 
            this.btnAjouter.BackColor = System.Drawing.Color.Red;
            this.btnAjouter.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjouter.Location = new System.Drawing.Point(143, 255);
            this.btnAjouter.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(182, 38);
            this.btnAjouter.TabIndex = 12;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = false;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 125);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Motif";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 181);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Date et heure";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 70);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Praticien";
            // 
            // dtpDate
            // 
            this.dtpDate.CalendarFont = new System.Drawing.Font("Georgia", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(127, 178);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(246, 26);
            this.dtpDate.TabIndex = 4;
            // 
            // FrmAjout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1274, 812);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.zoneSaisie);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "FrmAjout";
            this.Text = "Saisie d\'une visite";
            this.Load += new System.EventHandler(this.FmrSaisieVisite_Load);
            this.Controls.SetChildIndex(this.lblTitre, 0);
            this.Controls.SetChildIndex(this.zoneSaisie, 0);
            this.Controls.SetChildIndex(this.panel4, 0);
            this.zoneSaisie.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisites)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblVisiteur;
        private System.Windows.Forms.Panel zoneSaisie;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvVisites;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cbxPraticien;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxMotif;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDate;
    }
}