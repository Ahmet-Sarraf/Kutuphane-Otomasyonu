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
    public partial class KullanıcıIade : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi(); // SQL Adresi
        public  string TC; //Kullanıcı TC'si
        DateTime bugun = DateTime.Now; // Bugünün Tarihini Tutar

        public KullanıcıIade()
        {
            InitializeComponent();
        }

        private void KullanıcıIade_Load(object sender, EventArgs e)
        {
            txtTc.Text = TC;
            txtTc.ReadOnly = true; // Sadece Okunur Yapar

            try // Kitap Kodu getirme
            {
                SqlCommand getir = new SqlCommand("Select Kitap_Kodu from Tbl_OduncIslemleri Where Teslim_Edilme_Durumu=0 and KullanıcıTc=@p1", bgl.baglantı());
                getir.Parameters.AddWithValue("@p1", TC);

                SqlDataReader dr = getir.ExecuteReader();
                if (dr.Read())
                {
                    txtKod.Text = dr["Kitap_Kodu"].ToString();
                }
                else
                {
                    MessageBox.Show("İade Edecek Kitabınız Bulunmamakta", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    
                    return;
                    this.Hide();
                }
                
            }
            catch
            {
                MessageBox.Show("Bilgileri Getirirken Hata Oluştu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }


            try // Kitap Alma Tarihi Getirme
            {
                SqlCommand getir2 = new SqlCommand("Select Alma_Tarihi from Tbl_OduncIslemleri Where Teslim_Edilme_Durumu=0 and KullanıcıTc=@p1", bgl.baglantı());
                getir2.Parameters.AddWithValue("@p1", TC);

                SqlDataReader dr2 = getir2.ExecuteReader();
                if (dr2.Read())
                {
                    txtAlma.Text = dr2["Alma_Tarihi"].ToString();
                }
                else
                {
                    MessageBox.Show("İade Edecek Kitabınız Bulunmamakta", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    
                    return;
                    this.Hide();
                }

            }
            catch
            {
                MessageBox.Show("Bilgileri Getirirken Hata Oluştu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }


            try // Son Getirme Tarihi
            {
                SqlCommand getir3 = new SqlCommand("Select Son_Teslim_Tarihi from Tbl_OduncIslemleri Where Teslim_Edilme_Durumu=0 and KullanıcıTc=@p1", bgl.baglantı());
                getir3.Parameters.AddWithValue("@p1", TC);

                SqlDataReader dr3 = getir3.ExecuteReader();
                if (dr3.Read())
                {
                    txtSonTeslim.Text = dr3["Son_Teslim_Tarihi"].ToString();
                }
                else
                {
                    MessageBox.Show("İade Edecek Kitabınız Bulunmamakta", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    
                    return;
                    this.Hide();
                }

            }
            catch
            {
                MessageBox.Show("Bilgileri Getirirken Hata Oluştu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnIade_Click(object sender, EventArgs e) //İade Etme Butonu
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
            if (etkilenenSatir > 0)// İade Gerçekleşirse
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
            KitapPopulerlikGuncelleme();
            this.Hide();

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
    }
}
