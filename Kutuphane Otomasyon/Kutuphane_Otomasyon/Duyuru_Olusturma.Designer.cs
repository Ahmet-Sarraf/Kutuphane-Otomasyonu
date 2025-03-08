namespace Kutuphane_Otomasyon
{
    partial class Duyuru_Olusturma
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Duyuru_Olusturma));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBaslık = new System.Windows.Forms.TextBox();
            this.rchDuyuru = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOlustur = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnTemizle = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(52, 263);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(439, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Oluşturmak İstediğiniz Duyurunun Başlığını ve İçeriğini Giriniz.\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(53, 325);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Duyuru Başlığı:";
            // 
            // txtBaslık
            // 
            this.txtBaslık.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtBaslık.Location = new System.Drawing.Point(187, 326);
            this.txtBaslık.Name = "txtBaslık";
            this.txtBaslık.Size = new System.Drawing.Size(289, 20);
            this.txtBaslık.TabIndex = 1;
            // 
            // rchDuyuru
            // 
            this.rchDuyuru.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.rchDuyuru.Location = new System.Drawing.Point(187, 369);
            this.rchDuyuru.Name = "rchDuyuru";
            this.rchDuyuru.Size = new System.Drawing.Size(289, 218);
            this.rchDuyuru.TabIndex = 2;
            this.rchDuyuru.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(53, 368);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Duyuru:";
            // 
            // btnOlustur
            // 
            this.btnOlustur.Location = new System.Drawing.Point(362, 608);
            this.btnOlustur.Name = "btnOlustur";
            this.btnOlustur.Size = new System.Drawing.Size(114, 43);
            this.btnOlustur.TabIndex = 3;
            this.btnOlustur.Text = "Duyuruyu Oluştur";
            this.btnOlustur.Click += new System.EventHandler(this.btnOlustur_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(52, 723);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(425, 40);
            this.label4.TabIndex = 6;
            this.label4.Text = "Not:Oluşturacağınız Duyuruyu Bütün Kullanıcılar Görecektir.\r\n\r\n";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(168, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(229, 190);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // btnTemizle
            // 
            this.btnTemizle.Location = new System.Drawing.Point(229, 608);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(114, 43);
            this.btnTemizle.TabIndex = 4;
            this.btnTemizle.Text = "Temizle";
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // Duyuru_Olusturma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(541, 793);
            this.Controls.Add(this.btnTemizle);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnOlustur);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rchDuyuru);
            this.Controls.Add(this.txtBaslık);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Duyuru_Olusturma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Duyuru Oluşturma Sayfası";
            this.Load += new System.EventHandler(this.Duyuru_Olusturma_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBaslık;
        private System.Windows.Forms.RichTextBox rchDuyuru;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton btnOlustur;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraEditors.SimpleButton btnTemizle;
    }
}