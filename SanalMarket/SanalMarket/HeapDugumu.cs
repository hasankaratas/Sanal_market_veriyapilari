using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanalMarket
{
    public class HeapDugumu
    { 
        public Urun urun { get; set; }
        public HeapDugumu()
        {

        }
        public HeapDugumu(Urun u)
        {
            this.urun = u;
        }
    }
}
