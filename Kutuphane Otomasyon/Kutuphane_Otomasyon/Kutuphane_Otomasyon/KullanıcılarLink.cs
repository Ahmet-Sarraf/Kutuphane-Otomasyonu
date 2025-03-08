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
    public partial class KullanıcılarLink : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi();
        public KullanıcılarLink()
        {
            InitializeComponent();
        }

        private void KullanıcılarLink_Load(object sender, EventArgs e)
        {
            Listele();
        }

        public void Listele() // Kullanıcıları Listeler
        {
            string Komut = "Select * from Tbl_Kullanıcı";
            SqlDataAdapter da = new SqlDataAdapter(Komut, bgl.baglantı());
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
