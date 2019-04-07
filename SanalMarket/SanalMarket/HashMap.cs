using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanalMarket
{
    public class HashMap
    {
        int urunsayisi = 0;
        public ArrayList BulunanUrunler = new ArrayList();
        int TABLE_SIZE = 1000;
        HashEntry[] table;

        public HashMap()
        {
            table = new HashEntry[TABLE_SIZE];
            for (int i = 0; i < TABLE_SIZE; i++)
                table[i] = null;
        }
        public void AddUrun(string key, Urun urun)
        {
            int j = 0;
            int[] hashVal =  new int[10000];
            string[] kelimeler = new string[10000];
            for (int i = 0; i < key.Length; i++)
            {
                if (key[i] == ' ' || key[i] == ',')
                {
                    j++;
                    continue;
                }
                    
                kelimeler[j] += key[i];
                hashVal[j] += key[i];
            }
            
         
            for(int k=0; k<=j; k++)
            {
                hashVal[k] = (hashVal[k] % TABLE_SIZE);
                while (table[hashVal[k]] != null && table[hashVal[k]].Anahtar != key)
                    hashVal[k] = (hashVal[k] + 1) % TABLE_SIZE;
                urunsayisi++;
                table[hashVal[k]] = new HashEntry(kelimeler[k] , urun);
            }
            

        }
        public Urun GetUrun(string key)
        {
            int sayac = 0;
            int hashVal = 0;
            for (int i = 0; i < key.Length; i++)
            {
                hashVal += key[i];
            }
            hashVal = (hashVal % TABLE_SIZE);
            while (table[hashVal] != null && sayac != urunsayisi)
            {
                if(table[hashVal].Anahtar == key)
                {
                    BulunanUrunler.Add((Urun)table[hashVal].Deger);
                }
                hashVal = (hashVal + 1) % TABLE_SIZE;
            }
               
            if (table[hashVal] == null)
                return null;
            else
                return (Urun)table[hashVal].Deger;
        }


    }
}
