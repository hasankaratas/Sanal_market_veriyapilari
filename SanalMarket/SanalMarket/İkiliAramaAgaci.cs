using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanalMarket
{
    public class İkiliAramaAgaci
    {
        public int geciciyukseklik = -1;
        public int yukseklik = -1;
        private İkiliAramaAgacDugumu kok;
        public ArrayList dugumler = new ArrayList();
        public İkiliAramaAgaci()
        {
        }
        public İkiliAramaAgaci(İkiliAramaAgacDugumu kok)
        {
            this.kok = kok;
        }
        public int DugumSayisi()
        {
            return DugumSayisi(kok);
        }
        public int DugumSayisi(İkiliAramaAgacDugumu dugum)
        {
            int count = 0;
            if (dugum != null)
            {
                count = 1;
                count += DugumSayisi(dugum.sol);
                count += DugumSayisi(dugum.sag);
            }
            return count;
        }
        public int YaprakSayisi()
        {
            geciciyukseklik = -1;
            yukseklik = -1;
            return YaprakSayisi(kok);
        }
        public int YaprakSayisi(İkiliAramaAgacDugumu dugum)
        {
            int count = 0;
            if (dugum != null)
            {
                if ((dugum.sol == null) && (dugum.sag == null))
                {
                    count = 1;
                    geciciyukseklik++;
                    if(geciciyukseklik>yukseklik)
                    {
                        yukseklik = geciciyukseklik;
                    }
                    geciciyukseklik = -1;
                }
                    
                else
                {
                    geciciyukseklik++;
                    count = count + YaprakSayisi(dugum.sol) + YaprakSayisi(dugum.sag);
                }

                    
            }
            return count;
        }
        public ArrayList DugumleriYazdir()
        {
            return dugumler;
        }
        public void PreOrder()
        {
            dugumler.Clear();
            PreOrderInt(kok);
        }
        private void PreOrderInt(İkiliAramaAgacDugumu dugum)
        {
            if (dugum == null)
                return;
            Ziyaret(dugum);
            PreOrderInt(dugum.sol);
            PreOrderInt(dugum.sag);
        }
        public void InOrder()
        {
            dugumler.Clear();
            InOrderInt(kok);

        }
        private void InOrderInt(İkiliAramaAgacDugumu dugum)
        {
            if (dugum == null)
            {
                return;
            }
            InOrderInt(dugum.sol);
            Ziyaret(dugum);
            InOrderInt(dugum.sag);
        }
        private void Ziyaret(İkiliAramaAgacDugumu dugum)
        {
            dugumler.Add(dugum);
        }
        public void PostOrder()
        {
            dugumler.Clear();
            PostOrderInt(kok);
        }
        private void PostOrderInt(İkiliAramaAgacDugumu dugum)
        {
            if (dugum == null)
                return;
            PostOrderInt(dugum.sol);
            PostOrderInt(dugum.sag);
            Ziyaret(dugum);
        }
        public ulong IdOlustur(string kelime)
        {
            string metin = "";
            int sayac = 0;

            foreach (char a in kelime)
            {
                switch (a)
                {
                    case 'a':
                        metin += "01";
                        break;
                    case 'A':
                        metin += "01";
                        break;
                    case 'b':
                        metin += "02";
                        break;
                    case 'B':
                        metin += "02";
                        break;
                    case 'c':
                        metin += "03";
                        break;
                    case 'C':
                        metin += "03";
                        break;
                    case 'ç':
                        metin += "04";
                        break;
                    case 'Ç':
                        metin += "04";
                        break;
                    case 'd':
                        metin += "05";
                        break;
                    case 'D':
                        metin += "05";
                        break;
                    case 'e':
                        metin += "06";
                        break;
                    case 'E':
                        metin += "06";
                        break;
                    case 'f':
                        metin += "07";
                        break;
                    case 'F':
                        metin += "07";
                        break;
                    case 'g':
                        metin += "08";
                        break;
                    case 'G':
                        metin += "08";
                        break;
                    case 'ğ':
                        metin += "09";
                        break;
                    case 'Ğ':
                        metin += "09";
                        break;
                    case 'h':
                        metin += "10";
                        break;
                    case 'H':
                        metin += "10";
                        break;
                    case 'ı':
                        metin += "11";
                        break;
                    case 'I':
                        metin += "11";
                        break;
                    case 'i':
                        metin += "12";
                        break;
                    case 'İ':
                        metin += "12";
                        break;
                    case 'j':
                        metin += "13";
                        break;
                    case 'J':
                        metin += "13";
                        break;
                    case 'k':
                        metin += "14";
                        break;
                    case 'K':
                        metin += "14";
                        break;
                    case 'l':
                        metin += "15";
                        break;
                    case 'L':
                        metin += "15";
                        break;
                    case 'm':
                        metin += "16";
                        break;
                    case 'M':
                        metin += "16";
                        break;
                    case 'n':
                        metin += "17";
                        break;
                    case 'N':
                        metin += "17";
                        break;
                    case 'o':
                        metin += "18";
                        break;
                    case 'O':
                        metin += "18";
                        break;
                    case 'ö':
                        metin += "19";
                        break;
                    case 'Ö':
                        metin += "19";
                        break;
                    case 'p':
                        metin += "20";
                        break;
                    case 'P':
                        metin += "20";
                        break;
                    case 'r':
                        metin += "21";
                        break;
                    case 'R':
                        metin += "21";
                        break;
                    case 's':
                        metin += "22";
                        break;
                    case 'S':
                        metin += "22";
                        break;
                    case 'ş':
                        metin += "23";
                        break;
                    case 'Ş':
                        metin += "23";
                        break;
                    case 't':
                        metin += "24";
                        break;
                    case 'T':
                        metin += "24";
                        break;
                    case 'u':
                        metin += "25";
                        break;
                    case 'U':
                        metin += "25";
                        break;
                    case 'ü':
                        metin += "26";
                        break;
                    case 'Ü':
                        metin += "26";
                        break;
                    case 'v':
                        metin += "27";
                        break;
                    case 'V':
                        metin += "27";
                        break;
                    case 'w':
                        metin += "28";
                        break;
                    case 'W':
                        metin += "28";
                        break;
                    case 'x':
                        metin += "29";
                        break;
                    case 'X':
                        metin += "29";
                        break;
                    case 'y':
                        metin += "30";
                        break;
                    case 'Y':
                        metin += "30";
                        break;
                    case 'z':
                        metin += "31";
                        break;
                    case 'Z':
                        metin += "31";
                        break;
                    default:
                        metin += "00";
                        break;
                }
                sayac++;
                if (sayac == 9)
                    break;
            }
            if (kelime.Length < 9)
            {
                for (int i = 0; i < 9 - kelime.Length; i++)
                {
                    metin += "00";
                }
            }
            
            return (Convert.ToUInt64(metin));

        }
        public void Ekle(string deger)
        {
            ulong tempId = IdOlustur(deger);
            İkiliAramaAgacDugumu tempParent = new İkiliAramaAgacDugumu();
            İkiliAramaAgacDugumu tempSearch = kok;

            while (tempSearch != null)
            {
                tempParent = tempSearch;
                if (tempId == tempSearch.id)
                    return;
                else if (tempId < tempSearch.id)
                    tempSearch = tempSearch.sol;
                else
                    tempSearch = tempSearch.sag;
            }
            İkiliAramaAgacDugumu eklenecek = new İkiliAramaAgacDugumu(deger, tempId);
            //Ağaç boş, köke ekle
            if (kok == null)
                kok = eklenecek;
            else if (tempId < tempParent.id)
                tempParent.sol = eklenecek;
            else
                tempParent.sag = eklenecek;
        }
        public İkiliAramaAgacDugumu Ara(string anahtar)
        {
            ulong x = IdOlustur(anahtar);
            return AraInt(kok, anahtar);
        }
        private İkiliAramaAgacDugumu AraInt(İkiliAramaAgacDugumu dugum,
                                            string anahtar)
        {
            ulong x = IdOlustur(anahtar);
            if (dugum == null)
                return null;
            else if (dugum.id == x)
                return dugum;
            else if (dugum.id > x)
                return (AraInt(dugum.sol, anahtar));
            else
                return (AraInt(dugum.sag, anahtar));
        }

        public İkiliAramaAgacDugumu MinDeger()
        {
            İkiliAramaAgacDugumu tempSol = kok;
            while (tempSol.sol != null)
                tempSol = tempSol.sol;
            return tempSol;
        }

        public İkiliAramaAgacDugumu MaksDeger()
        {
            İkiliAramaAgacDugumu tempSag = kok;
            while (tempSag.sag != null)
                tempSag = tempSag.sag;
            return tempSag;
        }

        private İkiliAramaAgacDugumu Successor(İkiliAramaAgacDugumu silDugum)
        {
            İkiliAramaAgacDugumu successorParent = silDugum;
            İkiliAramaAgacDugumu successor = silDugum;
            İkiliAramaAgacDugumu current = silDugum.sag;
            while (current != null)
            {
                successorParent = successor;
                successor = current;
                current = current.sol;
            }
            if (successor != silDugum.sag)
            {
                successorParent.sol = successor.sag;
                successor.sag = silDugum.sag;
            }
            return successor;
        }
        public bool Sil(string deger)
        {
            ulong x = IdOlustur(deger);
            İkiliAramaAgacDugumu current = kok;
            İkiliAramaAgacDugumu parent = kok;
            bool issol = true;
            //DÜĞÜMÜ BUL
            while (current.id != x)
            {
                parent = current;
                if (x < current.id)
                {
                    issol = true;
                    current = current.sol;
                }
                else
                {
                    issol = false;
                    current = current.sag;
                }
                if (current == null)
                    return false;
            }
            //DURUM 1: YAPRAK DÜĞÜM
            if (current.sol == null && current.sag == null)
            {
                if (current == kok)
                    kok = null;
                else if (issol)
                    parent.sol = null;
                else
                    parent.sag = null;
            }
            //DURUM 2: TEK ÇOCUKLU DÜĞÜM
            else if (current.sag == null)
            {
                if (current == kok)
                    kok = current.sol;
                else if (issol)
                    parent.sol = current.sol;
                else
                    parent.sag = current.sol;
            }
            else if (current.sol == null)
            {
                if (current == kok)
                    kok = current.sag;
                else if (issol)
                    parent.sol = current.sag;
                else
                    parent.sag = current.sag;
            }
            //DURUM 3: İKİ ÇOCUKLU DÜĞÜM
            else
            {
                İkiliAramaAgacDugumu successor = Successor(current);
                if (current == kok)
                    kok = successor;
                else if (issol)
                    parent.sol = successor;
                else
                    parent.sag = successor;
                successor.sol = current.sol;
            }
            return true;
        }

   
    }
}
