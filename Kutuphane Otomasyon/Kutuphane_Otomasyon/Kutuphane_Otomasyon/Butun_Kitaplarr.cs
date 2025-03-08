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
    public partial class Butun_Kitaplarr : Form
    {
        public Butun_Kitaplarr()
        {
            InitializeComponent();
            comboBox1.TextChanged += comboBox1_TextChanged;
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        private void Butun_Kitaplarr_Load(object sender, EventArgs e)
        {
            Listele();
            ComboBoxDoldur();
            Filtrele(comboBox1.Text);
        }

        public void Listele() // Bütün Kitapların Listelenmesini Sağlar
        {
            string Komut = "Select * from Tbl_Kitap";
            SqlDataAdapter da = new SqlDataAdapter(Komut, bgl.baglantı());
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];

        }

        public void ComboBoxDoldur() // Girilen Harfe Göre Combobox'u Doldurur
        {
            try
            {
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

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            Filtrele(comboBox1.Text); // COmbobox DEğişimine Göre Filtreleme yapar
        }

        public void Filtrele(string arama) // Girilen Değere Göre Listelenmiş Kitaplar Arasında Filtrelenme Yapar
        {
            try
            {
                string Komut = "SELECT * FROM Tbl_Kitap WHERE Kitap_Adı LIKE @p1";
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
