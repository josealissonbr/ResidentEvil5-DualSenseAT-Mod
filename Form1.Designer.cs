namespace ETS2_DualSenseAT_Mod
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.statusLbl = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ammoLbl = new System.Windows.Forms.Label();
            this.everytick = new System.Windows.Forms.Timer(this.components);
            this.iAmmoTracker = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusLbl
            // 
            this.statusLbl.AutoSize = true;
            this.statusLbl.Location = new System.Drawing.Point(12, 165);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(89, 13);
            this.statusLbl.TabIndex = 0;
            this.statusLbl.Text = "Status: Unknown";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ResidentEvil5.Properties.Resources.re5_header;
            this.pictureBox1.Location = new System.Drawing.Point(15, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(299, 147);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // ammoLbl
            // 
            this.ammoLbl.AutoSize = true;
            this.ammoLbl.Location = new System.Drawing.Point(137, 165);
            this.ammoLbl.Name = "ammoLbl";
            this.ammoLbl.Size = new System.Drawing.Size(52, 13);
            this.ammoLbl.TabIndex = 2;
            this.ammoLbl.Text = "Starting...";
            // 
            // everytick
            // 
            this.everytick.Interval = 250;
            this.everytick.Tick += new System.EventHandler(this.everytick_Tick);
            // 
            // iAmmoTracker
            // 
            this.iAmmoTracker.AutoSize = true;
            this.iAmmoTracker.Checked = true;
            this.iAmmoTracker.CheckState = System.Windows.Forms.CheckState.Checked;
            this.iAmmoTracker.Location = new System.Drawing.Point(6, 19);
            this.iAmmoTracker.Name = "iAmmoTracker";
            this.iAmmoTracker.Size = new System.Drawing.Size(86, 17);
            this.iAmmoTracker.TabIndex = 3;
            this.iAmmoTracker.Text = "Ammo Track";
            this.iAmmoTracker.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.iAmmoTracker);
            this.groupBox1.Location = new System.Drawing.Point(15, 194);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(299, 115);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DualSense Adaptive Triggers Settings";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 321);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ammoLbl);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.statusLbl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(342, 223);
            this.Name = "Form1";
            this.Text = "Resident Evil 5 | DualSense AT";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label statusLbl;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label ammoLbl;
        private System.Windows.Forms.Timer everytick;
        private System.Windows.Forms.CheckBox iAmmoTracker;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

