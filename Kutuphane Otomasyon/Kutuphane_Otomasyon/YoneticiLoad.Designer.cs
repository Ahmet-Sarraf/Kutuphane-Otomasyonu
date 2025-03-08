namespace Kutuphane_Otomasyon
{
    partial class YoneticiLoad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YoneticiLoad));
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.SuspendLayout();
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "navBarGroup1";
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // YoneticiLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1111, 641);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "YoneticiLoad";
            this.Text = "Yönetici Anasayfa";
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
    }
}