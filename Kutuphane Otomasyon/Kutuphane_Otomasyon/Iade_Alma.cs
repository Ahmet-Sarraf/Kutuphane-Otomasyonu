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
    public partial class Iade_Alma : Form
    {
        public Iade_Alma()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi(); // SQl Adresi

        DateTime bugun = DateTime.Now; // Bugünün Tarihini Tutar

        private void Iade_Alma_Load(object sender, EventArgs e)
        {
            textBox1.TextChanged += new EventHandler(textBox1_TextChanged);
            Filtrele(textBox1.Text);
            Listele();
        }

        public void Listele() // TEslim Edilmemiş Kitapların Listelenmesini Sağlar
        {
            string Komut = "Select * From Tbl_OduncIslemleri where Teslim_Edilme_Durumu is Null Or Teslim_Edilme_Durumu = 0";
            SqlDataAdapter da = new SqlDataAdapter(Komut, bgl.baglantı());
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];

        }

        public void Filtrele(string arama) //Girilen TC Değerine Göre Tabloda Listeleme Yapılır
        {
            try
            {
                string Komut = "SELECT * FROM Tbl_OduncIslemleri WHERE (Teslim_Edilme_Durumu IS NULL OR Teslim_Edilme_Durumu = 0) AND KullanıcıTc LIKE @p1";
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Filtrele(textBox1.Text);
        }

        private void btnGetir_Click(object sender, EventArgs e) // Gridde Seçilen Satırın Bilgilerini Araçlara Taşır
        {
            try
            {
                txtKod.Text = gridView1.GetFocusedRowCellValue("Kitap_Kodu").ToString();
                txtTc.Text = gridView1.GetFocusedRowCellValue("KullanıcıTc").ToString();
                txtAlma.Text = gridView1.GetFocusedRowCellValue("Alma_Tarihi").ToString();
                txtSonTeslim.Text = gridView1.GetFocusedRowCellValue("Son_Teslim_Tarihi").ToString();
            }
            catch
            {
                MessageBox.Show("Kullanıcı Seçiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIade_Click(object sender, EventArgs e) // İade Etme Butonu
        {

            SqlCommand KomutIade = new SqlCommand(
                "UPDATE Tbl_OduncIslemleri SET Iade_Tarihi = @iadetarihi, " +
                "Zamanında_Teslim = CASE WHEN @bugun <= Son_Teslim_Tarihi THEN 1 ELSE 0 END, " +
                "Teslim_Edilme_Durumu = 1 " +
                "WHERE KullanıcıTc = @tc AND Kitap_Kodu = @kitapKodu AND Teslim_Edilme_Durumu = 0",
                bgl.baglantı());

            KomutIade.Parameters.AddWithValue("@iadeTarihi", bugun.ToString("yyyy-MM-dd"));
            KomutIade.Parameters.AddWithValue("@bugun", bugun.ToString("yyyy-MM-dd"));
            KomutIade.Parameters.AddWithValue("@tc", txtTc.Text);
            KomutIade.Parameters.AddWithValue("@kitapKodu", txtKod.Text);

            int etkilenenSatir = KomutIade.ExecuteNonQuery(); 
            if (etkilenenSatir > 0) // İade Etme Gerçekleşirse 
            {
                // Stok güncelle
                SqlCommand stokGuncelleme = new SqlCommand(
                    "UPDATE Tbl_Kitap SET Kutuphane_Adet = Kutuphane_Adet + 1 WHERE Kitap_Kodu = @kitapKodu",
                    bgl.baglantı());
                stokGuncelleme.Parameters.AddWithValue("@kitapKodu", txtKod.Text);
                stokGuncelleme.ExecuteNonQuery();

                // Zamanında Teslim Durumu'nu veritabanından okuma
                SqlCommand teslimDurumuSorgula = new SqlCommand(
                    "SELECT Zamanında_Teslim FROM Tbl_OduncIslemleri " +
                    "WHERE KullanıcıTc = @tc AND Kitap_Kodu = @kitapKodu AND Teslim_Edilme_Durumu = 1",
                    bgl.baglantı());
                teslimDurumuSorgula.Parameters.AddWithValue("@tc", txtTc.Text);
                teslimDurumuSorgula.Parameters.AddWithValue("@kitapKodu", txtKod.Text);

                object teslimDurumu = teslimDurumuSorgula.ExecuteScalar();
                int zamanindaTeslim = (teslimDurumu != DBNull.Value && teslimDurumu != null) ? Convert.ToInt32(teslimDurumu) : 0;

                // Kredi değişimi
                int krediDegisimi = (zamanindaTeslim == 1) ? 1 : -2;

                // Kullanıcı kredisi güncelle
                SqlCommand krediGuncelleme = new SqlCommand(
                    "UPDATE Tbl_Kullanıcı SET KullanıcıKredi = " +
                    "CASE " +
                    "WHEN @krediDegisimi > 0 THEN " +
                    "    CASE WHEN KullanıcıKredi + @krediDegisimi > 10 THEN 10 ELSE KullanıcıKredi + @krediDegisimi END " +
                    "ELSE " +
                    "    CASE WHEN KullanıcıKredi + @krediDegisimi < 0 THEN 0 ELSE KullanıcıKredi + @krediDegisimi END " +
                    "END " +
                    "WHERE KullanıcıTc = @tc",
                    bgl.baglantı());
                krediGuncelleme.Parameters.AddWithValue("@krediDegisimi", krediDegisimi);
                krediGuncelleme.Parameters.AddWithValue("@tc", txtTc.Text);
                krediGuncelleme.ExecuteNonQuery();

                // Kredi değişimi veritabanına kaydet
                SqlCommand krediDegisimiGuncelle = new SqlCommand(
                    "UPDATE Tbl_OduncIslemleri SET Kredi_Degisimi = @krediDegisimi WHERE KullanıcıTc = @tc AND Kitap_Kodu = @kitapKodu",
                    bgl.baglantı());
                krediDegisimiGuncelle.Parameters.AddWithValue("@krediDegisimi", krediDegisimi);
                krediDegisimiGuncelle.Parameters.AddWithValue("@tc", txtTc.Text);
                krediDegisimiGuncelle.Parameters.AddWithValue("@kitapKodu", txtKod.Text);
                krediDegisimiGuncelle.ExecuteNonQuery();

                MessageBox.Show("Kitap iade edildi, kredi güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Bu kitap zaten iade edilmiş olabilir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bgl.baglantı().Close();
            Listele();
            KitapPopulerlikGuncelleme();
        }

        //Kitap Popülerlik Güncelleme
        public void KitapPopulerlikGuncelleme()
        {
            // Kitaplar için popülerlik puanını güncelleme
            SqlCommand kitaplarKomutu = new SqlCommand("SELECT Kitap_Kodu, Kutuphane_Adet, Toplam_Adet FROM Tbl_Kitap", bgl.baglantı());
            SqlDataReader dr = kitaplarKomutu.ExecuteReader();

            while (dr.Read())
            {
                string kitapKodu = dr.GetString(0); // Kitap_Kodu (String olarak al)
                int kutuphaneAdet = dr.IsDBNull(1) ? 0 : dr.GetInt32(1);  // Kutuphane_Adet (Integer, Null kontrolü)
                int toplamAdet = dr.IsDBNull(2) ? 0 : dr.GetInt32(2); // Toplam_Adet (Integer, Null kontrolü)

                // Eğer kütüphanede hiç kitap yoksa, popülerlik puanı 10 olarak belirle
                if (kutuphaneAdet == 0)
                {
                    // Popülerlik puanını 10 olarak ayarla
                    SqlCommand populerlikGuncelleme = new SqlCommand("UPDATE Tbl_Kitap SET Kitap_Populerlik = '10' WHERE Kitap_Kodu = @KitapKodu", bgl.baglantı());
                    populerlikGuncelleme.Parameters.AddWithValue("@KitapKodu", kitapKodu);
                    populerlikGuncelleme.ExecuteNonQuery();
                    continue; // Bu kitabın popülerlik puanını güncelledik, diğer kitaplara geç
                }

                // Ödünç verilen kitap sayısını sorgula
                SqlCommand oduncVerilenKomut = new SqlCommand("SELECT COUNT(*) FROM Tbl_OduncIslemleri WHERE Kitap_Kodu = @KitapKodu AND Iade_Tarihi IS NULL", bgl.baglantı());
                oduncVerilenKomut.Parameters.AddWithValue("@KitapKodu", kitapKodu);
                int oduncVerilenKitapSayisi = Convert.ToInt32(oduncVerilenKomut.ExecuteScalar());

                // Popülerlik oranını hesapla
                double populerlikOrani = (double)oduncVerilenKitapSayisi / kutuphaneAdet; // Ödünç verilen / Kütüphane adet
                //double populerlikOrani = (double)oduncVerilenKitapSayisi / toplamAdet; // Ödünç verilen / Toplam adet
                int populerlikPuani = (int)(populerlikOrani * 10); // 0 ile 1 arasında olan oranı 10 ile çarparak popülerlik puanına çevir

                // Popülerlik puanını 1 ile 10 arasında sınırlama
                populerlikPuani = Math.Max(1, Math.Min(10, populerlikPuani));

                // Popülerlik puanını güncelle
                SqlCommand guncellePopulerlikKomutu = new SqlCommand("UPDATE Tbl_Kitap SET Kitap_Populerlik = @PopulerlikPuani WHERE Kitap_Kodu = @KitapKodu", bgl.baglantı());
                guncellePopulerlikKomutu.Parameters.AddWithValue("@PopulerlikPuani", populerlikPuani.ToString()); // Popülerlik puanını varchar olarak güncelle
                guncellePopulerlikKomutu.Parameters.AddWithValue("@KitapKodu", kitapKodu);
                guncellePopulerlikKomutu.ExecuteNonQuery();
            }

            dr.Close();
            bgl.baglantı().Close();
            MessageBox.Show("Kitap popülerlik puanları başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnEngelle_Click(object sender, EventArgs e) // Kullanıcı Engelleme Butomnu
        {
            if (string.IsNullOrWhiteSpace(txtTc.Text)) // TC değeri Boş İse
            {
                MessageBox.Show("Lütfen bir TC numarası giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult Onay = MessageBox.Show($"{txtTc.Text} Kimlik Numaralı Kullanıcıyı Engellemek İstediğinize Emin Misiniz? \n" +
                $"Not: Bu Kullanıcı Yöneticiler Tarafından Engeli Kaldırılmadan Tekardan Kitap Alamayacaktır","Dikkat",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);

            if (Onay == DialogResult.Yes) // Kullanıcıyı ENgellemeyi Onaylama
            {
                int kredi = 0;
                SqlCommand engelle = new SqlCommand("Update Tbl_Kullanıcı set KullanıcıKredi=@p1 where KullanıcıTc =@p2", bgl.baglantı());
                engelle.Parameters.AddWithValue("@p1", kredi);
                engelle.Parameters.AddWithValue("@p2", txtTc.Text);
                engelle.ExecuteNonQuery();
                bgl.baglantı().Close();

                MessageBox.Show("Kullanıcı Engellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}
