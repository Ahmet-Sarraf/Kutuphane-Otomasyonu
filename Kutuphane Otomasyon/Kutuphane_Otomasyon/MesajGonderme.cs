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
    public partial class MesajGonderme : Form
    {
        DateTime bugun = DateTime.Now; // Bugünün Tarihini Tutar
        sqlbaglantisi bgl = new sqlbaglantisi(); // SQL Adresi
        public MesajGonderme()
        {
            InitializeComponent();
            
            

        }

        private void MesajGonderme_Load(object sender, EventArgs e)
        {
            textBox1.TextChanged += new EventHandler(textBox1_TextChanged);
           
            Filtrele1(textBox1.Text);
            Listele();


        }

       

        public void Listele() // Kullanıcılar Tablosunu Listeler
        {
            string komut = "SELECT * FROM Tbl_Kullanıcı";
            SqlDataAdapter da = new SqlDataAdapter(komut, bgl.baglantı());
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
        }

        public void Filtrele1(string arama) // Kullanıcıları Girilen İsme Göre Listeler
        {
            try
            {
                string Komut = "SELECT * FROM Tbl_Kullanıcı WHERE KullanıcıAd Like @p1";
                SqlDataAdapter da = new SqlDataAdapter(Komut, bgl.baglantı());
                da.SelectCommand.Parameters.AddWithValue("@p1", arama + "%"); // Başlayan kelimeler için filtre
                
                DataSet ds = new DataSet();
                da.Fill(ds);
                gridControl1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Filtrele1(textBox1.Text);
        }

        

        private void btnSec_Click(object sender, EventArgs e)
        {
            txtTc.Text = gridView1.GetFocusedRowCellValue("KullanıcıTc").ToString();
        }

        private void BtnTEmizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
        public void Temizle()
        {
            txtTc.Text = "";
            txtKonu.Text = "";
            richTextBox1.Text = "";
        }

        private void btnGonder_Click(object sender, EventArgs e) // Mesaj Gönderme Butonu
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTc.Text)) // TC'nin Boş Olma Durumu 
                {
                    MessageBox.Show("Lütfen bir TC numarası giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtKonu.Text) || string.IsNullOrWhiteSpace(richTextBox1.Text)) // Mesaj Konusu ve Mesajın Boş Olma Durumunu Kontrol Etme
                {
                    MessageBox.Show("Mesaj Konusu ve Mesaj Girilmeden Mesaj Gönderilemez!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Mesaj Göndermeyi Onaylar
                DialogResult Onay = MessageBox.Show($"{txtTc.Text} Kimlik Numaralı Kişiye" +
                    $"{txtKonu.Text} konulu Mesajı Göndermek İstediğinize Emin misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (Onay == DialogResult.Yes)
                {
                    SqlCommand komut = new SqlCommand("insert into Tbl_Mesaj (KullanıcıTc,Mesaj_Konusu,Mesaj,Gonderme_Tarihi) values (@p1,@p2,@p3,@p4)", bgl.baglantı());
                    komut.Parameters.AddWithValue("@p1", txtTc.Text);
                    komut.Parameters.AddWithValue("@p2", txtKonu.Text);
                    komut.Parameters.AddWithValue("@p3", richTextBox1.Text);
                    komut.Parameters.AddWithValue("@p4", bugun.ToString("yyyy-MM-dd"));
                    komut.ExecuteNonQuery();
                    bgl.baglantı().Close();
                    MessageBox.Show("Mesaj Gönderildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Temizle();
                }
            }
            catch
            {
                 MessageBox.Show("Mesaj Gönderilemedi", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 return;
            }
        }
    }
}
