namespace GSB
{
    partial class FrmConnexion
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConnexion));
            this.lbl_mdp = new System.Windows.Forms.Label();
            this.lblNom = new System.Windows.Forms.Label();
            this.txtMdp = new System.Windows.Forms.TextBox();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.btnQuitter = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.imgGsb = new System.Windows.Forms.PictureBox();
            this.messageNom = new System.Windows.Forms.Label();
            this.messageMdp = new System.Windows.Forms.Label();
            this.btnConnecter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imgGsb)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_mdp
            // 
            this.lbl_mdp.AutoSize = true;
            this.lbl_mdp.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_mdp.Location = new System.Drawing.Point(298, 149);
            this.lbl_mdp.Name = "lbl_mdp";
            this.lbl_mdp.Size = new System.Drawing.Size(105, 18);
            this.lbl_mdp.TabIndex = 9;
            this.lbl_mdp.Text = "Mot de passe ";
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNom.Location = new System.Drawing.Point(298, 41);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(42, 18);
            this.lblNom.TabIndex = 8;
            this.lblNom.Text = "Nom";
            // 
            // txtMdp
            // 
            this.txtMdp.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMdp.Location = new System.Drawing.Point(298, 171);
            this.txtMdp.Name = "txtMdp";
            this.txtMdp.Size = new System.Drawing.Size(164, 26);
            this.txtMdp.TabIndex = 7;
            this.txtMdp.UseSystemPasswordChar = true;
            // 
            // txtNom
            // 
            this.txtNom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtNom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtNom.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNom.Location = new System.Drawing.Point(296, 65);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(164, 26);
            this.txtNom.TabIndex = 6;
            // 
            // btnQuitter
            // 
            this.btnQuitter.AutoSize = true;
            this.btnQuitter.BackColor = System.Drawing.Color.DarkRed;
            this.btnQuitter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnQuitter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnQuitter.Font = new System.Drawing.Font("Georgia", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitter.ForeColor = System.Drawing.Color.White;
            this.btnQuitter.Location = new System.Drawing.Point(0, 318);
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.Size = new System.Drawing.Size(586, 50);
            this.btnQuitter.TabIndex = 5;
            this.btnQuitter.Text = "Quitter l\'application";
            this.btnQuitter.UseVisualStyleBackColor = false;
            this.btnQuitter.Click += new System.EventHandler(this.btnQuitter_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(586, 34);
            this.label1.TabIndex = 10;
            this.label1.Text = "Accès visiteur";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imgGsb
            // 
            this.imgGsb.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("imgGsb.BackgroundImage")));
            this.imgGsb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgGsb.Location = new System.Drawing.Point(15, 41);
            this.imgGsb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.imgGsb.Name = "imgGsb";
            this.imgGsb.Size = new System.Drawing.Size(255, 179);
            this.imgGsb.TabIndex = 11;
            this.imgGsb.TabStop = false;
            // 
            // messageNom
            // 
            this.messageNom.AutoSize = true;
            this.messageNom.Font = new System.Drawing.Font("Georgia", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageNom.ForeColor = System.Drawing.Color.Red;
            this.messageNom.Location = new System.Drawing.Point(298, 93);
            this.messageNom.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.messageNom.Name = "messageNom";
            this.messageNom.Size = new System.Drawing.Size(39, 17);
            this.messageNom.TabIndex = 15;
            this.messageNom.Text = "msg";
            this.messageNom.Visible = false;
            // 
            // messageMdp
            // 
            this.messageMdp.AutoSize = true;
            this.messageMdp.Font = new System.Drawing.Font("Georgia", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageMdp.ForeColor = System.Drawing.Color.Red;
            this.messageMdp.Location = new System.Drawing.Point(298, 199);
            this.messageMdp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.messageMdp.Name = "messageMdp";
            this.messageMdp.Size = new System.Drawing.Size(39, 17);
            this.messageMdp.TabIndex = 16;
            this.messageMdp.Text = "msg";
            this.messageMdp.Visible = false;
            // 
            // btnConnecter
            // 
            this.btnConnecter.AutoSize = true;
            this.btnConnecter.BackColor = System.Drawing.Color.SlateGray;
            this.btnConnecter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConnecter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnConnecter.Font = new System.Drawing.Font("Georgia", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnecter.ForeColor = System.Drawing.Color.White;
            this.btnConnecter.Location = new System.Drawing.Point(0, 268);
            this.btnConnecter.Name = "btnConnecter";
            this.btnConnecter.Size = new System.Drawing.Size(586, 50);
            this.btnConnecter.TabIndex = 17;
            this.btnConnecter.Text = "Se connecter";
            this.btnConnecter.UseVisualStyleBackColor = false;
            this.btnConnecter.Click += new System.EventHandler(this.btnConnecter_Click);
            // 
            // FrmConnexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(586, 368);
            this.Controls.Add(this.btnConnecter);
            this.Controls.Add(this.messageMdp);
            this.Controls.Add(this.messageNom);
            this.Controls.Add(this.imgGsb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_mdp);
            this.Controls.Add(this.lblNom);
            this.Controls.Add(this.txtMdp);
            this.Controls.Add(this.txtNom);
            this.Controls.Add(this.btnQuitter);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmConnexion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Laboratoire pharmaceutique Galaxy-Swiss Bourdin - Gestion des visites";
            this.Load += new System.EventHandler(this.FrmConnexion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgGsb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_mdp;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.TextBox txtMdp;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.Button btnQuitter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox imgGsb;
        private System.Windows.Forms.Label messageNom;
        private System.Windows.Forms.Label messageMdp;
        private System.Windows.Forms.Button btnConnecter;
    }
}

