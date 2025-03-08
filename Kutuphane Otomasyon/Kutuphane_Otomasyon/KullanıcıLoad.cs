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
    public partial class KullanıcıLoad : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi(); // SQl Adresi
        public string TC; // Kullanıcı TC'si

        public KullanıcıLoad()
        {
            InitializeComponent();
        }

        private void KullanıcıLoad_Load(object sender, EventArgs e)
        {
            try
            {
                // İlk grafik için bağlantı ve veriler
                using (SqlConnection connection1 = bgl.baglantı())
                {
                    
                    using (SqlCommand Komut = new SqlCommand("SELECT Kitap_Turu, SUM(Kutuphane_Adet) AS 'Miktar' FROM Tbl_Kitap GROUP BY Kitap_Turu", connection1))
                    {
                        using (SqlDataReader dr = Komut.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(Convert.ToString(dr[1])));
                            }
                        }
                    }
                }

                bgl.baglantı().Close();

                // İkinci grafik için bağlantı ve veriler
                using (SqlConnection connection2 = bgl.baglantı())
                {
                    
                    using (SqlCommand Komut2 = new SqlCommand("SELECT Kategori, SUM(Kutuphane_Adet) AS 'Miktar' FROM Tbl_Kitap GROUP BY Kategori", connection2))
                    {
                        using (SqlDataReader dr2 = Komut2.ExecuteReader())
                        {
                            while (dr2.Read())
                            {
                                chartControl2.Series["Series 1"].Points.AddPoint(Convert.ToString(dr2[0]), int.Parse(Convert.ToString(dr2[1])));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (string.IsNullOrEmpty(TC))
            {
                MessageBox.Show("TC kimlik numarası boş olamaz.");
                return;
            }

            Listele();

        }
        public void Listele() // Kitapları Listeler
        {
            // Sadece popülerlik değeri 7'den büyük olan kitapları listeleyen sorgu
            string Komut = "SELECT * FROM Tbl_Kitap WHERE Kitap_Populerlik > 7";
            SqlDataAdapter da = new SqlDataAdapter(Komut, bgl.baglantı());
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
        }
    }
}
