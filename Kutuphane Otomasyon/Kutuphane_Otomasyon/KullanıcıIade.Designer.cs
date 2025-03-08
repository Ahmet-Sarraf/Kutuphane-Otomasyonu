namespace Kutuphane_Otomasyon
{
    partial class KullanıcıIade
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KullanıcıIade));
            this.label5 = new System.Windows.Forms.Label();
            this.txtSonTeslim = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtKod = new System.Windows.Forms.TextBox();
            this.txtTc = new System.Windows.Forms.TextBox();
            this.txtAlma = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnIade = new DevExpress.XtraEditors.SimpleButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(59, 457);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "Son Teslim Tarihi:";
            // 
            // txtSonTeslim
            // 
            this.txtSonTeslim.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtSonTeslim.Location = new System.Drawing.Point(198, 457);
            this.txtSonTeslim.Name = "txtSonTeslim";
            this.txtSonTeslim.Size = new System.Drawing.Size(128, 20);
            this.txtSonTeslim.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(59, 411);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Kitabı Alma Tarihi:";
            // 
            // txtKod
            // 
            this.txtKod.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtKod.Location = new System.Drawing.Point(198, 362);
            this.txtKod.MaxLength = 5;
            this.txtKod.Name = "txtKod";
            this.txtKod.Size = new System.Drawing.Size(128, 20);
            this.txtKod.TabIndex = 14;
            // 
            // txtTc
            // 
            this.txtTc.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtTc.Location = new System.Drawing.Point(198, 313);
            this.txtTc.MaxLength = 11;
            this.txtTc.Name = "txtTc";
            this.txtTc.Size = new System.Drawing.Size(128, 20);
            this.txtTc.TabIndex = 13;
            // 
            // txtAlma
            // 
            this.txtAlma.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtAlma.Location = new System.Drawing.Point(198, 411);
            this.txtAlma.Name = "txtAlma";
            this.txtAlma.Size = new System.Drawing.Size(128, 20);
            this.txtAlma.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(102, 360);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Kitap Kodu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(98, 313);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Kullanıcı TC:";
            // 
            // btnIade
            // 
            this.btnIade.Location = new System.Drawing.Point(198, 509);
            this.btnIade.Name = "btnIade";
            this.btnIade.Size = new System.Drawing.Size(128, 41);
            this.btnIade.TabIndex = 18;
            this.btnIade.Text = "Kitabı İade Et";
            this.btnIade.Click += new System.EventHandler(this.btnIade_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(124, 55);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(213, 195);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // KullanıcıIade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(473, 668);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnIade);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSonTeslim);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtKod);
            this.Controls.Add(this.txtTc);
            this.Controls.Add(this.txtAlma);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "KullanıcıIade";
            this.Text = "Kitap İade Etme";
            this.Load += new System.EventHandler(this.KullanıcıIade_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSonTeslim;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtKod;
        private System.Windows.Forms.TextBox txtTc;
        private System.Windows.Forms.TextBox txtAlma;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton btnIade;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}