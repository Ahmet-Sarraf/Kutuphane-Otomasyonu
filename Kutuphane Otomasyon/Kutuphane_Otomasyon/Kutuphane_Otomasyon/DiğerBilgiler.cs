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
    public partial class DiğerBilgiler : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi(); //SQL Adresi
        public DiğerBilgiler()
        {
            InitializeComponent();
        }

        private void DiğerBilgiler_Load(object sender, EventArgs e)
        {
            txtButun.TextChanged += new EventHandler(txtButun_TextChanged);
            txtIade.TextChanged += new EventHandler(txtIade_TextChanged);
            txtnotIade.TextChanged += new EventHandler(txtnotIade_TextChanged);

            TumKitaplariGetir();
            IadeEdilmemisKitaplariGetir();
            IadeEdilmisKitaplariGetir();
           
            Filtrele1(txtButun.Text);
            Filtrele2(txtIade.Text);
            Filtrele3(txtnotIade.Text);

        }

        private void TumKitaplariGetir() // Grid1'e Kitap Tablosunun Listelenmesini Sağlar
        {
            try
            {
                string komut = "SELECT * FROM Tbl_OduncIslemleri";
                SqlDataAdapter da = new SqlDataAdapter(komut, bgl.baglantı());
                DataSet ds = new DataSet();
                da.Fill(ds);
                gridControl1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tüm kitapları getirirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void IadeEdilmisKitaplariGetir() // Grid2'ye Teslim Edilmiş Kitapların Gelmesini Sağlar
        {
            try
            {
                string komut = "SELECT * FROM Tbl_OduncIslemleri WHERE Teslim_Edilme_Durumu = 1";
                SqlDataAdapter da = new SqlDataAdapter(komut, bgl.baglantı());
                DataSet ds = new DataSet();
                da.Fill(ds);
                gridControl2.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("İade edilmiş kitapları getirirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void IadeEdilmemisKitaplariGetir() // Grid3'e Teslim Edilmemiş Kitapların Gelmesini Sağlar
        {
            try
            {
                string komut = "Select * From Tbl_OduncIslemleri where Teslim_Edilme_Durumu is Null Or Teslim_Edilme_Durumu = 0";
                SqlDataAdapter da = new SqlDataAdapter(komut, bgl.baglantı());
                DataSet ds = new DataSet();
                da.Fill(ds);
                gridControl3.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("İade edilmemiş kitapları getirirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        public void Filtrele1(string arama) // Grid1'de TC Bilgisine Göre Arama Yapılmasını Sağlar
        {
            try
            {
                string Komut = "SELECT * FROM Tbl_OduncIslemleri WHERE KullanıcıTc LIKE @p1";
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

        public void Filtrele2(string arama)// Grid2'de TC Bilgisine Göre Arama Yapılmasını Sağlar
        {
            try
            {
                string Komut = "SELECT * FROM Tbl_OduncIslemleri WHERE Teslim_Edilme_Durumu = 1 AND KullanıcıTc LIKE @p1";
                SqlDataAdapter da = new SqlDataAdapter(Komut, bgl.baglantı());
                da.SelectCommand.Parameters.AddWithValue("@p1", arama + "%"); // Başlayan kelimeler için filtre
                DataSet ds = new DataSet();
                da.Fill(ds);
                gridControl2.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void Filtrele3(string arama) // Grid3'de TC Bilgisine Göre Arama Yapılmasını Sağlar
        {
            try
            {
                string Komut = "SELECT * FROM Tbl_OduncIslemleri WHERE (Teslim_Edilme_Durumu IS NULL OR Teslim_Edilme_Durumu = 0) AND KullanıcıTc LIKE @p1";
                SqlDataAdapter da = new SqlDataAdapter(Komut, bgl.baglantı());
                da.SelectCommand.Parameters.AddWithValue("@p1", arama + "%"); // Başlayan kelimeler için filtre
                DataSet ds = new DataSet();
                da.Fill(ds);
                gridControl3.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtButun_TextChanged(object sender, EventArgs e)
        {
            Filtrele1(txtButun.Text);
        }

        private void txtIade_TextChanged(object sender, EventArgs e)
        {
            Filtrele2(txtIade.Text);
        }

        private void txtnotIade_TextChanged(object sender, EventArgs e)
        {
            Filtrele3(txtnotIade.Text);
        }
    }
}
