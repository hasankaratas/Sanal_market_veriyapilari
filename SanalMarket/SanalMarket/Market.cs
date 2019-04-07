using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanalMarket
{
    public class Market
    {
        public Kategori mKategori = new Kategori();
        public ArrayList Kategoriler = new ArrayList();
        public List<Musteri> Musteriler = new List<Musteri>();
        public void KategoriEkle(Kategori kat)
        {
           
            Kategoriler.Add(kat);
        }
    }
}
