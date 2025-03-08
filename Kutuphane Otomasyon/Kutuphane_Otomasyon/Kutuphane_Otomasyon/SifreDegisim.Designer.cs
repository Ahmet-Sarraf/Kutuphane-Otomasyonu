namespace Kutuphane_Otomasyon
{
    partial class SifreDegisim
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SifreDegisim));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEski = new System.Windows.Forms.TextBox();
            this.txtYeni = new System.Windows.Forms.TextBox();
            this.txtYeni2 = new System.Windows.Forms.TextBox();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnGuncelle = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(128, 124);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(203, 182);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(47, 383);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Eski Şifrenizi Giriniz:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(60, 424);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Yeni Şifreyi Giriniz:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(17, 470);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Yeni Şifreyi Tekrar Giriniz";
            // 
            // txtEski
            // 
            this.txtEski.Location = new System.Drawing.Point(197, 380);
            this.txtEski.MaxLength = 6;
            this.txtEski.Name = "txtEski";
            this.txtEski.PasswordChar = '*';
            this.txtEski.Size = new System.Drawing.Size(134, 20);
            this.txtEski.TabIndex = 1;
            // 
            // txtYeni
            // 
            this.txtYeni.Location = new System.Drawing.Point(197, 421);
            this.txtYeni.MaxLength = 6;
            this.txtYeni.Name = "txtYeni";
            this.txtYeni.PasswordChar = '*';
            this.txtYeni.Size = new System.Drawing.Size(134, 20);
            this.txtYeni.TabIndex = 2;
            // 
            // txtYeni2
            // 
            this.txtYeni2.Location = new System.Drawing.Point(197, 467);
            this.txtYeni2.MaxLength = 6;
            this.txtYeni2.Name = "txtYeni2";
            this.txtYeni2.PasswordChar = '*';
            this.txtYeni2.Size = new System.Drawing.Size(134, 20);
            this.txtYeni2.TabIndex = 3;
            // 
            // simpleButton1
            // 
            this.simpleButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("simpleButton1.BackgroundImage")));
            this.simpleButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(394, 456);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(37, 31);
            this.simpleButton1.TabIndex = 7;
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            this.simpleButton1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.simpleButton1_MouseDown);
            this.simpleButton1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.simpleButton1_MouseUp);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Location = new System.Drawing.Point(213, 526);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(92, 35);
            this.btnGuncelle.TabIndex = 4;
            this.btnGuncelle.Text = "Şifreyi Değiştir";
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // SifreDegisim
            // 
            this.AcceptButton = this.btnGuncelle;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(478, 700);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.txtYeni2);
            this.Controls.Add(this.txtYeni);
            this.Controls.Add(this.txtEski);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SifreDegisim";
            this.Text = "Şifre Değiştirme";
            this.Load += new System.EventHandler(this.SifreDegisim_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEski;
        private System.Windows.Forms.TextBox txtYeni;
        private System.Windows.Forms.TextBox txtYeni2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton btnGuncelle;
    }
}