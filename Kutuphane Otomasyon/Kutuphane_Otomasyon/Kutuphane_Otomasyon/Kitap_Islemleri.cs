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
    public partial class Kitap_Islemleri : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi();

        public Kitap_Islemleri()
        {
            InitializeComponent();

            cmbKategori.Items.Clear();
            cmbKategori.Items.AddRange(new string[] { "Roman", "Hikaye", "Masal-Fabl", "Kurgu Dışı" });
            cmbKategori3.Items.AddRange(new string[] { "Roman", "Hikaye", "Masal-Fabl", "Kurgu Dışı" });
        }

        
         
        private void Kitap_Islemleri_Load(object sender, EventArgs e)
        {
            
            Listele();
            
        }

        //Kitap Ekleme
        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                // Kitap Puan Belirleme
                int kitapSayisi = int.Parse(mskKitapSayı.Text);

                int kitapPuan = 0;
                if (kitapSayisi >= 1 && kitapSayisi <= 10)
                {
                    kitapPuan = 9;
                }
                else if (kitapSayisi >= 11 && kitapSayisi <= 20)
                {
                    kitapPuan = 8;
                }
                else if (kitapSayisi >= 21 && kitapSayisi <= 30)
                {
                    kitapPuan = 7;
                }
                else if (kitapSayisi >= 31 && kitapSayisi <= 40)
                {
                    kitapPuan = 6;
                }
                else if (kitapSayisi >= 41 && kitapSayisi <= 50)
                {
                    kitapPuan = 5;
                }
                else if (kitapSayisi >= 51 && kitapSayisi <= 60)
                {
                    kitapPuan = 4;
                }
                else if (kitapSayisi >= 61 && kitapSayisi <= 70)
                {
                    kitapPuan = 3;
                }
                else if (kitapSayisi >= 71 && kitapSayisi <= 80)
                {
                    kitapPuan = 2;
                }
                else if (kitapSayisi >= 81)
                {
                    kitapPuan = 1;
                }



                SqlCommand kontrolKomut = new SqlCommand("SELECT COUNT(*) FROM Tbl_Kitap WHERE Kitap_Kodu = @p1", bgl.baglantı());
                kontrolKomut.Parameters.AddWithValue("@p1", mskKod.Text);
                int kayitSayisi = (int)kontrolKomut.ExecuteScalar();

                if (kayitSayisi > 0)
                {
                    // Aynı kitap kodu varsa kullanıcıya hata mesajı göster
                    MessageBox.Show("Bu kitap koduna sahip bir kitap zaten mevcut. Lütfen farklı bir kod giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SqlCommand komut = new SqlCommand("insert into Tbl_Kitap (Kitap_Kodu,Kitap_Adı,Kategori,Kitap_Turu,Sayfa_Sayısı,Yazarı,Yazım_Dili,Dili,Yayınevi,Toplam_Adet,Kutuphane_Adet,Kitap_Puan) " +
                    "values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12)", bgl.baglantı());
                komut.Parameters.AddWithValue("@p1", mskKod.Text);
                komut.Parameters.AddWithValue("@p2", txtAd.Text);
                komut.Parameters.AddWithValue("@p3", cmbKategori.Text);
                komut.Parameters.AddWithValue("@p4", cmbTur.Text);
                komut.Parameters.AddWithValue("@p5", mskSayfaSayı.Text);
                komut.Parameters.AddWithValue("@p6", txtYazar.Text);
                komut.Parameters.AddWithValue("@p7", txtYazımDili.Text);
                komut.Parameters.AddWithValue("@p8", txtDil.Text);
                komut.Parameters.AddWithValue("@p9", txtYayın.Text);
                komut.Parameters.AddWithValue("@p10", mskKitapSayı.Text);
                komut.Parameters.AddWithValue("@p11", mskKitapSayı.Text);
                komut.Parameters.AddWithValue("@p12", kitapPuan);
                komut.ExecuteNonQuery();
                bgl.baglantı().Close();
                Temizle();
                Listele();
            }
            catch
            {
                MessageBox.Show("Lütfen Boş Alanları Doldurunuz!","Dikkat",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        // Ekleme Kısmının Bilgileri Temizlemesi
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
        
        //Silme Butonu
        private void btnSil_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(mskKod2.Text))
            {
                MessageBox.Show("Silmek İstediğiniz Kitabı Seçin", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult Onay = MessageBox.Show($"{mskKod2.Text} Kodlu Kitaplar Kalıcı olarak Silinmesini Onaylıyor Musun","Dikkat",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (Onay == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("Delete from Tbl_Kitap where Kitap_Kodu=@p1", bgl.baglantı());
                komut.Parameters.AddWithValue("@p1", mskKod2.Text);
                komut.ExecuteNonQuery();
                bgl.baglantı().Close();
                Listele();
                Temizle2();
            }
        }

        //Silme Bölümünün Bilgileri Getirme Butonu
        private void btnBilgiGetir_Click_1(object sender, EventArgs e)
        {
            mskKod2.Text = gridView1.GetFocusedRowCellValue("Kitap_Kodu").ToString();
            txtAd2.Text = gridView1.GetFocusedRowCellValue("Kitap_Adı").ToString();
            cmbKategori2.Text = gridView1.GetFocusedRowCellValue("Kategori").ToString();
            cmbTur2.Text = gridView1.GetFocusedRowCellValue("Kitap_Turu").ToString();
            mskSayfaSayı2.Text = gridView1.GetFocusedRowCellValue("Sayfa_Sayısı").ToString();
            txtYazar2.Text = gridView1.GetFocusedRowCellValue("Yazarı").ToString();
            txtYazımDili2.Text = gridView1.GetFocusedRowCellValue("Yazım_Dili").ToString();
            txtDil2.Text = gridView1.GetFocusedRowCellValue("Dili").ToString();
            txtYayın2.Text = gridView1.GetFocusedRowCellValue("Yayınevi").ToString();
            mskKitapSayı2.Text = gridView1.GetFocusedRowCellValue("Toplam_Adet").ToString();
            mskBulunan2.Text = gridView1.GetFocusedRowCellValue("Kutuphane_Adet").ToString();

        }

        //Silme Bölümünün Bilgileri TEmizleme Butonu
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Temizle2();
        }

        // Güncelleme Butonu
        private void btnGuncelle_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Kitap Puan Belirleme
                int kitapSayisi = int.Parse(mskBulunan3.Text);

                int kitapPuan = 0;
                if (kitapSayisi >= 1 && kitapSayisi <= 10)
                {
                    kitapPuan = 9;
                }
                else if (kitapSayisi >= 11 && kitapSayisi <= 20)
                {
                    kitapPuan = 8;
                }
                else if (kitapSayisi >= 21 && kitapSayisi <= 30)
                {
                    kitapPuan = 7;
                }
                else if (kitapSayisi >= 31 && kitapSayisi <= 40)
                {
                    kitapPuan = 6;
                }
                else if (kitapSayisi >= 41 && kitapSayisi <= 50)
                {
                    kitapPuan = 5;
                }
                else if (kitapSayisi >= 51 && kitapSayisi <= 60)
                {
                    kitapPuan = 4;
                }
                else if (kitapSayisi >= 61 && kitapSayisi <= 70)
                {
                    kitapPuan = 3;
                }
                else if (kitapSayisi >= 71 && kitapSayisi <= 80)
                {
                    kitapPuan = 2;
                }
                else if (kitapSayisi >= 81)
                {
                    kitapPuan = 1;
                }




                SqlCommand komut = new SqlCommand("Update Tbl_Kitap set Kitap_Adı=@p2,Kategori=@p3,Kitap_Turu=@p4,Sayfa_Sayısı=@p5,Yazarı=@p6,Yazım_Dili=@p7," +
                    "Dili=@p8,Yayınevi=@p9,Toplam_Adet=@p10, Kutuphane_Adet=@p11, Kitap_Puan=@p12 where Kitap_Kodu=@p1", bgl.baglantı());
                komut.Parameters.AddWithValue("@p1", mskKod3.Text);
                komut.Parameters.AddWithValue("@p2", txtAd3.Text);
                komut.Parameters.AddWithValue("@p3", cmbKategori3.Text);
                komut.Parameters.AddWithValue("@p4", cmbTur3.Text);
                komut.Parameters.AddWithValue("@p5", mskSayfaSayı3.Text);
                komut.Parameters.AddWithValue("@p6", txtYazar3.Text);
                komut.Parameters.AddWithValue("@p7", txtYazımDili3.Text);
                komut.Parameters.AddWithValue("@p8", txtDil3.Text);
                komut.Parameters.AddWithValue("@p9", textBox9.Text);
                komut.Parameters.AddWithValue("@p10", mskKitapSayı3.Text);
                komut.Parameters.AddWithValue("@p11", mskBulunan3.Text);
                komut.Parameters.AddWithValue("@p12", kitapPuan);
                komut.ExecuteNonQuery();
                bgl.baglantı().Close();
                Temizle3();
                Listele();
            }
            catch
            {
                MessageBox.Show("Lütfen Boş Alanları Doldurunuz!", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //Güncelleme Kısmının Bilgileri Getir Butonu
        private void btnBilgiGetir2_Click(object sender, EventArgs e)
        {
            mskKod3.Text = gridView1.GetFocusedRowCellValue("Kitap_Kodu").ToString();
            txtAd3.Text = gridView1.GetFocusedRowCellValue("Kitap_Adı").ToString();
            cmbKategori3.Text = gridView1.GetFocusedRowCellValue("Kategori").ToString();
            cmbTur3.Text = gridView1.GetFocusedRowCellValue("Kitap_Turu").ToString();
            mskSayfaSayı3.Text = gridView1.GetFocusedRowCellValue("Sayfa_Sayısı").ToString();
            txtYazar3.Text = gridView1.GetFocusedRowCellValue("Yazarı").ToString();
            txtYazımDili3.Text = gridView1.GetFocusedRowCellValue("Yazım_Dili").ToString();
            txtDil3.Text = gridView1.GetFocusedRowCellValue("Dili").ToString();
            textBox9.Text = gridView1.GetFocusedRowCellValue("Yayınevi").ToString();
            mskKitapSayı3.Text = gridView1.GetFocusedRowCellValue("Toplam_Adet").ToString();
            mskBulunan3.Text = gridView1.GetFocusedRowCellValue("Kutuphane_Adet").ToString();
        }

        //Güncelleme Kısmının Bilgileri Silme Butonu
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Temizle3();
        }



        public void Temizle()
        {
            mskKod.Text = "";
            txtAd.Text = "";
            cmbKategori.Text = "";
            cmbTur.Text = "";
            mskSayfaSayı.Text = "";
            txtYazar.Text = "";
            txtYazımDili.Text = "";
            txtDil.Text = "";
            txtYayın.Text = "";
            mskKitapSayı.Text = "";
            mskBulunan.Text = "";
        }
        public void Temizle2()
        {
            mskKod2.Text = "";
            txtAd2.Text = "";
            cmbKategori2.Text = "";
            cmbTur2.Text = "";
            mskSayfaSayı2.Text = "";
            txtYazar2.Text = "";
            txtYazımDili2.Text = "";
            txtDil2.Text = "";
            txtYayın2.Text = "";
            mskKitapSayı2.Text = "";
            mskBulunan2.Text = "";
        }
        public void Temizle3()
        {
            mskKod3.Text = "";
            txtAd3.Text = "";
            cmbKategori3.Text = "";
            cmbTur3.Text = "";
            mskSayfaSayı3.Text = "";
            txtYazar3.Text = "";
            txtYazımDili3.Text = "";
            txtDil3.Text = "";
            textBox9.Text = "";
            mskKitapSayı3.Text = "";
            mskBulunan3.Text = "";
        }

        // Ekleme Kısmının Comboboxlarını Doldurma
        private void cmbKatagori_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbTur.Items.Clear();

            switch (cmbKategori.SelectedItem.ToString())
            {
                case "Roman":
                    cmbTur.Items.AddRange(new string[] { "Macera", "Bilim Kurgu", "Fantastik", "Romantik", "Tarihi", "Polisiye", "Gerilim", "Korku", "Psikolojik", " Felsefi", "Dram", "Komedi", "Postmodern" });
                    break;

                case "Hikaye":
                    cmbTur.Items.AddRange(new string[] { "Olay", "Durum", " Fantastik", "Polisiye", "Korku", "Mizah", "Dramatik", "Psikolojik", "Macera", "Bilim Kurgu" });
                    break;

                case "Masal-Fabl":
                    cmbTur.Items.AddRange(new string[] { "Hayvan Masalları"," Halk Masalları","Destan Masalları","Kısa Masallar","Folk Masalları","Büyü Masalları","Efsane Masalalrı","Peri Masalları"  });
                    break;

                case "Kurgu Dışı":
                    cmbTur.Items.AddRange(new string[] { "Biyografi", "Otobiyografi", "Anı", "Deneme", "Tarih", "Gezi", "Bilimsel ve Teknik", "Kişisel Gelişim", "Eğitim ve Rehberlik","Felsefi" });
                    break;

                default:
                    cmbTur.Items.Add("Tür bulunamadı.");
                    break;
            }
        }



        // Güncelleme Kısmının Comboboxlarını Doldurma
        private void cmbKategori3_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbTur3.Items.Clear();

            switch (cmbKategori3.SelectedItem.ToString())
            {
                case "Roman":
                    cmbTur3.Items.AddRange(new string[] { "Macera", "Bilim Kurgu", "Fantastik", "Romantik", "Tarihi", "Polisiye", "Gerilim", "Korku", "Psikolojik", " Felsefi", "Dram", "Komedi", "Postmodern" });
                    break;

                case "Hikaye":
                    cmbTur3.Items.AddRange(new string[] { "Olay", "Durum", " Fantastik", "Polisiye", "Korku", "Mizah", "Dramatik", "Psikolojik", "Macera", "Bilim Kurgu" });
                    break;

                case "Masal-Fabl":
                    cmbTur3.Items.AddRange(new string[] { "Hayvan Masalları", " Halk Masalları", "Destan Masalları", "Kısa Masallar", "Folk Masalları", "Büyü Masalları", "Efsane Masalalrı", "Peri Masalları" });
                    break;

                case "Kurgu Dışı":
                    cmbTur3.Items.AddRange(new string[] { "Biyografi", "Otobiyografi", "Anı", "Deneme", "Tarih", "Gezi", "Bilimsel ve Teknik", "Kişisel Gelişim", "Eğitim ve Rehberlik","Felsefi" });
                    break;

                default:
                    cmbTur3.Items.Add("Tür bulunamadı.");
                    break;
            }
        }

        // Grid Tablosunu Listeleme Metodu
        public void Listele()
        {
            string Komut = "Select * from Tbl_Kitap";
            SqlDataAdapter da = new SqlDataAdapter(Komut, bgl.baglantı());
            DataSet ds = new DataSet();
            da.Fill(ds);
            txtYayın3.DataSource = ds.Tables[0];

        }

        //Tıklanan butona göre açılacak olan sayfa
        public void SetTabPage(int tabIndex)
        {
            switch (tabIndex)
            {
                case 1:
                    tabControl1.SelectedIndex = 0; // Ekleme işlemi için 1. tab seçilir
                    break;
                case 2:
                    tabControl1.SelectedIndex = 1; // Silme işlemi için 2. tab seçilir
                    break;
                case 3:
                    tabControl1.SelectedIndex = 2; // Güncelleme işlemi için 3. tab seçilir
                    break;
            }
        }
        
    }
}
