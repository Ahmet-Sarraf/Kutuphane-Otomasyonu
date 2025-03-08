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
    public partial class Duyuru : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi(); // SQL Adresi
        public Duyuru()
        {
            InitializeComponent();
        }

        private void Duyuru_Load(object sender, EventArgs e)
        {
            Listele();
        }

        public void Listele() // Tüm Duyuruların Listelenmesini Sağlar
        {
            string Komut = "SELECT * FROM Tbl_Duyuru";
            SqlDataAdapter da = new SqlDataAdapter(Komut, bgl.baglantı());
            DataSet ds = new DataSet();
            da.Fill(ds);

            gridControl1.DataSource = ds.Tables[0];
        }

        private void btnAc_Click(object sender, EventArgs e) // Grid1'den Verileri Tools'lara TAşınmasını Sağlar
        {
            txtTarih.Text = gridView1.GetFocusedRowCellValue("Gönderme_Tarihi").ToString();
            txtKonu.Text = gridView1.GetFocusedRowCellValue("Duyurunun_Konusu").ToString();
            rchMesaj.Text = gridView1.GetFocusedRowCellValue("Duyuru").ToString();
        }
    }
}
