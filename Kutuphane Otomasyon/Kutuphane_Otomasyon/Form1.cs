using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane_Otomasyon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // Kullanıcı Giriş Ekranını Açar
        {
            FrmKullanıcıGiris frm = new FrmKullanıcıGiris();
            frm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e) // Yönetici Giriş Ekranını Açar
        {
            FrmYoneticiGiris frm = new FrmYoneticiGiris();
            frm.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
