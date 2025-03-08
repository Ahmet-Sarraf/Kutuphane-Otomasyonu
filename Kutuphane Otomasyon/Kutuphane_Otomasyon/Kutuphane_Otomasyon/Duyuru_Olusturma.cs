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
    public partial class Duyuru_Olusturma : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi(); // SQL Adresi
        DateTime bugun = DateTime.Now; // Bugünün Tarihini Tutar

        public Duyuru_Olusturma()
        {
            InitializeComponent();
        }

        private void Duyuru_Olusturma_Load(object sender, EventArgs e)
        {

        }

        private void btnOlustur_Click(object sender, EventArgs e) // Duyuru Oluşturmayı sağlar
        {
            // Duyuru Başlığı yada Duyuru Kısmının Boş Olma Durumunu Kontrol Eder
            if (string.IsNullOrWhiteSpace(txtBaslık.Text) || string.IsNullOrWhiteSpace(rchDuyuru.Text))
            {
                MessageBox.Show("Başlık ve Duyuru Girilmeden Duyuru Oluşturalamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Duyuruyu Oluşturmak İçin Onay İsteme 
            DialogResult Onay = MessageBox.Show($"{txtBaslık.Text} Başlıklı Duyuruyu Oluşturmak İstediğinize Emin Misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Onay == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("Insert into Tbl_Duyuru (Duyurunun_Konusu,Duyuru,Gönderme_Tarihi) values (@p1,@p2,@p3)", bgl.baglantı());
                komut.Parameters.AddWithValue("@p1", txtBaslık.Text);
                komut.Parameters.AddWithValue("@p2", rchDuyuru.Text);
                komut.Parameters.AddWithValue("@p3", bugun.ToString("yyyy-MM-dd"));

                komut.ExecuteNonQuery();
                bgl.baglantı().Close();
                MessageBox.Show("Duyuru Oluşturuldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Temizle(); // Duyuruyu Oluşturduktan Sonra Araçları Temizler 
            }
        }

        public void Temizle() // Araçları Temizler 
        {
            txtBaslık.Text = "";
            rchDuyuru.Text = "";
        }

        private void btnTemizle_Click(object sender, EventArgs e) // Temizleme Butonu
        {
            Temizle();
        }
    }
}
