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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kategori k2 = new Kategori();
            Urun u2 = new Urun();
            k2.KategoriIsmi = txtKategori.Text;
            u2.UrunAdi = txtUrunAdi.Text;
            u2.Marka = txtMarka.Text;
            u2.Model = txtModel.Text;
            u2.Miktar = Convert.ToInt32(txtMiktar.Text);
            u2.Maliyet = Convert.ToInt32(txtMaliyet.Text);
            u2.SatisFiyati = Convert.ToInt32(txtSatisFiyati.Text);
            u2.Aciklaması = txtUrunAciklamasi.Text;
            bool katkontrol = false;
            bool adkontrol = false;
            bool modelkontrol = false;
            bool uruneklendimi = false;
            if (txtKategori.Text !="" && txtMaliyet.Text !="" && txtMarka.Text != "" && txtMiktar.Text != "" && txtModel.Text != "" && txtSatisFiyati.Text != "" && txtUrunAciklamasi.Text != "" && txtUrunAdi.Text !="" )
            {
                foreach(Kategori k in Form1.market.Kategoriler)
                {
                    if(txtKategori.Text == k.KategoriIsmi)
                    {
                        katkontrol = true;
                        k.Agac.InOrder();
                        foreach(İkiliAramaAgacDugumu d in k.Agac.dugumler)
                        {
                            if(txtUrunAdi.Text == d.veri)
                            {
                                adkontrol = true;
                                foreach(Urun u in d.Urunler)
                                {
                                    if(u.Marka == txtMarka.Text && u.Model == txtModel.Text)
                                    {
                                        modelkontrol = true;
                                        MessageBox.Show("Bu Ürün Mevcut Ürün Bilgileri Hakkında Değişiklik İçin Güncelleme Bölümüne Gidiniz..!");
                                    }

                                }
                                if(modelkontrol==false)
                                {
                                    d.Urunler.Add(u2);
                                    MessageBox.Show("Ürün Eklendi..!");
                                    uruneklendimi = true;
                                }
                            }
                            
                        }
                       if(adkontrol==false)
                        {
                            
                            k.Agac.Ekle(txtUrunAdi.Text);
                            k.Agac.Ara(txtUrunAdi.Text).Urunler.Add(u2);
                            MessageBox.Show("Ürün Eklendi..!");
                            uruneklendimi = true;
                        }
                    }
                    
                }
                if (katkontrol == false)
                {
                    Form1.market.Kategoriler.Add(k2);
                    foreach(Kategori k in Form1.market.Kategoriler)
                    {
                        if(k.KategoriIsmi== txtKategori.Text)
                        {
                           
                            k.Agac.Ekle(txtUrunAdi.Text);
                            k.Agac.Ara(txtUrunAdi.Text).Urunler.Add(u2);
                            MessageBox.Show("Ürün Eklendi..!");
                            uruneklendimi = true;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Boş Geçemezsiniz..!! ");
            }
            if(uruneklendimi==true)
            {
                foreach(Musteri m in Form1.market.Musteriler)
                {
                    foreach(Urun u in m.Siparis)
                    {
                        if(u.Marka==u2.Marka && u.UrunAdi==u2.UrunAdi && u.Model==u2.Model)
                        {
                            m.Bildirimler.Add(u2);
                        }
                    }
                }
            }
            txtKategori.Clear();
            txtUrunAdi.Clear();
            txtMarka.Clear();
            txtModel.Clear();
            txtMiktar.Clear();
            txtMaliyet.Clear();
            txtSatisFiyati.Clear();
            txtUrunAciklamasi.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bool kontrol = false;
            listUrunleriListele2.Items.Clear();
            listUrunleriListele2.View = View.Details;
            int sayac = 0;
            foreach(Kategori k in Form1.market.Kategoriler)
            {
                if(k.Agac.Ara(txtAra.Text) != null)
                {
                    foreach (Urun u in k.Agac.Ara(txtAra.Text).Urunler)
                    {
                        kontrol = true;
                        listUrunleriListele2.Items.Add(k.KategoriIsmi);
                        listUrunleriListele2.Items[sayac].SubItems.Add(u.UrunAdi);
                        listUrunleriListele2.Items[sayac].SubItems.Add(u.Marka);
                        listUrunleriListele2.Items[sayac].SubItems.Add(u.Model);
                        listUrunleriListele2.Items[sayac].SubItems.Add(u.Miktar.ToString());
                        listUrunleriListele2.Items[sayac].SubItems.Add(u.Maliyet.ToString());
                        listUrunleriListele2.Items[sayac].SubItems.Add(u.SatisFiyati.ToString());
                        listUrunleriListele2.Items[sayac].SubItems.Add(u.Aciklaması);
                        sayac++;
                    }
                }
                
               
            }
            if (kontrol == false)
            {
                MessageBox.Show("Ürün Bulunamadı..!");
            }
            txtAra.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool kontrol = false;
            if (txtKategori.Text != "" && txtUrunAdi.Text != "" && txtMarka.Text != "" && txtModel.Text != "")
            {
                foreach (Kategori k in Form1.market.Kategoriler)
                {
                    if (k.KategoriIsmi == txtKategori.Text)
                    {
                        foreach (Urun u in k.Agac.Ara(txtUrunAdi.Text).Urunler)
                        {
                            if (u.Marka == txtMarka.Text && u.Model == txtModel.Text)
                            {
                                kontrol = true;
                                k.Agac.Ara(txtUrunAdi.Text).Urunler.Remove(u);
                                MessageBox.Show("Ürün Silindi..!");
                                break;
                            }
                        }

                    }
                }
                if(kontrol==false)
                {
                    MessageBox.Show("Ürün Bulunamadı..!");
                }
            }
           else
                MessageBox.Show("Kategori İsmi, Ürün Adı, Marka, Model Bölümleri Boş Geçilemez! ");

            txtKategori.Clear();
            txtUrunAdi.Clear();
            txtMarka.Clear();
            txtModel.Clear();
            txtMiktar.Clear();
            txtMaliyet.Clear();
            txtSatisFiyati.Clear();
            txtUrunAciklamasi.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Kategori k in Form1.market.Kategoriler)
            {
                comboBox1.Items.Add(k.KategoriIsmi);
            }
            comboBox1.SelectedIndex = 0;
            bool kontrol = false;
            foreach (Kategori k in Form1.market.Kategoriler)
            {
                if (k.Agac.Ara(txtKategoriGüncelle.Text) != null)
                {
                    kontrol = true;
                    lblKategoriAdi.Text=k.KategoriIsmi;
                }
            }
            if (kontrol == false)
            {
                MessageBox.Show("Ürün Bulunamadı..!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bool kontrol = false;
            İkiliAramaAgacDugumu temp = new İkiliAramaAgacDugumu();
            foreach (Kategori k in Form1.market.Kategoriler)
            {
                if (k.Agac.Ara(txtKategoriGüncelle.Text) != null)
                {
                    
                    temp.veri = k.Agac.Ara(txtKategoriGüncelle.Text).veri;
                    temp.Urunler = k.Agac.Ara(txtKategoriGüncelle.Text).Urunler;
                    k.Agac.Sil(txtKategoriGüncelle.Text);
                }
            }
            foreach (Kategori k in Form1.market.Kategoriler)
            {
                if(comboBox1.Text==k.KategoriIsmi)
                {
                    k.Agac.Ekle(temp.veri);
                    foreach (Urun u in temp.Urunler)
                    {
                        kontrol = true;
                        k.Agac.Ara(temp.veri).Urunler.Add(u);
                    }
                    if(kontrol==true)
                        MessageBox.Show("Kategori Başarıyla Güncellenmiştir...");
                    else
                        MessageBox.Show("Güncelleme Başarısız Oldu..!");
                }
            }
            txtKategoriGüncelle.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(txtAranacakMarka.Text !="" && txtAranacakModel.Text !="")
            {
                foreach(Kategori k in Form1.market.Kategoriler)
                {
                    k.Agac.InOrder();
                    foreach(İkiliAramaAgacDugumu d in k.Agac.dugumler)
                    {
                        foreach(Urun u in d.Urunler)
                        {
                            if(txtAranacakMarka.Text == u.Marka && txtAranacakModel.Text == u.Model)
                            {
                                txtYeniMarka.Text = u.Marka;
                                txtYeniMiktar.Text = u.Miktar.ToString();
                                txtYeniModel.Text = u.Model;
                                txtYeniSatisFiyati.Text = u.SatisFiyati.ToString();

                            }
                        }
                    }
                }
            }
            else
                MessageBox.Show("Boş Geçilemez..!");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (txtYeniMarka.Text != "" && txtYeniMiktar.Text != "" && txtYeniModel.Text != "" && txtYeniSatisFiyati.Text != "")
            {
                foreach (Kategori k in Form1.market.Kategoriler)
                {
                    k.Agac.InOrder();
                    foreach (İkiliAramaAgacDugumu d in k.Agac.dugumler)
                    {
                        foreach (Urun u in d.Urunler)
                        {
                            if (txtAranacakMarka.Text == u.Marka && txtAranacakModel.Text == u.Model)
                            {
                                u.Marka = txtYeniMarka.Text;
                                u.Miktar =Convert.ToInt32(txtYeniMiktar.Text);
                                u.Model = txtYeniModel.Text;
                                u.SatisFiyati = Convert.ToInt32(txtYeniSatisFiyati.Text);
                                MessageBox.Show("Başarıyla Güncellenmiştir..!");
                                foreach(Musteri m in Form1.market.Musteriler)
                                {
                                    foreach(Urun uu in m.Siparis)
                                    {
                                        if(uu.UrunAdi == u.UrunAdi && uu.Marka==u.Marka && uu.Model==u.Model)
                                        {
                                            m.Bildirimler.Add(uu);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
                MessageBox.Show("Boş Geçilemez..!");

            txtYeniMarka.Clear();
            txtYeniMiktar.Clear();
            txtYeniModel.Clear();
            txtYeniSatisFiyati.Clear();
            txtAranacakMarka.Clear();
            txtAranacakModel.Clear();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            lblGelir.Text = Form1.gelir.ToString();
            lblGider.Text = Form1.gider.ToString();
            lblKar.Text = (Form1.gelir - Form1.gider).ToString();

        }
    }
}
