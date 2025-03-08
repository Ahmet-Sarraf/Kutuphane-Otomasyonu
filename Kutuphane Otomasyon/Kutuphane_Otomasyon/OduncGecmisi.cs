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
    public partial class OduncGecmisi : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi();
        public string TC;
        public OduncGecmisi()
        {
            InitializeComponent();
        }

        private void OduncGecmisi_Load(object sender, EventArgs e)
        {
            Listele(TC);
        }

       
        
            public void Listele(string kullaniciTC) // Girilen TC'ye Ait Ödünç Geçmişini Listeler
            {
                if (string.IsNullOrWhiteSpace(kullaniciTC))
                {
                    MessageBox.Show("TC değeri boş olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    string Komut = "SELECT * FROM Tbl_OduncIslemleri WHERE KullanıcıTc = @kullaniciTC";
                    SqlDataAdapter da = new SqlDataAdapter(Komut, bgl.baglantı());
                    da.SelectCommand.Parameters.AddWithValue("@kullaniciTC", kullaniciTC);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    
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
        
    }
}
