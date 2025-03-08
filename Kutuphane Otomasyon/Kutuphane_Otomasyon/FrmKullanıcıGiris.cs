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
    public partial class FrmKullanıcıGiris : Form
    {
        

        public FrmKullanıcıGiris()
        {
            InitializeComponent();
            
        }

        sqlbaglantisi bgl = new sqlbaglantisi(); // SQL Adresi

       

        private void FrmKullanıcıGiris_Load(object sender, EventArgs e)
        {

        }


        private void BtnGiris_Click(object sender, EventArgs e) // Giriş Yapmayı Sağlar
        {
            SqlCommand komut1 = new SqlCommand("Select * From Tbl_Kullanıcı where KullanıcıTc=@p1 and KullanıcıSifre=@p2", bgl.baglantı());
            komut1.Parameters.AddWithValue("@p1", mskTc.Text);
            komut1.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = komut1.ExecuteReader();
            if (dr.Read()) // Girilen Değerlerin Doğruluk Durumunu Kontrol Eder
            {
                // Kullanıcının Kredi Durumunu Kontrol Eder
                int kredi = Convert.ToInt32(dr["KullanıcıKredi"]);
                if (kredi == 0)
                {
                    MessageBox.Show("Krediniz sıfır olduğu için sisteme ulaşamıyorsunuz, lütfen yöneticiye başvurun.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Giriş Yapılıyor", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    KullanıcıAnaSayfa frm = new KullanıcıAnaSayfa();
                    frm.TC = mskTc.Text;
                    frm.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Hatalı Tc veya Şifre", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            bgl.baglantı().Close();
        }

        private void BtnGerii_Click(object sender, EventArgs e) // Seçim Paneline Götürür
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Bir Yetkiliye Danışınız ve Kimlik Numarası ile Kayıt Yaptırabilirsiniz","Kayıt Olma",MessageBoxButtons.OK);
        }
    }
}
