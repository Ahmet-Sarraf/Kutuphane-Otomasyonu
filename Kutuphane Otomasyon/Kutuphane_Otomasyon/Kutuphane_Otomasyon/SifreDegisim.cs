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
    public partial class SifreDegisim : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi();
        public string TC;
        public SifreDegisim()
        {
            InitializeComponent();
        }

        private void SifreDegisim_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
        }

        private void simpleButton1_MouseDown(object sender, MouseEventArgs e)
        {
            txtEski.PasswordChar = '\0'; // Şifreyi göster
            txtYeni.PasswordChar = '\0';
            txtYeni2.PasswordChar = '\0';
        }

        // Buton bırakıldığında şifreyi gizle
        private void simpleButton1_MouseUp(object sender, MouseEventArgs e)
        {
            txtEski.PasswordChar = '*'; // Şifreyi tekrar gizle
            txtYeni.PasswordChar = '*';
            txtYeni2.PasswordChar = '*';
        }



        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            string eskiSifre = txtEski.Text; // Eski şifre
            string yeniSifre1 = txtYeni.Text; // Yeni şifre (1. giriş)
            string yeniSifre2 = txtYeni2.Text; // Yeni şifre (2. giriş)

            // Boş alan kontrolü
            if (string.IsNullOrWhiteSpace(eskiSifre) ||
                string.IsNullOrWhiteSpace(yeniSifre1) || string.IsNullOrWhiteSpace(yeniSifre2))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Temizle();
                return;
            }

            // Yeni şifreler aynı mı kontrolü
            if (yeniSifre1 != yeniSifre2)
            {
                MessageBox.Show("Yeni şifreler birbiriyle uyuşmuyor!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Temizle();
                return;
            }

            try  
            {
                // Eski Şifre Kontrolu
                SqlCommand Kontrol = new SqlCommand(" Select KullanıcıSifre from Tbl_Kullanıcı where KullanıcıTc=@t1",bgl.baglantı());
                Kontrol.Parameters.AddWithValue("@t1", TC);

                object sifreObj = Kontrol.ExecuteScalar();
                if (sifreObj == null || sifreObj.ToString() != eskiSifre)
                {
                    MessageBox.Show("Eski şifre hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Temizle();
                    return;
                }

                // Şifre Güncelleme
                SqlCommand Guncelle = new SqlCommand("Update Tbl_Kullanıcı Set KullanıcıSifre = @p1 Where KullanıcıTc=@p2",bgl.baglantı());
                Guncelle.Parameters.AddWithValue("@p1", yeniSifre1);
                Guncelle.Parameters.AddWithValue("@p2", TC);

                int rowsAffected = Guncelle.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Şifre başarıyla değiştirildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Temizle();
                    
                }
                else
                {
                    MessageBox.Show("Şifre değiştirilirken bir hata oluştu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Temizle();
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           


        }
        public void Temizle()
        {
            txtEski.Text = "";
            txtYeni.Text = "";
            txtYeni2.Text = "";
        }
    }
}
