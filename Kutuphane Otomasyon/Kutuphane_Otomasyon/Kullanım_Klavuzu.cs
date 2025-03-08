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
    public partial class Kullanım_Klavuzu : Form
    {
        public Kullanım_Klavuzu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // Ödünç ve İade İşlemleri Butonu 
        {
            MessageBox.Show("Ödünç ALma İşlemi Yapmak İçin Bir Yöneticden Yardım Alabilir Yada Kendiniz Ödünç Alabilirsiniz. Aynı Anda Sadece Bir Kitap Alabilirsiniz " +
                "ve Sadece Kredinizin Yettiği Kitapları Alabilirsiniz. İade Etmek İstediğiniz Kitap İçin Ödünç Alma Adımlarının Aynısını İade Etme İçin Takip Edebilirsiniz.","Ödünç Alma ve İade İşlemşleri"
                , MessageBoxButtons.OK);
        }

        private void button4_Click(object sender, EventArgs e) // Kredi Sistemi Tablosu
        {
            MessageBox.Show("Krediniz Ödünç Aldığınız Kitabın Zamanında Teslim Edilme Durumuna Göre Değişmektedir." +
                "Krediniz, Aldığınız Kitabı Zamanında Teslim Etmeniz Durumunda Göre 1 puan Artar yada 2 Paun Azalır. Yeni Kayıt Oluşturduysanız Krediniz Otomatik 7" +
                " Olarak Belirlenmektedir","Kredi Sistemi",MessageBoxButtons.OK);
        }

        private void button5_Click(object sender, EventArgs e) // Alabileceğim Kitablar Tablosu
        {
            MessageBox.Show("Alabileceğiniz Kitaplar Kredinize Göre Belirlenmektedir. Kitaplar Kütüphanede Bulunma Miktarına Göre Puanlanmakta ve Aktif Ödünç Alınma Oranına Göre" +
                "Popülerliği Azalıp Artmaktadır. Krediniz, Alacağınız Kitabın Hem Puanından Hem de Popülerliğinden Az Olma Durumunda Kitabı Alamazsınız", "Alabileceğim Kitaplar"
                , MessageBoxButtons.OK);
        }

        private void button2_Click(object sender, EventArgs e) // Şifre İşlemleri
        {
            MessageBox.Show("Şifrenizi Unutmanız Durumunda Lütfen Bir Yetkiliye Danışınız. Kimlik Numaranız ile Şifrenizi Öğrenebilir Değiştirmek İsterseniz Yetkili Kişi Kendi" +
                "Panelinden Değişebilir yada Siz Kullanıcı Ekranından Kullanıcı İşlemleri Bölümünden Şifrenizi Değiştirebilirsiniz. ","Şifre İşlemleri",MessageBoxButtons.OK);
        }

        private void Kullanım_Klavuzu_Load(object sender, EventArgs e)
        {

        }
    }
}
