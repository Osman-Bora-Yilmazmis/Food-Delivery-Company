using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datastructers3_1
{
    class TreeNode // TREENODE SINIFIM
    {
        public MahalleSınıfı Mahalle;
        public TreeNode leftChild;
        public TreeNode rightChild;
        public void displayNode()
        { Console.Write(" " + Mahalle + " "); }
    }
    class Tree //TREE SINIFIM
    {
        public TreeNode root;      
        public void insert(MahalleSınıfı newdata)//AĞACA ELEMAN EKLEYEN METOD
        {
            TreeNode newNode = new TreeNode();
            newNode.Mahalle = newdata;
            if (root == null)
                root = newNode;
            else
            {
                TreeNode current = root;
                TreeNode parent;
                while (true)
                {
                    parent = current;
                    if (newdata.MahalleAdi.CompareTo(current.Mahalle.MahalleAdi)<0)
                    {
                        current = current.leftChild;
                        if (current == null)
                        {
                            parent.leftChild = newNode;
                            return;
                        }
                    }
                    else
                    {
                        current = current.rightChild;
                        if (current == null)
                        {
                            parent.rightChild = newNode;
                            return;
                        }
                    }
                } 
            }
        }
        public int Derinlikbul(int derinlik ,TreeNode Node)//DERİNLİK BULDURAN VE DÖNDÜREN METOD
        {
            Console.WriteLine("Mahalle : " + Node.Mahalle.MahalleAdi);
            int sağderinlik = derinlik;
            int solderinlik = derinlik;
            if( Node.rightChild != null)
            {
                sağderinlik = Derinlikbul(derinlik+1, Node.rightChild);
            }

            if (Node.leftChild != null)
            {
                solderinlik = Derinlikbul(derinlik + 1, Node.leftChild);
            }
            if(sağderinlik < solderinlik) { return solderinlik; }
            return sağderinlik;

        }
        public void MahalleBuldur(TreeNode Node, string Mahalleadi)//MAHALLEDEKİ TOPLAM SİPARİŞLERİ BULDURAN METOD
        {
            if (Node == null) { return; }
            if (Node.Mahalle.MahalleAdi == Mahalleadi)
            {
                Node.Mahalle.YüzelliBulYazdir();
            }
            else
            {
                MahalleBuldur(Node.leftChild, Mahalleadi);
                MahalleBuldur(Node.rightChild, Mahalleadi);
            }
        }
        public int YemekAdedi(TreeNode Node ,string yemekadi )//ADI GİRİLEN YEMEĞİN AĞAÇTAKİ SAYISINI BULAN VE DÖNDÜREN METOD
        {
            int toplamYemekAdedi = 0;
            foreach(SiparişlerSınıfı siparis in Node.Mahalle.SiparişBilgileri)
            {
                foreach(YemekSınıfı yemek in siparis.SiparişBilgileri)
                {
                    if(yemek.yemek == yemekadi)
                    {
                        toplamYemekAdedi += yemek.yemeksayisi;
                        yemek.fiyat = yemek.fiyat * 0.9;
                    }
                }
            }
   
            if (Node.rightChild != null)
            {
                toplamYemekAdedi += YemekAdedi(Node.rightChild, yemekadi);
                
                
            }

            if (Node.leftChild != null)
            {
                toplamYemekAdedi +=  YemekAdedi(Node.leftChild, yemekadi);
            }
            
            return toplamYemekAdedi;

        }

    }

    class YemekSınıfı //YEMEK SINIFIM
    {
        public string yemek;
        public int yemeksayisi;
        public double fiyat;
        
        public YemekSınıfı(string yemek, int yemeksayisi,double fiyat)
        {
            this.yemek = yemek;
            this.yemeksayisi = yemeksayisi;
            this.fiyat = fiyat;
        }
    }
    class MahalleSınıfı //MAHALLE SINIFIM
    {
        public string MahalleAdi;
        public List<SiparişlerSınıfı> SiparişBilgileri = new List<SiparişlerSınıfı>();

        public MahalleSınıfı(string mahalleadi)
        {
            this.MahalleAdi = mahalleadi;
        }
        public void YüzelliBulYazdir()
        {
            foreach(SiparişlerSınıfı siparişler in SiparişBilgileri)
            {
                if(siparişler.ToplamÜcret()> 150)
                {
                    
                    foreach(YemekSınıfı yemek in siparişler.SiparişBilgileri)
                    {
                        Console.WriteLine("Yemek Bilgileri: " + yemek.yemek + "    "+ yemek.fiyat+ " TL");
                    }
                }
            }
        }
    }
    class SiparişlerSınıfı //SİPARİŞLER SINIFIM
    {
        public List<YemekSınıfı> SiparişBilgileri = new List<YemekSınıfı>();
        public double ToplamÜcret() //TOPLAM ÜCRETİ BULDURAN METOD 
        {
            double toplamücret = 0;
            for(int i = 0; SiparişBilgileri.Count > i; i++)
            {
                toplamücret += SiparişBilgileri[i].fiyat * SiparişBilgileri[i].yemeksayisi;
            }
            return toplamücret;
        }
    }
    
    class Program
    {
        static Random Rastgele = new Random();//RANDOM METODUM
        static string[] mahalleler = { "Evka 3","Özkanlar", "Atatürk", "Erzene", "Kazımdirik" }; //MAHALLE LİSTESİ
        static string[] yemeklerim = { "nohutlu tavuk", "dana rosto", "spagetti ", "yoğurtlu makarna", "bulgur pilavı", "pilav", "salçalı tavuk", "hatay dürüm", "izmir kumrusu", "küfte", "mantı", "hotdog", "Sucuklu Şahanem" }; //YEMEKLERİN LİSTESİ
        static double[] fiyatlar = { 20, 50 , 100 , 25 , 250 , 5 , 17, 97, 70, 3.50, 2.50 , 63 , 90 , 10 }; //FİYATLARIN LİSTESİ
        static void Main(string[] args)
        {
            Tree MahalleNesnesi = new Tree();
            List<SiparişlerSınıfı> SiparişlerListesi = new List<SiparişlerSınıfı>();
            for (int i = 0; mahalleler.Length > i; i++)
            {
                MahalleSınıfı Mahalle = new MahalleSınıfı(mahalleler[i]);
                int sayi = Rastgele.Next(2,4);
                

                for (int b = 0; sayi> b; b++)
                {
                    SiparişlerSınıfı Siparişler = new SiparişlerSınıfı();
             
                    for(int c = 0; yemeklerim.Length> c; c++)
                    {
                        string rastgeleyemek = yemeklerim[Rastgele.Next(0, yemeklerim.Length)]; //YEMEKLERİM LİSTESİNDEN RASTGELE YEMEKLER OLUŞTURULUR
                        int rastgeleyemeksayisi = Rastgele.Next(1, 8); //YEMEKLERİN SAYISI İCİN RASTGELE YEMEK SAYİSİ OLSUTURULUR
                        double rastgelefiyat = fiyatlar[Rastgele.Next(0, fiyatlar.Length)]; //FİYATLAR LİSTESİNDEN RASTGELE FİYATLAR OLUŞTURULUR
                        YemekSınıfı yemek = new YemekSınıfı(rastgeleyemek, rastgeleyemeksayisi, rastgelefiyat);
                        Siparişler.SiparişBilgileri.Add(yemek); //TESLİMAT OLUSTUKTAN SONRA İLGİLİ SİPARİSE GONDERİLİR
                    }
                    Mahalle.SiparişBilgileri.Add(Siparişler);
                }
                if(i == 2)
                {
                    Console.WriteLine("Atatürk Mahallesi İçin 150 TL'nin üzerindeki siparişlerin bilgileri ");
                    Mahalle.YüzelliBulYazdir();
                }
                MahalleNesnesi.insert(Mahalle);
            }
            Console.WriteLine(" ");
            int derinlik = MahalleNesnesi.Derinlikbul(0, MahalleNesnesi.root);
            Console.WriteLine(" ");
            Console.WriteLine(" Derinlik : " + derinlik);
            Console.WriteLine(" ");
            Console.WriteLine("Evka 3 Mahallesi Siparişler:");
            MahalleNesnesi.MahalleBuldur(MahalleNesnesi.root, "Evka 3");
            Console.WriteLine(" ");
            Console.WriteLine("Özkanlar Mahallesi Siparişler:");
            MahalleNesnesi.MahalleBuldur(MahalleNesnesi.root, "Özkanlar");
            Console.WriteLine(" ");
            Console.WriteLine("Atatürk Mahallesi Siparişler:");
            MahalleNesnesi.MahalleBuldur(MahalleNesnesi.root, "Atatürk");
            Console.WriteLine(" ");
            Console.WriteLine("Erzene Mahallesi Siparişler:");
            MahalleNesnesi.MahalleBuldur(MahalleNesnesi.root, "Erzene");
            Console.WriteLine(" ");
            Console.WriteLine("Kazımdirik Mahallesi Siparişler:");
            MahalleNesnesi.MahalleBuldur(MahalleNesnesi.root, "Kazımdirik");
            
            Console.WriteLine(" ");
            Console.WriteLine("Güncelleştirildikten sonra ");
            Console.WriteLine("Küfte Adedi :  "+MahalleNesnesi.YemekAdedi(MahalleNesnesi.root, "küfte"));
            MahalleNesnesi.MahalleBuldur(MahalleNesnesi.root, "Kazımdirik");

            Console.ReadLine();










        }
    }
}
