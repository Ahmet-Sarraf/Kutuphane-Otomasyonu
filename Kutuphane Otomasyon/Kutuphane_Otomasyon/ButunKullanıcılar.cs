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
    public partial class ButunKullanıcılar : Form
    {
        public ButunKullanıcılar()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi(); //SQL Adresi

        private void ButunKullanıcılar_Load(object sender, EventArgs e)
        {
            textBox1.TextChanged += new EventHandler(textBox1_TextChanged);
            Listele();
            Filtrele(textBox1.Text);
        }
        public void Listele() // Bütün Kullanıcıları Listeler
        {
            string Komut = "Select * from Tbl_Kullanıcı";
            SqlDataAdapter da = new SqlDataAdapter(Komut, bgl.baglantı());
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];

        }

        public void Filtrele(string arama) // Girilen TC 'ye Göre Listeleme Yapar
        {
            try
            {
                string Komut = "SELECT * FROM Tbl_Kullanıcı WHERE KullanıcıTc LIKE @p1";
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
            Filtrele(textBox1.Text);
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void lnkEngelli_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) // Engellenmiş Kullanıcıların Listesine Ulaşılır
        {
            Engelliler frm = new Engelliler();
            frm.Show();
        }
    }
}
