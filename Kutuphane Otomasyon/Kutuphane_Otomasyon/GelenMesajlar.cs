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
    public partial class GelenMesajlar : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi(); //SQL Adresi
        public string TC; // Giriş Yapan Kullanıcının TC'sini Tutar

        public GelenMesajlar() 
        {
            InitializeComponent();
            txtKonu.ReadOnly = true; // Aracın sadece okunabilmesini Sağlar
            txtTarih.ReadOnly = true;// Aracın sadece okunabilmesini Sağlar
            rchMesaj.ReadOnly = true;// Aracın sadece okunabilmesini Sağlar
        }

        private void GelenMesajlar_Load(object sender, EventArgs e)
        {
            Listele(TC);
        }

        public void Listele(string kullaniciTC) // Girilen TC DEğerine Göre Mesajlar Tablosunu Listeler
        {
            if (string.IsNullOrWhiteSpace(kullaniciTC))
            {
                MessageBox.Show("TC değeri boş olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string Komut = "SELECT * FROM Tbl_Mesaj WHERE KullanıcıTc = @kullaniciTC";
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

        private void btnAc_Click(object sender, EventArgs e) // Mesajı Tools'a Taşır
        {
            txtTarih.Text = gridView1.GetFocusedRowCellValue("Gonderme_Tarihi").ToString();
            txtKonu.Text = gridView1.GetFocusedRowCellValue("Mesaj_Konusu").ToString();
            rchMesaj.Text = gridView1.GetFocusedRowCellValue("Mesaj").ToString();
            
        }
    }
}
