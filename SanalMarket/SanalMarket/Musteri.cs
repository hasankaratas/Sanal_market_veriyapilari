using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanalMarket
{
    public class Musteri
    {
        public string Ad;
        public string Soyad;
        public string KullaniciAdi;
        private string Sifre;
        public ArrayList Sepet = new ArrayList();
        public ArrayList Gecmis = new ArrayList();
        public ArrayList Siparis = new ArrayList();
        public ArrayList Bildirimler = new ArrayList();
        public string sifre
        {
            set { Sifre = value; }
        }

        public string Cinsiyet;

        public bool SifreKontrol(string parola)
        {
            if (parola == Sifre)
                return true;
            else
                return false;
        }
    }
}
