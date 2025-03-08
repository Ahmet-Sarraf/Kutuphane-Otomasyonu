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
    public partial class OduncAlma : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi();// SQL Adresi
        private DataTable filtrelenmisKitaplar; // Kullanıcının alabileceği kitaplar

        DateTime bugun = DateTime.Now; // Bugünğn Tarihini Tutar

        public string TC; // Kullanıcının TC'Sini Tutar 

        public OduncAlma()
        {
            InitializeComponent();
            comboBox1.TextChanged += comboBox1_TextChanged;
            Filtrele(comboBox1.Text);
        }

        private void OduncAlma_Load(object sender, EventArgs e)
        {
            Listele(TC);
            mskTc.Text = TC;
            mskTc.ReadOnly = true;
            SonTeslim.MinDate = bugun;
            SonTeslim.MaxDate = bugun.AddMonths(1);

            // Kullanıcı Kredi Puanını Sorgular
            SqlCommand KrediGetir = new SqlCommand("Select KullanıcıKredi from Tbl_Kullanıcı where KullanıcıTc = @tc2", bgl.baglantı());
            KrediGetir.Parameters.AddWithValue("@tc2", TC);

            object result2 = KrediGetir.ExecuteScalar();
            if (result2 != null)
            {
                label5.Text = $"Kredi Puanınız {result2}"; // Kredi Puanını Labele Atar
            }
            else
            {
                MessageBox.Show("Kullanıcı Bulunamadı");
            }


        }

        public void Listele(string kullaniciTC) // Girilen TC'ye Göre Listeleme Yapar
        {
            if (string.IsNullOrWhiteSpace(kullaniciTC))
            {
                MessageBox.Show("TC değeri boş olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Kullanıcının Kredisine Göre Alabileceği Kitapları Seçen Komut
                string Komut = @"SELECT * 
                         FROM Tbl_Kitap 
                         WHERE Kitap_Puan <= (SELECT KullanıcıKredi FROM Tbl_Kullanıcı WHERE KullanıcıTc = @kullaniciTC)
                           AND Kitap_Populerlik <= (SELECT KullanıcıKredi FROM Tbl_Kullanıcı WHERE KullanıcıTc = @kullaniciTC)";
                SqlDataAdapter da = new SqlDataAdapter(Komut, bgl.baglantı());
                da.SelectCommand.Parameters.AddWithValue("@kullaniciTC", kullaniciTC);
                DataSet ds = new DataSet();
                da.Fill(ds);
                filtrelenmisKitaplar = ds.Tables[0]; // Veriyi filtrelenmisKitaplar'a atayın
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

        public void Filtrele(string arama) 
        {
            if (filtrelenmisKitaplar == null) return; // Eğer filtrelenmisKitaplar null ise işlem yapma

            // Kullanıcının alabileceği kitaplardan arama yap
            DataView view = new DataView(filtrelenmisKitaplar);
            view.RowFilter = $"Kitap_Adı LIKE '{arama}%'";
            gridControl1.DataSource = view;
        }

        public void ComboBoxDoldur() // Kitap İsimlerine Göre Comboboxu Doldurur
        {
            try
            {
                string Komut = "SELECT Kitap_Adı FROM Tbl_Kitap";
                SqlCommand cmd = new SqlCommand(Komut, bgl.baglantı());
                SqlDataReader dr = cmd.ExecuteReader();

                // ComboBox AutoComplete ayarları
                AutoCompleteStringCollection kitaplar = new AutoCompleteStringCollection();

                while (dr.Read())
                {
                    string kitapAdi = dr["Kitap_Adı"].ToString();
                    comboBox1.Items.Add(kitapAdi);
                    kitaplar.Add(kitapAdi); // Otomatik tamamlama için ekleme
                }

                dr.Close();

                comboBox1.AutoCompleteCustomSource = kitaplar;
                comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
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

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            Filtrele(comboBox1.Text);
        }

        private void btnSec_Click(object sender, EventArgs e)
        {
            txtKitapKodu.Text = gridView1.GetFocusedRowCellValue("Kitap_Kodu").ToString();
        }

        private void btnAl_Click(object sender, EventArgs e)
        {
            //  Kitap Kodu Sorgulama
            SqlCommand kontrolKomutu = new SqlCommand("SELECT COUNT(*) FROM Tbl_Kitap WHERE Kitap_Kodu = @KitapKodu", bgl.baglantı());
            kontrolKomutu.Parameters.AddWithValue("@KitapKodu", txtKitapKodu.Text);

            int KitapKodu = Convert.ToInt32(kontrolKomutu.ExecuteScalar());

            if (KitapKodu == 0)
            {
                // Kullanıcı bulunamadıysa hata mesajı göster ve işlemi durdur
                MessageBox.Show("Hatalı Kitap Kodu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bgl.baglantı().Close();
                return; // İşlemi sonlandır
            }

            // Kullanıcı Kredi Sorgulama
            SqlCommand KullanıcıKredi = new SqlCommand("Select KullanıcıKredi From Tbl_Kullanıcı where KullanıcıTc=@Kullanıcıtc", bgl.baglantı());
            KullanıcıKredi.Parameters.AddWithValue("@Kullanıcıtc", mskTc.Text);
            int kullaniciKredisi = Convert.ToInt32(KullanıcıKredi.ExecuteScalar());

            //Kitap Puan ve Popülerlik Sorgulama
            SqlCommand kitapPuanKomutu = new SqlCommand("SELECT Kitap_Puan, Kitap_Populerlik FROM Tbl_Kitap WHERE Kitap_Kodu = @kitapKodu", bgl.baglantı());
            kitapPuanKomutu.Parameters.AddWithValue("@kitapKodu", txtKitapKodu.Text);
            SqlDataReader reader = kitapPuanKomutu.ExecuteReader();

            int kitapPuanı = 0;
            int kitapPopülerlik = 0;

            if (reader.Read())
            {
                kitapPuanı = Convert.ToInt32(reader["Kitap_Puan"]);
                kitapPopülerlik = Convert.ToInt32(reader["Kitap_Populerlik"]);
            }
            reader.Close();

            if (kullaniciKredisi < kitapPuanı || kullaniciKredisi < kitapPopülerlik)
            {
                MessageBox.Show($"Kullanıcı kredisi ({kullaniciKredisi}), bu kitabı ödünç almak için yetersiz. Kitap için gereken kredi: {kitapPuanı} veya {kitapPopülerlik} (Popülerlik).",
                        "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kitap Sayısı Sorgulama
            SqlCommand KitapSayısı = new SqlCommand("Select Kutuphane_Adet from Tbl_Kitap where Kitap_Kodu = @a1", bgl.baglantı());
            KitapSayısı.Parameters.AddWithValue("@a1", txtKitapKodu.Text);
            int mevcutStok = Convert.ToInt32(KitapSayısı.ExecuteScalar());
            if (mevcutStok <= 0)
            {
                MessageBox.Show("Bu kitap kütüphanede kalmadı. Ödünç verme işlemi yapılamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bgl.baglantı().Close();
                return;
            }

            SqlCommand AktıfOdunc = new SqlCommand("Select Count(*) From Tbl_OduncIslemleri Where KullanıcıTc=@kullanıcıtc And Iade_Tarihi is Null", bgl.baglantı());
            AktıfOdunc.Parameters.AddWithValue("@kullanıcıtc", mskTc.Text);
            int aktifOduncSayisi = Convert.ToInt32(AktıfOdunc.ExecuteScalar());
            if (aktifOduncSayisi > 0)
            {
                MessageBox.Show("Birden Fazla Kitap Alamazsın.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bgl.baglantı().Close();
                return;
            }

            // Ödünç verme
            SqlCommand komut = new SqlCommand("insert into Tbl_OduncIslemleri (KullanıcıTc,Kitap_Kodu, Alma_Tarihi,Son_Teslim_Tarihi) values" +
                "(@p1,@p2,@p3,@p4)", bgl.baglantı());
            komut.Parameters.AddWithValue("@p1", mskTc.Text);
            komut.Parameters.AddWithValue("@p2", txtKitapKodu.Text);
            komut.Parameters.AddWithValue("@p3", bugun.ToString("yyyy-MM-dd"));
            komut.Parameters.AddWithValue("@p4", SonTeslim.Value.ToString("yyyy-MM-dd"));
            komut.ExecuteNonQuery();
            bgl.baglantı().Close();

            // Bulunan Kitap Sayısı Güncelleme
            SqlCommand komut2 = new SqlCommand("Update Tbl_Kitap Set Kutuphane_Adet = Kutuphane_Adet - 1 Where Kitap_Kodu =@s1 ", bgl.baglantı());
            komut2.Parameters.AddWithValue("@s1", txtKitapKodu.Text);
            komut2.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("Kitap Ödünç Verildi ve stok güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Kitap popülerlik tanımlama
            KitapPopulerlikGuncelleme();
            Listele(TC);

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
