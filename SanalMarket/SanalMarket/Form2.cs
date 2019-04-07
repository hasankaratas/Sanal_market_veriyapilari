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
    public partial class Form2 : Form
    {
        
        public Musteri must;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listAra.Items.Clear();
            listAra.View = View.Details;
            int sayac = 0;
            bool urunkontrol = false;
            foreach (Kategori k in Form1.market.Kategoriler)
            {
                k.Agac.InOrder();
                foreach (İkiliAramaAgacDugumu d in k.Agac.dugumler)
                {
                    if (txtAdaGöreAra.Text == d.veri)
                    {

                        foreach (Urun u in d.Urunler)
                        {
                            urunkontrol = true;
                            listAra.Items.Add(k.KategoriIsmi);
                            listAra.Items[sayac].SubItems.Add(u.UrunAdi);
                            listAra.Items[sayac].SubItems.Add(u.Marka);
                            listAra.Items[sayac].SubItems.Add(u.Model);
                            listAra.Items[sayac].SubItems.Add(u.Miktar.ToString());
                            listAra.Items[sayac].SubItems.Add(u.SatisFiyati.ToString());
                            listAra.Items[sayac].SubItems.Add(u.Aciklaması);
                            sayac++;
                        }
                    }
                }
            }
            if (urunkontrol == false)
            {
                MessageBox.Show("Ürün Bulunamadı..!");
            }
        }

       
        private void Form2_Load(object sender, EventArgs e)
        {
            string temp = "Aşağıdaki siparişleriniz marketimize gelmiştir : \n";
            lblAdSoyad.Text = must.Ad + " " + must.Soyad;
            lblKullaniciAdi.Text = must.KullaniciAdi;
            comboBox1.SelectedIndex = 0;
            if(must.Bildirimler != null)
            {
                foreach(Urun u in must.Bildirimler)
                {
                    temp += ("Ürün Adı : " + u.UrunAdi + " Marka : " + u.Marka + " Model : " + u.Model + "\n");


                }
                must.Bildirimler.Clear();
                if(temp != "Aşağıdaki siparişleriniz marketimize gelmiştir : \n")
                MessageBox.Show(temp);
                
            }
            foreach (Kategori k in Form1.market.Kategoriler)
            {
                cmbUcuzKategori.Items.Add(k.KategoriIsmi);
                cmbKategoriler.Items.Add(k.KategoriIsmi);
            }
            cmbKategoriler.SelectedIndex = 0;
            cmbUcuzKategori.SelectedIndex = 0;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int sayac = 0;
            listUrunleriListele.Items.Clear();
            listUrunleriListele.View = View.Details;

            foreach (Kategori k in Form1.market.Kategoriler)
            {
                if (k.KategoriIsmi == cmbKategoriler.Text)
                {
                    if (comboBox1.Text == "Inorder")
                    {
                        k.Agac.InOrder();
                        labelControl6.Text = "Düğüm Sayısı : " + k.Agac.DugumSayisi().ToString();
                        k.Agac.YaprakSayisi();
                        labelControl15.Text = "Ağacın Derinliği : " + k.Agac.yukseklik.ToString();


                    }
                    else if (comboBox1.Text == "Preorder")
                    {
                        k.Agac.PreOrder();
                        labelControl6.Text = "Düğüm Sayısı : " + k.Agac.DugumSayisi().ToString();
                        k.Agac.YaprakSayisi();
                        labelControl15.Text = "Ağacın Derinliği : " + k.Agac.yukseklik.ToString();


                    }

                    else
                    {
                        k.Agac.PostOrder();
                        labelControl6.Text = "Düğüm Sayısı : " + k.Agac.DugumSayisi().ToString();
                        k.Agac.YaprakSayisi();
                        labelControl15.Text = "Ağacın Derinliği : " + k.Agac.yukseklik.ToString();

                    }

                    foreach (İkiliAramaAgacDugumu d in k.Agac.dugumler)
                    {

                        foreach (Urun u in d.Urunler)
                        {
                            listUrunleriListele.Items.Add(u.UrunAdi);
                            listUrunleriListele.Items[sayac].SubItems.Add(u.Marka);
                            listUrunleriListele.Items[sayac].SubItems.Add(u.Model);
                            listUrunleriListele.Items[sayac].SubItems.Add(u.Miktar.ToString());
                            listUrunleriListele.Items[sayac].SubItems.Add(u.SatisFiyati.ToString());
                            listUrunleriListele.Items[sayac].SubItems.Add(u.Aciklaması);
                            sayac++;
                        }
                    }


                }
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int sayac = 0;
            listUrunleriListele.Items.Clear();
            listUrunleriListele.View = View.Details;

            foreach (Kategori k in Form1.market.Kategoriler)
            {

                k.Agac.InOrder();
                foreach (İkiliAramaAgacDugumu d in k.Agac.dugumler)
                {
                    foreach (Urun u in d.Urunler)
                    {
                        if (Convert.ToInt32(txtKucukFiyat.Text) <= u.SatisFiyati && Convert.ToInt32(txtBuyukFiyat.Text) >= u.SatisFiyati)
                        {
                            listUrunleriListele.Items.Add(u.UrunAdi);
                            listUrunleriListele.Items[sayac].SubItems.Add(u.Marka);
                            listUrunleriListele.Items[sayac].SubItems.Add(u.Model);
                            listUrunleriListele.Items[sayac].SubItems.Add(u.Miktar.ToString());
                            listUrunleriListele.Items[sayac].SubItems.Add(u.SatisFiyati.ToString());
                            listUrunleriListele.Items[sayac].SubItems.Add(u.Aciklaması);
                            sayac++;
                        }
                    }
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            listGecmis.Items.Clear();
            listGecmis.View = View.Details;
            int sayac = 0;
            foreach (Musteri m in Form1.market.Musteriler)
            {
                if (m == must)
                {
                    foreach (Urun u in m.Gecmis)
                    {
                        listGecmis.Items.Add(u.UrunAdi);
                        listGecmis.Items[sayac].SubItems.Add(u.Marka);
                        listGecmis.Items[sayac].SubItems.Add(u.Model);
                        listGecmis.Items[sayac].SubItems.Add(u.Miktar.ToString());
                        listGecmis.Items[sayac].SubItems.Add(u.SatisFiyati.ToString());
                        listGecmis.Items[sayac].SubItems.Add(u.Aciklaması);
                        sayac++;
                    }
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listSepet.Items.Clear();
            listSepet.View = View.Details;
            int sayac = 0;
            double tutar = 0;
            foreach (Musteri m in Form1.market.Musteriler)
            {
                if (m == must)
                {
                    foreach (Urun u in m.Sepet)
                    {
                        listSepet.Items.Add(u.UrunAdi);
                        listSepet.Items[sayac].SubItems.Add(u.Marka);
                        listSepet.Items[sayac].SubItems.Add(u.Model);
                        listSepet.Items[sayac].SubItems.Add(u.Miktar.ToString());
                        listSepet.Items[sayac].SubItems.Add(u.SatisFiyati.ToString());
                        listSepet.Items[sayac].SubItems.Add(u.Aciklaması);
                        tutar = tutar+ (u.Miktar * u.SatisFiyati);
                        sayac++;
                    }
                }
            }
            labelControl7.Text = tutar.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            bool kontrol = false;
            Urun urun = new Urun();

            if (listUrunleriListele.SelectedItems.Count != 0)
            {
                ListViewItem item = listUrunleriListele.SelectedItems[0];
                urun.UrunAdi = item.SubItems[0].Text;
                urun.Marka = item.SubItems[1].Text;
                urun.Model = item.SubItems[2].Text;
                urun.Miktar = Convert.ToInt32(item.SubItems[3].Text);
                urun.Aciklaması = item.SubItems[5].Text;
                urun.SatisFiyati = Convert.ToInt32(item.SubItems[4].Text);
            }
            else
            {
                MessageBox.Show("Ürün Seçiniz..!");
            }
                

            foreach (Kategori k in Form1.market.Kategoriler)
            {
                k.Agac.InOrder();
                foreach (İkiliAramaAgacDugumu d in k.Agac.dugumler)
                {
                    if (d.veri == urun.UrunAdi)
                    {
                        foreach (Urun u in d.Urunler)
                        {
                            if (u.Marka == urun.Marka && u.Model == urun.Model)
                            {
                                urun.Maliyet = u.Maliyet;
                                foreach (Musteri m in Form1.market.Musteriler)
                                {
                                    if (m.KullaniciAdi == must.KullaniciAdi)
                                    {
                                        if (m.Sepet != null)
                                        {
                                            foreach (Urun uu in m.Sepet)
                                            {
                                                if (u.Marka == uu.Marka && u.Model == uu.Model)
                                                {
                                                    kontrol = true;
                                                    uu.Miktar++;
                                                    MessageBox.Show("Ürün Sepete Başarıyla Eklendi..!");
                                                }
                                            }
                                        }
                                        if (kontrol == false)
                                        {
                                            
                                            urun.Miktar = 1;
                                            m.Sepet.Add(urun);
                                            
                                            MessageBox.Show("Ürün Sepete Başarıyla Eklendi..!");
                                           
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool kontrol = false;
            Urun urun = new Urun();
            if (listAra.SelectedItems.Count != 0)
            {
                ListViewItem item = listAra.SelectedItems[0];
                urun.UrunAdi = item.SubItems[1].Text;
                urun.Marka = item.SubItems[2].Text;
                urun.Model = item.SubItems[3].Text;
                urun.Miktar = Convert.ToInt32(item.SubItems[4].Text);
                urun.Aciklaması = item.SubItems[6].Text;
                urun.SatisFiyati = Convert.ToInt32(item.SubItems[5].Text);
            }
            else
                MessageBox.Show("Ürün Seçiniz..!");
            foreach (Kategori k in Form1.market.Kategoriler)
            {
                k.Agac.InOrder();
                foreach (İkiliAramaAgacDugumu d in k.Agac.dugumler)
                {
                    if (d.veri == urun.UrunAdi)
                    {
                        foreach (Urun u in d.Urunler)
                        {
                            if (u.Marka == urun.Marka && u.Model == urun.Model)
                            {
                                urun.Maliyet = u.Maliyet;
                                foreach (Musteri m in Form1.market.Musteriler)
                                {
                                    if (m.KullaniciAdi == must.KullaniciAdi)
                                    {
                                        if (m.Sepet != null)
                                        {
                                            foreach (Urun uu in m.Sepet)
                                            {
                                                if (u.Marka == uu.Marka && u.Model == uu.Model)
                                                {
                                                    kontrol = true;
                                                    uu.Miktar++;
                                                    MessageBox.Show("Ürün Sepete Başarıyla Eklendi..!");
                                                }
                                            }
                                        }
                                        if (kontrol == false)
                                        {
                                            urun.Miktar = 1;
                                            m.Sepet.Add(urun);
                                            MessageBox.Show("Ürün Sepete Başarıyla Eklendi..!");
                                        }

                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Urun urun = new Urun();
            ListViewItem item;
            if (listSepet.SelectedItems.Count != 0)
            {
                item = listSepet.SelectedItems[0];
                urun.UrunAdi = item.SubItems[0].Text;
                urun.Marka = item.SubItems[1].Text;
                urun.Model = item.SubItems[2].Text;
                foreach (Musteri m in Form1.market.Musteriler)
                {
                    if (m.KullaniciAdi == must.KullaniciAdi)
                    {
                        foreach (Urun u in m.Sepet)
                        {
                            if (u.Marka == urun.Marka && u.Model == urun.Model)
                            {
                                m.Sepet.Remove(u);
                                item.Remove();
                                MessageBox.Show("Ürün Sepetten Silindi..!");
                                break;
                            }
                        }
                    }
                }
            }
            else
                MessageBox.Show("Ürün Seçiniz..!");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            bool miktarkontrol = false;
            bool satinalmabasarilimi = false;
            foreach (Musteri m in Form1.market.Musteriler)
            {
                if (m.KullaniciAdi == must.KullaniciAdi)
                {
                    foreach (Urun u in m.Sepet)
                    {
                        foreach (Kategori k in Form1.market.Kategoriler)
                        {
                            k.Agac.InOrder();
                            foreach (İkiliAramaAgacDugumu d in k.Agac.dugumler)
                            {
                                foreach (Urun u2 in d.Urunler)
                                {
                                    if (u2.Marka == u.Marka && u2.Model == u.Model)
                                    {
                                        if (u2.Miktar < u.Miktar)
                                        {
                                            miktarkontrol = true;
                                            break;
                                        }

                                    }
                                }
                            }
                        }

                    }
                }
            }
            if(miktarkontrol==true)
            {
                MessageBox.Show("Bu miktar stoğumuzda bulunmamaktadır..!");
            }
            else
            {
                foreach (Musteri m in Form1.market.Musteriler)
                {
                    if (m.KullaniciAdi == must.KullaniciAdi)
                    {
                        foreach (Urun u in m.Sepet)
                        {
                            foreach (Kategori k in Form1.market.Kategoriler)
                            {
                                k.Agac.InOrder();
                                foreach (İkiliAramaAgacDugumu d in k.Agac.dugumler)
                                {
                                    foreach (Urun u2 in d.Urunler)
                                    {
                                        if (u2.Marka == u.Marka && u2.Model == u.Model)
                                        {
                                           if(u2.Miktar>u.Miktar)
                                            {
                                                u2.Miktar=u2.Miktar - u.Miktar;
                                                Form1.gelir += (u.SatisFiyati) * u.Miktar;
                                                Form1.gider += (u.Maliyet) * u.Miktar;
                                                m.Gecmis.Add(u);
                                                satinalmabasarilimi = true;
                                                foreach (Urun u3 in m.Siparis)
                                                {
                                                    if(u3.UrunAdi ==u.UrunAdi && u3.Marka==u.Marka && u3.Model==u.Model)
                                                    {
                                                        m.Siparis.Remove(u3);
                                                        break;
                                                    }
                                                }
                                                
                                            }
                                           else if(u2.Miktar == u.Miktar)
                                            {
                                                Form1.gelir += (u.SatisFiyati) * u.Miktar;
                                                Form1.gider += (u.Maliyet) * u.Miktar;
                                                m.Gecmis.Add(u);
                                                satinalmabasarilimi = true;
                                                foreach (Urun u3 in m.Siparis)
                                                {
                                                    if (u3.UrunAdi == u.UrunAdi && u3.Marka == u.Marka && u3.Model == u.Model)
                                                    {
                                                        m.Siparis.Remove(u3);
                                                        break;
                                                    }
                                                }
                                                d.Urunler.Remove(u2);
                                                break;
                                            }

                                        }
                                    }
                                }
                            }

                        }
                    }
                    if(satinalmabasarilimi==true)
                    {
                        MessageBox.Show("Sepetteki Ürünler Satın Alındı..!");
                    }
                    
                    m.Sepet.Clear();
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            listUcuzUrun.Items.Clear();
            listUcuzUrun.View = View.Details;
            double tutar = 0;
            Heap h = new Heap(1000);
            HeapDugumu heap = new HeapDugumu();
            foreach(Kategori k in Form1.market.Kategoriler)
            {
                if(k.KategoriIsmi==cmbUcuzKategori.Text)
                {
                    k.Agac.InOrder();
                    foreach (İkiliAramaAgacDugumu d in k.Agac.dugumler)
                    {
                        foreach(Urun u in d.Urunler)
                        {
                            for(int j=0; j<u.Miktar;j++)
                              h.Insert(u);
                        }
                    }

                }
               
            }
            foreach(Musteri m in Form1.market.Musteriler)
            {
                if(m.KullaniciAdi==must.KullaniciAdi)
                {
                    if (h.currentSize >= Convert.ToUInt32(txtAdet.Text))
                    {
                        for (int i = 0; i < Convert.ToUInt32(txtAdet.Text); i++)
                        {

                            heap = h.RemoveMax();
                            if ((heap.urun.Miktar - 1) == 0)
                            {
                                foreach (Kategori k in Form1.market.Kategoriler)
                                {
                                    if (cmbUcuzKategori.Text == k.KategoriIsmi)
                                    {
                                        k.Agac.InOrder();
                                        foreach (İkiliAramaAgacDugumu d in k.Agac.dugumler)
                                        {
                                            foreach (Urun u in d.Urunler)
                                            {
                                                if (heap.urun.Marka == u.Marka && heap.urun.Model == u.Model)
                                                {
                                                    foreach (Urun u3 in m.Siparis)
                                                    {
                                                        if (u3.UrunAdi == u.UrunAdi && u3.Marka == u.Marka && u3.Model == u.Model)
                                                        {
                                                            m.Siparis.Remove(u3);
                                                            break;
                                                        }
                                                    }
                                                    m.Gecmis.Add(u);
                                                    Form1.gelir += u.SatisFiyati;
                                                    Form1.gider += u.Maliyet;
                                                    d.Urunler.Remove(u);
                                                    break;
                                                }
                                            }
                                        }
                                    }

                                }
                            }
                            else
                            {
                                foreach (Kategori k in Form1.market.Kategoriler)
                                {
                                    if (cmbUcuzKategori.Text == k.KategoriIsmi)
                                    {
                                        k.Agac.InOrder();
                                        foreach (İkiliAramaAgacDugumu d in k.Agac.dugumler)
                                        {
                                            foreach (Urun u in d.Urunler)
                                            {
                                                if (heap.urun.Marka == u.Marka && heap.urun.Model == u.Model)
                                                {
                                                    Urun u2 = new Urun();
                                                    u2.Maliyet = u.Maliyet;
                                                    u2.Marka = u.Marka;
                                                    u2.Miktar = 1;
                                                    u2.Model = u.Model;
                                                    u2.SatisFiyati = u.SatisFiyati;
                                                    u2.UrunAdi = u.UrunAdi;
                                                    u2.Aciklaması = u.Aciklaması;
                                                    u2.Miktar = 1;
                                                    u.Miktar--;
                                                    m.Gecmis.Add(u2);
                                                    Form1.gelir += u.SatisFiyati;
                                                    Form1.gider += u.Maliyet;
                                                    
                                                    break;
                                                }
                                            }
                                        }
                                    }

                                }
                            }

                            tutar += heap.urun.SatisFiyati;
                            listUcuzUrun.Items.Add(heap.urun.UrunAdi);
                            listUcuzUrun.Items[i].SubItems.Add(heap.urun.Marka);
                            listUcuzUrun.Items[i].SubItems.Add(heap.urun.Model);
                            listUcuzUrun.Items[i].SubItems.Add(1.ToString());
                            listUcuzUrun.Items[i].SubItems.Add(heap.urun.SatisFiyati.ToString());
                            listUcuzUrun.Items[i].SubItems.Add(heap.urun.Aciklaması);


                        }
                        lblUcuzTutar.Text = tutar.ToString();
                        MessageBox.Show("Listedeki Ürünler Başarı ile Alındı.!!");
                    }
                    else
                    {
                        MessageBox.Show("Bu kategoride bu kadar ürün mevcut değil..!");
                    }
                }
            }
           

            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            bool urunmevcutmu = false;
            if(txtSiparisMarka.Text !="" && txtSiparisModel.Text != "" && txtSiparisUrunAdi.Text != "")
            {
                foreach(Kategori k in Form1.market.Kategoriler)
                {
                    k.Agac.InOrder();
                    foreach(İkiliAramaAgacDugumu d in k.Agac.dugumler)
                    {
                        foreach(Urun u in d.Urunler)
                        {
                            if(u.UrunAdi==txtSiparisUrunAdi.Text && u.Marka==txtSiparisMarka.Text && u.Model==txtSiparisModel.Text)
                            {
                                urunmevcutmu = true;
                                MessageBox.Show("Bu ürün stoğumuzda mevcuttur..!");
                            }
                        }
                    }

                }
                if(urunmevcutmu == false)
                {
                    foreach (Musteri m in Form1.market.Musteriler)
                    {
                        if (m.KullaniciAdi == must.KullaniciAdi)
                        {
                            Urun u = new Urun();
                            u.UrunAdi = txtSiparisUrunAdi.Text;
                            u.Marka = txtSiparisMarka.Text;
                            u.Model = txtSiparisModel.Text;
                            MessageBox.Show("Talebiniz Kayıt Edildi..! Ürün Gelirse Size Bilgi Verilecektir..!");
                            m.Siparis.Add(u);

                        }
                    }
                }
               
            }
            else
                MessageBox.Show("Bilgiler boş geçilemez..!");
            txtSiparisUrunAdi.Clear();
            txtSiparisMarka.Clear();
            txtSiparisModel.Clear();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            listSiparisler.Items.Clear();
            listSiparisler.View = View.Details;
            int sayac = 0;
            foreach(Urun u in must.Siparis)
            {
                listSiparisler.Items.Add(u.UrunAdi);
                listSiparisler.Items[sayac].SubItems.Add(u.Marka);
                listSiparisler.Items[sayac].SubItems.Add(u.Model);
                sayac++;
            }
           
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Urun urun = new Urun();
            if (listGecmis.SelectedItems.Count != 0)
            {
                ListViewItem item = listGecmis.SelectedItems[0];
                urun.UrunAdi = item.SubItems[0].Text;
                urun.Marka = item.SubItems[1].Text;
                urun.Model = item.SubItems[2].Text;
                urun.Miktar = Convert.ToInt32(item.SubItems[3].Text);
                urun.Aciklaması = item.SubItems[5].Text;
                urun.SatisFiyati = Convert.ToInt32(item.SubItems[4].Text);

            }
            else
                MessageBox.Show("Ürün Seçiniz..!");

            if(txtYorum.Text =="")
            {
                MessageBox.Show("Yorum boş olamaz..!");
            }
            else
            {
                foreach(Kategori k in Form1.market.Kategoriler)
                {
                    k.Agac.InOrder();
                    foreach(İkiliAramaAgacDugumu d in k.Agac.dugumler)
                    {
                        foreach(Urun u in d.Urunler)
                        {
                            if(u.UrunAdi==urun.UrunAdi && u.Marka==urun.Marka && u.Model==urun.Model)
                            {
                                MessageBox.Show("Yorum Başarıyla Eklendi..!");
                                u.Yorumlar.Add(txtYorum.Text);
                                break;
                            }
                        }
                    }
                }
            }
            txtYorum.Clear();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            listYorumlar.Items.Clear();
            listYorumlar.View = View.Details;
            Urun urun = new Urun();
            if (listAra.SelectedItems.Count != 0)
            {
                ListViewItem item = listAra.SelectedItems[0];
                urun.UrunAdi = item.SubItems[1].Text;
                urun.Marka = item.SubItems[2].Text;
                urun.Model = item.SubItems[3].Text;
                urun.Miktar = Convert.ToInt32(item.SubItems[4].Text);
                urun.Aciklaması = item.SubItems[6].Text;
                urun.SatisFiyati = Convert.ToInt32(item.SubItems[5].Text);

            }
            else
                MessageBox.Show("Ürün Seçiniz..!");
            foreach(Kategori k in Form1.market.Kategoriler)
            {
                k.Agac.InOrder();
                foreach(İkiliAramaAgacDugumu d in k.Agac.dugumler)
                {
                    foreach(Urun u in d.Urunler)
                    {
                        if(urun.UrunAdi==u.UrunAdi && urun.Marka==u.Marka && urun.Model == u.Model)
                        {
                            foreach(string i in u.Yorumlar)
                            {
                               
                                listYorumlar.Items.Add(i);
                            }
                            
                        }
                    }
                }
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            listYorumlar2.Items.Clear();
            listYorumlar2.View = View.Details;
            Urun urun = new Urun();
            if (listUrunleriListele.SelectedItems.Count != 0)
            {
                ListViewItem item = listUrunleriListele.SelectedItems[0];
                urun.UrunAdi = item.SubItems[0].Text;
                urun.Marka = item.SubItems[1].Text;
                urun.Model = item.SubItems[2].Text;
                urun.Miktar = Convert.ToInt32(item.SubItems[3].Text);
                urun.Aciklaması = item.SubItems[5].Text;
                urun.SatisFiyati = Convert.ToInt32(item.SubItems[4].Text);

            }
            else
                MessageBox.Show("Ürün Seçiniz..!");
            foreach (Kategori k in Form1.market.Kategoriler)
            {
                k.Agac.InOrder();
                foreach (İkiliAramaAgacDugumu d in k.Agac.dugumler)
                {
                    foreach (Urun u in d.Urunler)
                    {
                        if (urun.UrunAdi == u.UrunAdi && urun.Marka == u.Marka && urun.Model == u.Model)
                        {
                            foreach (string i in u.Yorumlar)
                            {
                                listYorumlar2.Items.Add(i);
                            }

                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool varmi = false;
            int sayac = 0;
            listAra.Items.Clear();
            listAra.View = View.Details;
            HashMap hashTable = new HashMap();
            foreach(Kategori k in Form1.market.Kategoriler)
            {
                k.Agac.InOrder();
                foreach(İkiliAramaAgacDugumu d in k.Agac.dugumler)
                {
                    foreach(Urun u in d.Urunler)
                    {
                        hashTable.AddUrun(u.Aciklaması, u);
                    }
                }
            }
            hashTable.GetUrun(txtKelimeyeGöreAra.Text);
            if(hashTable.BulunanUrunler !=null)
            {
                foreach (Kategori k in Form1.market.Kategoriler)
                {
                    k.Agac.InOrder();
                    foreach (İkiliAramaAgacDugumu d in k.Agac.dugumler)
                    {
                        foreach (Urun urun2 in hashTable.BulunanUrunler)
                        {
                            foreach (Urun urun3 in d.Urunler)
                            {
                                if (urun2.Marka == urun3.Marka && urun2.Model == urun3.Model)
                                {
                                    varmi = true;
                                    listAra.Items.Add(k.KategoriIsmi);
                                    listAra.Items[sayac].SubItems.Add(urun2.UrunAdi);
                                    listAra.Items[sayac].SubItems.Add(urun2.Marka);
                                    listAra.Items[sayac].SubItems.Add(urun2.Model);
                                    listAra.Items[sayac].SubItems.Add(urun2.Miktar.ToString());
                                    listAra.Items[sayac].SubItems.Add(urun2.SatisFiyati.ToString());
                                    listAra.Items[sayac].SubItems.Add(urun2.Aciklaması);
                                    sayac++;
                                }
                            }
                        }
                    }
                }
            }
            if(varmi == false)
                MessageBox.Show("KAYIT BULUNAMADI..!");

            txtKelimeyeGöreAra.Clear();


        }
    }
}
