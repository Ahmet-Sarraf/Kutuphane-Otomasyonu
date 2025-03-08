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
    public partial class FrmYoneticiGiris : Form
    {
        public FrmYoneticiGiris()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi(); // SQL Adresi


        private void FrmYoneticiGiris_Load(object sender, EventArgs e)
        {

        }

        private void BtnGiris_Click(object sender, EventArgs e) // Giriş Yapmayı Sağlar
        {
            SqlCommand komut = new SqlCommand("Select * From Tbl_Yonetici where YoneticiTc=@p1 and YoneticiSifre=@p2", bgl.baglantı());
            komut.Parameters.AddWithValue("@p1", mskTc.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();

            if (dr.Read()) // Bilgilerin Doğruluğunu Kontrol Eder
            {

                MessageBox.Show("Giriş Yapılıyor", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                YoneticiAnaSayfa frm = new YoneticiAnaSayfa();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Tc veya Şifre", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            bgl.baglantı().Close();
        }

        private void BtnGerii_Click(object sender, EventArgs e) // Seçim Ekranına Götürü
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }
    }
}
