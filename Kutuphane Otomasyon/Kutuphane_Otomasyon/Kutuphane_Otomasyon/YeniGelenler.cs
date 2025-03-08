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
    public partial class YeniGelenler : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi();
        public YeniGelenler()
        {
            InitializeComponent();
        }

        private void YeniGelenler_Load(object sender, EventArgs e)
        {
            try
            {
                // Kitap ID Sıralaması Yapar ve Sondan Sıralamaya Başlar
                string sorgu = "SELECT * FROM Tbl_Kitap ORDER BY KitapID DESC";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sorgu, bgl.baglantı());
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                // GridView'e verileri bağlama
                gridControl1.DataSource = dataTable;

            }
            catch
            {
                MessageBox.Show("Bir hata oluştu: ");
            }

        }
    }
}
