using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanalMarket
{
    public class Urun
    {
        public string UrunAdi;
        public string Marka;
        public string Model;
        public int Miktar;
        public double Maliyet;
        public double SatisFiyati;
        public string Aciklaması;
        public ArrayList Yorumlar = new ArrayList();
    }
}
