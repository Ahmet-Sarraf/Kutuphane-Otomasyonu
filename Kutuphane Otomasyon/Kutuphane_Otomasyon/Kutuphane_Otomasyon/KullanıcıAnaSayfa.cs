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
using System.Data.SqlClient;

namespace Kutuphane_Otomasyon
{
    public partial class KullanıcıAnaSayfa : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        sqlbaglantisi bgl = new sqlbaglantisi(); //SQL Adresi
        public string TC; // Kullanıcı TC si



        public KullanıcıAnaSayfa()
        {
            InitializeComponent();
        }

        private void KullanıcıAnaSayfa_Load(object sender, EventArgs e)
        {
            KullanıcıLoad frm = new KullanıcıLoad();
            frm.TC = TC;
            frm.MdiParent = this;
            frm.Show();
            
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e) // Bütün Kitaplar Formunu Açar
        {
            Butun_Kitaplarr frm = new Butun_Kitaplarr();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e) //Kullanıcının Alabileceği Kitaplar Formunu Açar
        {
            Alınabilir_Kitaplar frm = new Alınabilir_Kitaplar();
            frm.TC = TC;
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e) // Kitap Ödünç Alma Formunu Açar
        {
            OduncAlma frm = new OduncAlma();
            frm.TC = TC;
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)// İade Alma Formunu Açar
        {
            // Kitap Kodu getirme
            try
            {
                // Kullanıcının İade Edeceği Kitabını Kontrol Eder
                SqlCommand getir = new SqlCommand("Select Kitap_Kodu from Tbl_OduncIslemleri Where Teslim_Edilme_Durumu=0 and KullanıcıTc=@p1", bgl.baglantı());
                getir.Parameters.AddWithValue("@p1", TC);

                SqlDataReader dr = getir.ExecuteReader();
                if (dr.Read()) // İade Edebileceği Kitap Varsa
                {

                    KullanıcıIade frm = new KullanıcıIade(); // İade Etme Formunu Açar
                    frm.TC = TC;

                    frm.Show();
                }
                else
                {
                    MessageBox.Show("İade Edecek Kitabınız Bulunmamakta", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    return;
                }
            }
            catch
            {
                MessageBox.Show("Hata");
            }
            

        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e) // Yeni Gelenler formunu Açar 
        {
            YeniGelenler frm = new YeniGelenler();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e) // Ödünç Geçmişi Formunu Açar
        {
            OduncGecmisi frm = new OduncGecmisi();
            frm.TC = TC;
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e) // Gelen Mesajlar Formunu Açar
        {
            GelenMesajlar frm = new GelenMesajlar();
            frm.TC = TC;
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e) // Şifre Değiştirme Formunu Açar
        {
            SifreDegisim frm = new SifreDegisim();
            frm.TC = TC;
            frm.Show();
        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }

        private void KullanıcıAnaSayfa_FormClosing(object sender, FormClosingEventArgs e) // Formu Kapattığında Uygulamayı Kapatır 
        {
           
            
                Application.Exit();
            
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e) // Kullanım Klavuzu Formunu Açar
        {
            Kullanım_Klavuzu frm = new Kullanım_Klavuzu();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e) // Duyuru Formunu Açar
        {
            Duyuru frm = new Duyuru();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem11_ItemClick(object sender, ItemClickEventArgs e) // Kullanıcı Load Formunu Açar
        {
            KullanıcıLoad frm = new KullanıcıLoad();
            frm.TC = TC;
            frm.MdiParent = this;
            frm.Show();
        }
    }
}