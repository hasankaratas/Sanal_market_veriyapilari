using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SanalMarket
{
    public partial class Form1 : Form
    {
        public static Market market = new Market();
        public static double  gelir = 0, gider = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 fr2 = new Form2();
            bool kontrol = false;
            foreach(Musteri mus in market.Musteriler)
            {
                if(mus.KullaniciAdi==txtMusteriKullaniciAdi.Text)
                {
                    if (mus.SifreKontrol(txtMusteriSifre.Text))
                    {
                        kontrol = true;
                        txtMusteriKullaniciAdi.Clear();
                        txtMusteriSifre.Clear();
                        fr2.must = mus;
                        fr2.ShowDialog();
                    }
                }
                
            }
            if(kontrol == false)
            {
                MessageBox.Show("Kullanıcı Adı veya Şifreniz Yanlıştır.!");
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnPersonelGirisi_Click(object sender, EventArgs e)
        {
            Form3 fr3 = new Form3();
            if(txtPersonelKullaniciAdi.Text=="admin"&& txtPersonelSifre.Text == "admin")
            {
                txtPersonelKullaniciAdi.Clear();
                txtPersonelSifre.Clear();
                fr3.ShowDialog();
            }
            else
            {
                MessageBox.Show("Girilen Kullanıcı Adı veya Şifre Yanlış.. ");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int j = 0;
            string[] kategoriler = { "Bilgisayar", "Beyaz Eşya", "Giyim", "Kırtasiye & Ofis", "Yapı Market", "Bahçe", "Tekstil", "Yiyecek" };
            string[] urunadlari = { "Dizüstü Bilgisayar", "Masaüstü Bilgisayar", "Buzdolabı", "Çamaşır Makinası", "Gömlek", "Takım Elbise", "Kalem", "Defter", "Boya", "El Aletleri", "Bahçe Sandalyeleri", "Bahçe Takımları", "Perde", "Yorgan", "Et Ürünleri", "Süt Ürünleri" };
            string[] urunmarkalari = { "Asus", "Monster", "Beko", "Bosch", "Altınyıldız", "Pierre Cardin", "Faber Castel", "GIPTA", "Marshall", "Stanley", "Comfort", "Sunfun", "Taç", "Karaca", "Emin", "Pınar" };
            string[] urunmodel = { "ROG", "ABRA", "B9470", "WAT24480TR", "TAİLORED", "G021GL001.BOSTON.53252.VR033", "Grip", "Quadro", "Mat Silikon", "STDC18LHBK", "Begonya", "Orkide", "Beşiktaşlı", "Real Madridli", "Kuşbaşı", "Peynir" };
            int[] urunmikar = { 5, 15, 7, 2, 35, 4, 7, 12, 14, 21, 23, 2, 1, 31, 14, 17 };
            int[] urunmaliyet = { 2200, 1200, 250, 450, 20, 150, 14, 10, 15, 100, 35, 140, 25, 40, 14, 7 };
            int[] urunsatisfiyati = { 5500, 6000, 1000, 1100, 35, 450, 30, 15, 30, 250, 75, 300, 35, 90, 30, 15};
            string[] urunaciklamalari = { "Intel Core i7 7700HQ 8GB 1TB + 128GB SSD GTX1050Ti Freedos 15.6 FHD Taşınabilir Bilgisayar" ,"Intel Core i7 7700HQ 8GB 1TB GTX1050Ti Freedos 15.6 FHD Masaüstü Bilgisayar", "9480 KM Neo Frost Buzdolabı", "9 KG 1200 DEVİR A+++ ENERJİ BEYAZ ÇAMAŞIR MAKİNA", "%55 Pamuk, %45 Polyester, Siyah, Klasik Model, Regular Fit", "Asetat : %59 Yun : % 41 Mono Yaka ", "0.7mm Versatil Kalem", " A4 140 Yp. Deri Kapak Spiralli Defter", "İç Cephe Boya 7.5 Lt", "18Volt/2,0Ah Li-ion Çift Akülü Profesyonel Darbeli Matkap", "Üretiminde cam elyaflı hammadde kullanılmıştır",  "1 adet camlı masa: 160x90x75 cm 4 adet sandalye: 55x48x92 cm" , "Beşiktaş Zebra Perde (Siyah/Beyaz) - 220x260 cm", "Microfiber Yorgan 115x225 cm", "1kg kuzu kuşbaşı", "500gr beyaz peynir" };
            cmbUyeOlCinsiyet.SelectedIndex = 0;
            for(int i=0; i<8;i++)
            {
                İkiliAramaAgacDugumu d = new İkiliAramaAgacDugumu();
                İkiliAramaAgacDugumu d2 = new İkiliAramaAgacDugumu();
                Urun u = new Urun();
                Urun u2 = new Urun();
                Kategori k = new Kategori();
                u.UrunAdi = urunadlari[j];
                u.Marka = urunmarkalari[j];
                u.Model = urunmodel[j];
                u.Miktar = urunmikar[j];
                u.Maliyet = urunmaliyet[j];
                u.SatisFiyati = urunsatisfiyati[j];
                u.Aciklaması = urunaciklamalari[j];
                u2.UrunAdi = urunadlari[j + 1];
                u2.Marka = urunmarkalari[j+1];
                u2.Model = urunmodel[j+1];
                u2.Miktar = urunmikar[j+1];
                u2.Maliyet = urunmaliyet[j+1];
                u2.SatisFiyati = urunsatisfiyati[j+1];
                u2.Aciklaması = urunaciklamalari[j+1];
                k.KategoriIsmi = kategoriler[i];
                k.Agac.Ekle(urunadlari[j]);
                k.Agac.Ara(urunadlari[j]).Urunler.Add(u);
                k.Agac.Ekle(urunadlari[j + 1]);
                k.Agac.Ara(urunadlari[j + 1]).Urunler.Add(u2);
                market.KategoriEkle(k);
                j += 2;
            }
        }

        private void btnUyeOl_Click(object sender, EventArgs e)
        {
            Musteri m = new Musteri();
            bool kontrol = false;
            foreach(Musteri mus in market.Musteriler)
            {
                if(mus.KullaniciAdi == txtUyeOlKullaniciAdi.Text)
                {
                    MessageBox.Show("Bu kullanıcı adı başka bir üye tarafından kullanılmaktadır.!");
                    kontrol = true;
                }
                
            
            }
            if(kontrol == false)
            {
                if (txtUyeOlAd.Text != "" && txtUyeOlSoyad.Text != "" && txtUyeOlKullaniciAdi.Text != "" && txtUyeOlSifre.Text != "")
                {
                    m.Ad = txtUyeOlAd.Text;
                    m.Soyad = txtUyeOlSoyad.Text;
                    m.Cinsiyet = cmbUyeOlCinsiyet.Text;
                    m.KullaniciAdi = txtUyeOlKullaniciAdi.Text;
                    if (txtUyeOlSifre.Text == txtUyeOlYenidenSifre.Text)
                    {
                        m.sifre = txtUyeOlSifre.Text;
                        market.Musteriler.Add(m);
                        MessageBox.Show("Üyeliğiniz Başarı İle Tamamlanmıştır..! \n İyi Alışverişler Dileriz.. :)) ");
                        txtUyeOlAd.Clear();
                        txtUyeOlSoyad.Clear();
                        txtUyeOlKullaniciAdi.Clear();
                        txtUyeOlSifre.Clear();
                        txtUyeOlYenidenSifre.Clear();
                    }
                    else
                        MessageBox.Show("Şifreler Uyuşmuyor.!");

                }
                else
                    MessageBox.Show("Girilen Bilgilerden herhangi biri boş geçilemez.!");
            }
            



        }

        

        
    }
}
