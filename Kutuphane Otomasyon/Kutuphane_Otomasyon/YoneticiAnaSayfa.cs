using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace Kutuphane_Otomasyon
{
    public partial class YoneticiAnaSayfa : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public YoneticiAnaSayfa()
        {
            InitializeComponent();
        }

        private void YoneticiAnaSayfa_Load(object sender, EventArgs e) // Yönetici Load Formunu Açar
        {
            YoneticiLoad yl = new YoneticiLoad();
            yl.MdiParent = this;
            yl.Show();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e) // Kitap İşlemleri Formunu ve Settab1'i Açar
        {
            Kitap_Islemleri frm = new Kitap_Islemleri();
            frm.MdiParent = this;
            frm.Show();
            frm.SetTabPage(1);
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)// Kitap İşlemleri Formunu ve Settab2'yi Açar
        {
            Kitap_Islemleri frm = new Kitap_Islemleri();
            frm.MdiParent = this;
            frm.Show();
            frm.SetTabPage(2);
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)// Kitap İşlemleri Formunu ve Settab3'ü Açar
        {
            Kitap_Islemleri frm = new Kitap_Islemleri();
            frm.MdiParent = this;
            frm.Show();
            frm.SetTabPage(3);
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e) // Bütün Kitaplar Formunu Açar
        {
            Butun_Kitaplarr frm = new Butun_Kitaplarr();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e) // Bütün Kullanıcılar Formunu Açar
        {
            ButunKullanıcılar frm = new ButunKullanıcılar();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e) // Kullanıcı İşlemleri Formunu ve Settab1'i Açar
        {
            Kullanıcı_Islemleri frm = new Kullanıcı_Islemleri();
            frm.MdiParent = this;
            frm.Show();
            frm.SetTabPage(1);
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)// Kullanıcı İşlemleri Formunu ve Settab2'yi Açar
        {
            Kullanıcı_Islemleri frm = new Kullanıcı_Islemleri();
            frm.MdiParent = this;
            frm.Show();
            frm.SetTabPage(2);
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)// Kullanıcı İşlemleri Formunu ve Settab3'ü Açar
        {
            Kullanıcı_Islemleri frm = new Kullanıcı_Islemleri();
            frm.MdiParent = this;
            frm.Show();
            frm.SetTabPage(3);
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)// Ödünç Verme Formunu Açar
        {
            Odunc_Verme frm = new Odunc_Verme();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)// IAde Alma Formunu Açar
        {
            Iade_Alma frm = new Iade_Alma();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem14_ItemClick(object sender, ItemClickEventArgs e) // Diğer Bilgiler Formunu Açar
        {
            DiğerBilgiler frm = new DiğerBilgiler();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem12_ItemClick(object sender, ItemClickEventArgs e) // Duyuru Oluşturma Formunu Açar
        {
            Duyuru_Olusturma frm = new Duyuru_Olusturma();
            frm.Show(); }

        private void barButtonItem15_ItemClick(object sender, ItemClickEventArgs e) //Bütün Duyurular Formunu Açar
        {
            Butun_Duyurular frm = new Butun_Duyurular();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem16_ItemClick(object sender, ItemClickEventArgs e) //Mesaj Gönderme Formunu Açar
        {
            MesajGonderme frm = new MesajGonderme();
            frm.MdiParent = this;
            frm.Show();

        }

        private void barButtonItem17_ItemClick(object sender, ItemClickEventArgs e)// Bütün Mesajlar Formunu Açar
        {
            Butun_Mesajlar frm = new Butun_Mesajlar();
            frm.MdiParent = this;
            frm.Show();
        }

        private void YoneticiAnaSayfa_FormClosing(object sender, FormClosingEventArgs e) // Formu Kapattığında Uygulamayı Kapatır
        {
            
                Application.Exit();
            
        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }
    }
}

