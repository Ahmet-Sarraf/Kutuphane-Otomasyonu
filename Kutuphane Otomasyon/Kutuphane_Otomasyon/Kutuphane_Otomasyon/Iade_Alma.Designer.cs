namespace Kutuphane_Otomasyon
{
    partial class Iade_Alma
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEngelle = new DevExpress.XtraEditors.SimpleButton();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSonTeslim = new System.Windows.Forms.TextBox();
            this.btnIade = new DevExpress.XtraEditors.SimpleButton();
            this.btnGetir = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txtKod = new System.Windows.Forms.TextBox();
            this.txtTc = new System.Windows.Forms.TextBox();
            this.txtAlma = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1154, 772);
            this.splitContainer1.SplitterDistance = 300;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.textBox1);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnEngelle);
            this.splitContainer2.Panel2.Controls.Add(this.label5);
            this.splitContainer2.Panel2.Controls.Add(this.txtSonTeslim);
            this.splitContainer2.Panel2.Controls.Add(this.btnIade);
            this.splitContainer2.Panel2.Controls.Add(this.btnGetir);
            this.splitContainer2.Panel2.Controls.Add(this.label4);
            this.splitContainer2.Panel2.Controls.Add(this.txtKod);
            this.splitContainer2.Panel2.Controls.Add(this.txtTc);
            this.splitContainer2.Panel2.Controls.Add(this.txtAlma);
            this.splitContainer2.Panel2.Controls.Add(this.label3);
            this.splitContainer2.Panel2.Controls.Add(this.label2);
            this.splitContainer2.Size = new System.Drawing.Size(1154, 300);
            this.splitContainer2.SplitterDistance = 500;
            this.splitContainer2.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(71, 114);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(175, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(67, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(316, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "İade Alacağınız Kişinin TC\'sini Giriniz";
            // 
            // btnEngelle
            // 
            this.btnEngelle.Location = new System.Drawing.Point(504, 243);
            this.btnEngelle.Name = "btnEngelle";
            this.btnEngelle.Size = new System.Drawing.Size(101, 39);
            this.btnEngelle.TabIndex = 10;
            this.btnEngelle.Text = "Kullanıcı Engelle";
            this.btnEngelle.Click += new System.EventHandler(this.btnEngelle_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(154, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Son Teslim Tarihi:";
            // 
            // txtSonTeslim
            // 
            this.txtSonTeslim.Location = new System.Drawing.Point(293, 191);
            this.txtSonTeslim.Name = "txtSonTeslim";
            this.txtSonTeslim.Size = new System.Drawing.Size(128, 20);
            this.txtSonTeslim.TabIndex = 8;
            // 
            // btnIade
            // 
            this.btnIade.Location = new System.Drawing.Point(338, 243);
            this.btnIade.Name = "btnIade";
            this.btnIade.Size = new System.Drawing.Size(101, 39);
            this.btnIade.TabIndex = 7;
            this.btnIade.Text = "İade Al";
            this.btnIade.Click += new System.EventHandler(this.btnIade_Click);
            // 
            // btnGetir
            // 
            this.btnGetir.Location = new System.Drawing.Point(231, 243);
            this.btnGetir.Name = "btnGetir";
            this.btnGetir.Size = new System.Drawing.Size(101, 39);
            this.btnGetir.TabIndex = 6;
            this.btnGetir.Text = "Bilgileri Getir";
            this.btnGetir.Click += new System.EventHandler(this.btnGetir_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(154, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Kitabı Alma Tarihi:";
            // 
            // txtKod
            // 
            this.txtKod.Location = new System.Drawing.Point(293, 96);
            this.txtKod.MaxLength = 5;
            this.txtKod.Name = "txtKod";
            this.txtKod.Size = new System.Drawing.Size(128, 20);
            this.txtKod.TabIndex = 4;
            // 
            // txtTc
            // 
            this.txtTc.Location = new System.Drawing.Point(293, 47);
            this.txtTc.MaxLength = 11;
            this.txtTc.Name = "txtTc";
            this.txtTc.Size = new System.Drawing.Size(128, 20);
            this.txtTc.TabIndex = 3;
            // 
            // txtAlma
            // 
            this.txtAlma.Location = new System.Drawing.Point(293, 145);
            this.txtAlma.Name = "txtAlma";
            this.txtAlma.Size = new System.Drawing.Size(128, 20);
            this.txtAlma.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(197, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Kitap Kodu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(193, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Kullanıcı TC:";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1154, 468);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // Iade_Alma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 772);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Iade_Alma";
            this.Text = "Iade_Alma";
            this.Load += new System.EventHandler(this.Iade_Alma_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnIade;
        private DevExpress.XtraEditors.SimpleButton btnGetir;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtKod;
        private System.Windows.Forms.TextBox txtTc;
        private System.Windows.Forms.TextBox txtAlma;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSonTeslim;
        private DevExpress.XtraEditors.SimpleButton btnEngelle;
    }
}