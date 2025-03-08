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
    public partial class Alınabilir_Kitaplar : Form
    {
       
        sqlbaglantisi bgl = new sqlbaglantisi();//SQL Adresi
        private DataTable filtrelenmisKitaplar; // Kullanıcının alabileceği kitaplar

        public string TC; // Kullanıcının TC Bilgisi
        
        
        public Alınabilir_Kitaplar()
        {
            InitializeComponent();
            
            comboBox1.TextChanged += comboBox1_TextChanged;
            Filtrele(comboBox1.Text);

        }

        private void Alınabilir_Kitaplar_Load(object sender, EventArgs e)
        {

            Listele(TC);

        }
        
        // Kitapların Listelenmesi
        public void Listele(string kullaniciTC)
        {
            if (string.IsNullOrWhiteSpace(kullaniciTC))
            {
                MessageBox.Show("TC değeri boş olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Kullanıcının Kredisine göre alabileceği kitapların filtrelenmesi
                string Komut = @"SELECT * 
                         FROM Tbl_Kitap 
                         WHERE Kitap_Puan <= (SELECT KullanıcıKredi FROM Tbl_Kullanıcı WHERE KullanıcıTc = @kullaniciTC)
                           AND Kitap_Populerlik <= (SELECT KullanıcıKredi FROM Tbl_Kullanıcı WHERE KullanıcıTc = @kullaniciTC)";
                SqlDataAdapter da = new SqlDataAdapter(Komut, bgl.baglantı());
                da.SelectCommand.Parameters.AddWithValue("@kullaniciTC", kullaniciTC);
                DataSet ds = new DataSet();
                da.Fill(ds);
                filtrelenmisKitaplar = ds.Tables[0]; // Veriyi filtrelenmisKitaplar'a atayın
                gridControl1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                bgl.baglantı().Close();
            }
        }

        public void Filtrele(string arama)
        {
            if (filtrelenmisKitaplar == null) return; // Eğer filtrelenmisKitaplar null ise işlem yapma

            // Kullanıcının alabileceği kitaplardan arama yap
            DataView view = new DataView(filtrelenmisKitaplar);
            view.RowFilter = $"Kitap_Adı LIKE '{arama}%'";
            gridControl1.DataSource = view;
        }

        public void ComboBoxDoldur()
        {
            try
            {
                // Kullanıcının Alabileceği Kitaplar Arasında Arama Yapması
                string Komut = "SELECT Kitap_Adı FROM Tbl_Kitap";
                SqlCommand cmd = new SqlCommand(Komut, bgl.baglantı());
                SqlDataReader dr = cmd.ExecuteReader();

                // ComboBox AutoComplete ayarları
                AutoCompleteStringCollection kitaplar = new AutoCompleteStringCollection();

                while (dr.Read())
                {
                    string kitapAdi = dr["Kitap_Adı"].ToString();
                    comboBox1.Items.Add(kitapAdi);
                    kitaplar.Add(kitapAdi); // Otomatik tamamlama için ekleme
                }

                dr.Close();

                comboBox1.AutoCompleteCustomSource = kitaplar;
                comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                bgl.baglantı().Close();
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            Filtrele(comboBox1.Text);
        }
    }
}
