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
    public partial class Butun_Mesajlar : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi(); //SQL Adresi

        public Butun_Mesajlar()
        {
            InitializeComponent();
        }
        private void Butun_Mesajlar_Load(object sender, EventArgs e)
        {
            textBox1.TextChanged += new EventHandler(textBox1_TextChanged);
            Listele();
            Filtrele1(textBox1.Text);
        }

        public void Filtrele1(string arama) // Girilen TC'ye Göre Filtrele İşlemi
        {
            try
            {
                string Komut = "SELECT * FROM Tbl_Mesaj WHERE KullanıcıTc Like @p1";
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


        public void Listele() // Bütün Mesaj Tablosunun Listelenmesi
        {
            string komut = "SELECT * FROM Tbl_Mesaj";
            SqlDataAdapter da = new SqlDataAdapter(komut, bgl.baglantı());
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Filtrele1(textBox1.Text);
        }

        private void btnAc_Click(object sender, EventArgs e) // Mesajın Açılmasını Sağlar
        {
            rchMesaj.Text = gridView1.GetFocusedRowCellValue("Mesaj").ToString();
        }
    }
}
