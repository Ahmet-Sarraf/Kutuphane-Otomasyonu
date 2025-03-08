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
    public partial class Engelliler : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi(); // SQl Adresi 
        public Engelliler()
        {
            InitializeComponent();
            textBox1.TextChanged += new EventHandler(textBox1_TextChanged);
           
            Engellenenler();
            Filtrele(textBox1.Text);
        }

        private void Engelliler_Load(object sender, EventArgs e)
        {

        }

        private void Engellenenler() // Kredisi 0 Olan Kullanıcıları Listeler
        {
            
                string komut = "SELECT * FROM Tbl_Kullanıcı Where KullanıcıKredi = 0";
                SqlDataAdapter da = new SqlDataAdapter(komut, bgl.baglantı());
                DataSet ds = new DataSet();
                da.Fill(ds);
                gridControl1.DataSource = ds.Tables[0];
            
        }

        public void Filtrele(string arama) // Listelenmiş Kullanıcıları TC'ye Göre Arar
        {
            try
            {
                string Komut = "SELECT * FROM Tbl_Kullanıcı WHERE KullanıcıKredi = 0 and KullanıcıTc LIKE @p1";
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

        private void btnkaldır_Click(object sender, EventArgs e) // Kullanıcının Engelini (Kredisinin 0 Olma Durumu) Kaldırır
        {
            try
            {
                string Tc = gridView1.GetFocusedRowCellValue("KullanıcıTc").ToString(); //Gridde Seçilen Kullanıcının TC Bilgisini Tutar
                int temelKredi = 3;

                // Engeli Kaldırmak İçin Onay İster
                DialogResult Onay = MessageBox.Show($"{Tc} Kimlik Numaralı Kullanıcının Engelini Kaldırmayı Onaylıyor Musunuz? \n" +
                    $"Not: Bu Kullanıcının Kredisi 3 olarak Tanımlanacaktır", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (Onay == DialogResult.Yes)
                {

                    // Onaylama Durumunda Kredi puanı 3 Olarak Güncellenir (Engel Kalkar)
                    SqlCommand EngelKaldırma = new SqlCommand("Update Tbl_Kullanıcı set KullanıcıKredi=@q1 where KullanıcıTc=@q2", bgl.baglantı());
                    EngelKaldırma.Parameters.AddWithValue("@q1", temelKredi);
                    EngelKaldırma.Parameters.AddWithValue("@q2", Tc);
                    EngelKaldırma.ExecuteNonQuery();
                    bgl.baglantı().Close();
                    MessageBox.Show($"{Tc} Kimlik Numaralı Kullanıcının Engeli kalkmıştır.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Engellenenler();
                }
            }
            catch
            {
                MessageBox.Show("Engelini Kaldırmak İstediğiniz Kişiyi Seçiniz", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
