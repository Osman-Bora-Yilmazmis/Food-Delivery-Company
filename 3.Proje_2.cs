using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructers3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] mahalleler = { "KURUDERE MAHALLESİ", "SARNIÇKÖY MAHALLESİ", "KAYADİBİ MAHALLESİ", "ÇAMİÇİ MAHALLESİ", "BEŞYOL MAHALLESİ", "GÖKDERE MAHALLESİ", "ÇİÇEKLİ MAHALLESİ", "LAKA MAHALLESİ", "KARAÇAM MAHALLESİ", "YAKAKÖY MAHALLESİ" };//MAHALLELERİN LİSTESİ
            int[] nüfus = { 59, 81, 250, 265, 334, 392, 399, 432, 590, 1217 }; //NÜFUS LİSTESİ
            Hashtable table = new Hashtable(); //HASHTABLE OLUŞTURUR
            Console.WriteLine("Oluşturulan Hashtable:");
            for (int i = 0; mahalleler.Length > i; i++)
            {
                table[mahalleler[i]] = nüfus[i];//HASH TABLE'a EKLEME GERÇEKLEŞİR
                
            }
            for (int i = 0; mahalleler.Length > i; i++)
            {
                Console.WriteLine(mahalleler[i] + " " + table[mahalleler[i]]); //EKLENENLER EKRANA YAZDIRIRILIR
            }
            Console.WriteLine(" ");
            Console.WriteLine("Baş harfi girildikten sonra:");

            while (true)
            {
                char girilenharf = Console.ReadKey().KeyChar;
                Console.WriteLine(" ");
                for (int i = 0; mahalleler.Length > i; i++)
                {
                    if (mahalleler[i].ToLower().StartsWith(girilenharf.ToString()))
                    {
                        table[mahalleler[i]] = ++nüfus[i]; //BAŞ HARFİ GİRİLEN NÜFUS 1 ARTTIRILIR
                    }

                }
                for (int i = 0; mahalleler.Length > i; i++)
                {
                    Console.WriteLine(mahalleler[i] + "  " + table[mahalleler[i]]);//NÜFUS ARTTRILIDIKTAN SONRA OLUŞAN LİSTE EKRANA YAZDIRILIR
                }
                Console.WriteLine(" ");
                
            }
            


        }
    }
}
