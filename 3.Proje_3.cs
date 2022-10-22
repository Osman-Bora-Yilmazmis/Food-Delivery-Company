using System;

namespace DataStructers3_3
{
    class MahalleSınıfı //MAHALLE SINIFI
    {
        public int nüfussayisi;
        public string Mahalleadi;

        public MahalleSınıfı(int nüfussayisi, string Mahalleadi)
        {
            this.nüfussayisi = nüfussayisi;
            this.Mahalleadi = Mahalleadi;
        }
    }
    class Heap //HEAP VERİ YAPISI
    {
        int maxSize;
        int currentSize = 0;
        MahalleSınıfı[] array;
        public Heap(int maxSize)
        {
            this.maxSize = maxSize;
            array = new MahalleSınıfı[maxSize];
        }
        public bool insert(MahalleSınıfı key) //İLGİLİ MAHALLEYİ EKLEYEN METOD
        {
            if (currentSize == maxSize)
            {
                return false;
            }
            array[currentSize] = key;

            trickleUp(currentSize++);
            return true;
        }
        public void trickleUp(int index) //TRİCKLEUP METODU
        {
            int parent = (index - 1) / 2;
            MahalleSınıfı bottom = array[index];
            while (index > 0 && array[parent].nüfussayisi< bottom.nüfussayisi)
            {
                array[index] = array[parent];
                index = parent;
                parent = (parent - 1) / 2;
            }
            array[index] = bottom;
        }
        public MahalleSınıfı remove() //İLGİLİ MAHALLEYİ SİLEN METOD
        {
            MahalleSınıfı root = array[0];
            array[0] = array[--currentSize];
            trickledown(0);
            return root;
        }
        public void trickledown(int index)// TRİCKLEDOWN METODU
        {
            int largerChild;
            MahalleSınıfı top = array[index];
            while (index < currentSize / 2)
            {
                int leftChild = 2 * index + 1;
                int rightChild = leftChild + 1;
                if (rightChild < currentSize && array[leftChild].nüfussayisi < array[rightChild].nüfussayisi)
                {
                    largerChild = rightChild;
                }
                else
                {
                    largerChild = leftChild;

                }
                if (top.nüfussayisi >= array[largerChild].nüfussayisi)
                {
                    break;
                }
                array[index] = array[largerChild];
                index = largerChild;
            }
            array[index] = top;
        }
    }
    class Program
    {
        static string[] mahalleler = { "KURUDERE MAHALLESİ", "SARNIÇKÖY MAHALLESİ", "KAYADİBİ MAHALLESİ", "ÇAMİÇİ MAHALLESİ", "BEŞYOL MAHALLESİ", "GÖKDERE MAHALLESİ", "ÇİÇEKLİ MAHALLESİ", "LAKA MAHALLESİ", "KARAÇAM MAHALLESİ", "YAKAKÖY MAHALLESİ" };//MAHALLELERİN TUTULDUĞU LİSTE
        static int[] nüfus = { 59, 81, 250, 265, 334, 392, 399, 432, 590, 1217 }; //NÜFUSLARIN TUTULDUĞU LİSTE
        static void Main(string[] args)
        {
            
            Heap MahallelerVeNüfus = new Heap(50);//Heap sınıfı tipinde mahalleler ve nüfus oluşturulur
            for(int i = 0; mahalleler.Length > i; i++)
            {
                MahalleSınıfı eklenecekmahallevenüfus = new MahalleSınıfı(nüfus[i], mahalleler[i]);//MAHALLE SINIFI TİPİNDE eklenecekmahallevenüfus oluşturulur
                MahallelerVeNüfus.insert(eklenecekmahallevenüfus); //İLGİLİ MAHALLE VE NÜFUS HEAP VERİ YAPISINA EKLENİR
                Console.WriteLine(eklenecekmahallevenüfus.Mahalleadi + " " + eklenecekmahallevenüfus.nüfussayisi);//MAHALLE ADİ VE NÜFUS SAYİSİ YAZDIRILIR

            }
            Console.WriteLine(" ");
            Console.WriteLine("Çıkarılan Ve Döndürülen Elemanlar:");
            Console.WriteLine(" ");
            
            for (int i = 0; 3>i; i++)
            {
                MahalleSınıfı ÇıkanEleman = MahallelerVeNüfus.remove(); //HEAPTEN ELEMAN ÇIKARILIR VE DÖNDÜRÜLÜR
                Console.WriteLine(ÇıkanEleman.Mahalleadi + "  " + ÇıkanEleman.nüfussayisi ); //DÖNDÜRÜLEN ELEMAN KONSOLA YAZDIRILIR

            }
            Console.ReadLine();


            
        }
    }
}
