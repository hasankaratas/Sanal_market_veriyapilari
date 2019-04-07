using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanalMarket
{
    public class İkiliAramaAgacDugumu
    {
        public string veri;
        public ulong id;
        public İkiliAramaAgacDugumu sol;
        public İkiliAramaAgacDugumu sag;
        public ArrayList Urunler = new ArrayList();
        public İkiliAramaAgacDugumu()
        {
        }

        public İkiliAramaAgacDugumu(string veri, ulong id)
        {
            this.veri = veri;
            sol = null;
            sag = null;
            this.id = id;
        }
    }
}
