using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Kutuphane_Otomasyon
{
    public partial class Kullanıcı_Islemleri : Form
    {
        public Kullanıcı_Islemleri()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        private void Kullanıcı_Islemleri_Load(object sender, EventArgs e)
        {
            Listele();
        }

        
        // Kullanıcı Ekleme Butonu
        private void btnEkle_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(mskTc.Text) || // Boş Alan Geçilmesini Engeller
                string.IsNullOrWhiteSpace(txtIsım.Text) ||
                string.IsNullOrWhiteSpace(txtSoyısım.Text) ||
                string.IsNullOrWhiteSpace(txtsifre.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            try
            {
                using (SqlConnection connection = bgl.baglantı())
                {
                    // Bu Komut Hem Yönetici Hem de Kullanıcı Tablosunundaki TC Bilgilerini Kontrol Eder
                    SqlCommand kontrolKomut = new SqlCommand(@"
                            SELECT COUNT(*)
                            FROM (
                                SELECT KullanıcıTc AS Tc FROM Tbl_Kullanıcı
                                UNION ALL
                                SELECT YoneticiTc AS Tc FROM Tbl_Yonetici
                            ) AS TcListesi
                            WHERE Tc = @p1", connection);

                    kontrolKomut.Parameters.AddWithValue("@p1", mskTc.Text);

                    
                    int kayitSayisi = (int)kontrolKomut.ExecuteScalar(); // Aynı TC Bulunma Miktarı

                    if (kayitSayisi > 0) // Aynı TC'den Başka Bİrisi Varsa
                    {
                        MessageBox.Show("Bu TC Numarasına Ait Başka Bir Kullanıcı veya Yönetici Bulunmaktadır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    SqlCommand komut = new SqlCommand(
                        "INSERT INTO Tbl_Kullanıcı (KullanıcıTc, KullanıcıAd, KullanıcıSoyad, KullanıcıSifre) VALUES (@p1, @p2, @p3, @p4)",
                        connection);
                    komut.Parameters.AddWithValue("@p1", mskTc.Text);
                    komut.Parameters.AddWithValue("@p2", txtIsım.Text);
                    komut.Parameters.AddWithValue("@p3", txtSoyısım.Text);
                    komut.Parameters.AddWithValue("@p4", txtsifre.Text);

                    komut.ExecuteNonQuery();
                }

                MessageBox.Show("Kullanıcı başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Kullanıcı TC Girilmek Zorunludur."+ex, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        // Kullanıcı Ekleme kısmının Temizleme Butonu
        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        // Kullanıcı Silme Butonu
        private void BtnSil_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(mskTc2.Text))
            {
                MessageBox.Show("Lütfen bir TC numarası giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult Onay = MessageBox.Show($"{mskTc2.Text} TC'li Kullanıcıyı Kalıcı Olarak Silmek İstiyor Musunuz!", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Onay == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("Delete from Tbl_Kullanıcı where KullanıcıTc=@p1", bgl.baglantı());
                komut.Parameters.AddWithValue("@p1", mskTc2.Text);
                komut.ExecuteNonQuery();
                bgl.baglantı().Close();
                Listele();
                Temizle2();
            }
        }

        // Kullanıcı Silme Bölümünün Getir Butonu
        private void btnGetir_Click_1(object sender, EventArgs e)
        {
            mskTc2.Text = gridView1.GetFocusedRowCellValue("KullanıcıTc").ToString();
            txtIsım2.Text = gridView1.GetFocusedRowCellValue("KullanıcıAd").ToString();
            txtSoyısım2.Text = gridView1.GetFocusedRowCellValue("KullanıcıSoyad").ToString();
            txtsifre2.Text = gridView1.GetFocusedRowCellValue("KullanıcıSifre").ToString();
            
        }

        // Kullanıcı Silme bölümünün temizle Butonu
        private void BtnTemizle2_Click(object sender, EventArgs e)
        {
            Temizle2();
        }

        //Güncelleme Butonu
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand Komut = new SqlCommand("Update Tbl_Kullanıcı Set KullanıcıAd=@p2,KullanıcıSoyad=@p3,KullanıcıSifre=@p4 Where KullanıcıTc=@p1", bgl.baglantı());
            Komut.Parameters.AddWithValue("@p1", mskTc3.Text);
            Komut.Parameters.AddWithValue("@p2", txtIsım3.Text);
            Komut.Parameters.AddWithValue("@p3", txtSoyısım3.Text);
            Komut.Parameters.AddWithValue("@p4", txtsifre3.Text);
           
            Komut.ExecuteNonQuery();
            bgl.baglantı().Close();
            Listele();
            Temizle3();
        }

        //Kullanıcı Güncelleme Kısmının Bilgileri Getir Butonu
        private void btnGetir2_Click(object sender, EventArgs e)
        {
            mskTc3.Text = gridView1.GetFocusedRowCellValue("KullanıcıTc").ToString();
            txtIsım3.Text = gridView1.GetFocusedRowCellValue("KullanıcıAd").ToString();
            txtSoyısım3.Text = gridView1.GetFocusedRowCellValue("KullanıcıSoyad").ToString();
            txtsifre3.Text = gridView1.GetFocusedRowCellValue("KullanıcıSifre").ToString();
        }

        // Kullanıcı Güncelleme Kısmının Temizle Butonu
        private void simpleButton6_Click(object sender, EventArgs e)
        {
            Temizle3();
        }



        public void Temizle() // Ekleme Araçlarını Temizleme
        {
            mskTc.Text = "";
            txtIsım.Text = "";
            txtSoyısım.Text = "";
            txtsifre.Text = "";
            
        }
        public void Temizle2() // Silme Araçlarını Temizleme
        {
            mskTc2.Text = "";
            txtIsım2.Text = "";
            txtSoyısım2.Text = "";
            txtsifre2.Text = "";

        }
        public void Temizle3() // Güncelleme Araçlarını Temizleme
        {
            mskTc3.Text = "";
            txtIsım3.Text = "";
            txtSoyısım3.Text = "";
            txtsifre3.Text = "";

        }

        public void Listele() // Tüm Kullanıcıları Listeler
        {
            string Komut = "Select * from Tbl_Kullanıcı";
            SqlDataAdapter da = new SqlDataAdapter(Komut, bgl.baglantı());
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];

        }

        // Tıklanan Butona Göre Açılacak Olan Sayfa
        public void SetTabPage(int tabIndex)
        {
            switch (tabIndex)
            {
                case 1:
                    tabControl.SelectedIndex = 0; // Ekleme işlemi için 1. tab seçilir
                    break;
                case 2:
                    tabControl.SelectedIndex = 1; // Silme işlemi için 2. tab seçilir
                    break;
                case 3:
                    tabControl.SelectedIndex = 2; // Güncelleme işlemi için 3. tab seçilir
                    break;
            }
        }


    }
}
