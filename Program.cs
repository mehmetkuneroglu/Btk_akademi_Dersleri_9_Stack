using System.Collections;
using System.Threading.Channels;

internal partial class Program
{
    // burada Personel.cs class ını tanımladık ve çözüm gezginine gönderdik. Burada bu sınıfı kullanacağız
    private static void Main(string[] args)
    {
        //HashSet Kullanımı
        //Tanımlama
        var harfler = new HashSet<char>() 
        {
            'ü', 'ö','e','u','i','o','ı'
        };
        //ekleme
        KoleksiyonYazdir(harfler);
        harfler.Add('a');
        KoleksiyonYazdir(harfler);
        // Silme
       // harfler.Remove('u');
        KoleksiyonYazdir(harfler);

        // Alfabeyi Ascıı kodlardan almak
        Console.WriteLine("\nAlfabe\n");
        var alfabe =new List<char>();
        for (int i = 97; i < 123; i++)
        {
            alfabe.Add((char)i);
        }
        KoleksiyonYazdir(alfabe);
        //Console.WriteLine("\nstandat ascii kodlarıbnda olmayan türkçe karakterler\n");
        // harfler.ExceptWith(alfabe);
        //Console.WriteLine("\nTürkçe Alfabe");
        //harfler.UnionWith(alfabe);
        //Console.WriteLine("\nKesişim kümesi");
        //harfler.IntersectWith(alfabe);
        Console.WriteLine("\nKESİŞİM KÜMESİ HARİCİNDEKİLER");
        harfler.SymmetricExceptWith(alfabe);
        KoleksiyonYazdir(harfler);
        Console.ReadKey();
        static void KoleksiyonYazdir(IEnumerable koleksiyon)
        {
            int i = 0;
            foreach (var item in koleksiyon)
            {
                Console.Write(item + "  "); //elemanlar otomatik sıralanmaz eklendiği sırayla gelir
                i++;
            }
            Console.WriteLine("\nElemen sayısı  :  {0}\n", i); ; 
        }
    }
    #region SortedSet Örnekleri
    private static void SortedSetKumelerOrnegi()
    {
        // SortedSet Küme Örneği
        //var A = new SortedSet<int>() {1,2,3,4 };
        var A = new SortedSet<int>(RastgeleSayiUret(22));
        //var B = new SortedSet<int>() { 1, 2, 5,6 };
        var B = new SortedSet<int>(RastgeleSayiUret(22));
        #region Yazdırma

        Console.WriteLine("A Kümesi Elemanları");
        foreach (var item in A)
        {
            Console.Write($"{item,4}");
        }
        Console.WriteLine("\nA Kümesinin eleman sayısı  : {0} \n", A.Count); ;
        Console.WriteLine("\n\nB Kümesi Elemanları");
        foreach (var item in B)
        {
            Console.Write($"{item,4}");
        }
        Console.WriteLine("\nB Kümesinin eleman sayısı  : {0} \n", B.Count); ;

        #endregion

        // Union - Birleşim
        //A.UnionWith(B);
        //Console.WriteLine("\nUnionWith işleminden sonra Birleşim Kümesi\n");
        //foreach (var item in A)
        //{
        //    Console.Write($"{item,4}");
        //}
        //Console.WriteLine("\nBirleşim Kümesinin eleman sayısı  : {0} \n", A.Count); ;

        // intersect -Kesişim
        // A.IntersectWith(B);

        //Console.WriteLine("\nİntersectWith işleminden sonra Kesişim Kümesi\n");
        //foreach (var item in A)
        //{
        //    Console.Write($"{item,4}");
        //}
        //Console.WriteLine("\nKesişim Kümesinin eleman sayısı  : {0} \n", A.Count); ;

        //ExeptWiht- Fark
        //A.ExceptWith(B);


        //Console.WriteLine("\nExcepttWith işleminden sonra Kesişim Kümesi\n");
        //foreach (var item in A)
        //{
        //    Console.Write($"{item,4}");
        //}
        //Console.WriteLine("\nA/B eleman sayısı  : {0} \n", A.Count); ;

        //SymetricExeptWith - Kesişim dışındaki tüm elemanlar
        A.SymmetricExceptWith(B);

        Console.WriteLine("\nSymetricExcepttWith işleminden sonra Kesişim Kümesi\n");
        foreach (var item in A)
        {
            Console.Write($"{item,4}");
        }
        Console.WriteLine("\n Kesişim dışındaki tüm elemanların sayısı  : {0} \n", A.Count);
    }
    #region RastgeleSayiUret Metodu
    //SortedSet için otommatik sayı üreten bir metod
    static List<int> RastgeleSayiUret(int n)
    {
        var liste =new List<int>();
        var r =new Random();
        for (int i = 0; i < n; i++)
        {
            liste.Add(r.Next(1, 81));
        }
        return liste;
    }
    #endregion
    private static void SortedSetUygulamaOrnegi()
    {
        //SortedSet Uygulama
        var sayilar = new List<int>(); // Normal liste oluşturduk
        var r = new Random(); // random sınıfından örnek oluşturduk
        for (int i = 0; i < 100; i++)
        {
            sayilar.Add(r.Next(0, 10));
            Console.Write($"{sayilar[i],3}");
        }
        Console.WriteLine("\n\nListedeki eleman sayısı {0} : \n", sayilar.Count);
        var benzersizSayilar = new SortedSet<int>(sayilar);
        foreach (var item in benzersizSayilar)
        {
            Console.Write($"{item,3}");
        }
        Console.WriteLine("\nBensersiz sayılar adedi :{0} ", benzersizSayilar.Count);
    }

    private static void SortedSetKullanimiOrnegi()
    {
        //SortedSet Kullanımı
        // Tanımlama
        var liste = new SortedSet<string>(); //Yalnızca benzersiz değerler eklenebilir aynı değer iki kez eklenemez
        // ekleme sonrasında True veya False değer döndürür
        if (liste.Add("Mehmet"))
        {
            Console.WriteLine("Mehmet eklendi.");
        }
        else
        {
            Console.WriteLine("Ekleme başarısız!");

        }
        Console.WriteLine("\nListedeki eleman sayısı   :{0,2}\n", liste.Count);

        //Aşağıdaki kodlar da aynı işlemi yapar
        Console.WriteLine("{0}", liste.Add("Ahmet") == true ? "Ahmet eklendi" : "Ekleme başarısız");
        Console.WriteLine("{0}", liste.Add("Ahmet") == true ? "Ahmet eklendi" : "Ekleme başarısız");// bu kod Dalse dönecek

        //Doğrudan listeye ekleme
        liste.Add("Ayşe");
        liste.Add("Hasan");
        liste.Add("Aynur");
        liste.Add("Sibel");
        liste.Add("Arda");
        // Liste içinde dolaşma
        Console.WriteLine("\nListe elemanları\n");
        foreach (var item in liste)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("\nListedeki eleman sayısı   :{0,2}\n", liste.Count);

        //çıktı listesi küçükten büyüğe doğru sıralanmış olarak gelir
        // Listeden eleman silme
        liste.Remove("Sibel");
        Console.WriteLine("\nSilme işleminden sonra Liste elemanları\n");
        foreach (var item in liste)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("\nListedeki eleman sayısı   :{0,2}\n", liste.Count);

        // özellikli silme işlemi
        liste.RemoveWhere(deger => deger.Contains("a")); // içerisinde "a" geçen değerler silinir
        liste.RemoveWhere(deger => deger.StartsWith("H")); //"H" ile başlayan değerler silinir

        Console.WriteLine("\n RemoveWhere ileSilme işleminden sonra Liste elemanları\n");
        foreach (var item in liste)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("\nListedeki eleman sayısı   :{0,2}\n", liste.Count);
    }
    #endregion
    private static void SortedDictionaryYapisiOrnegi()
    {
        // SortedDictionary yapısı
        // TAnımlama- ekleme
        var indeksListesi = new SortedDictionary<string, List<int>>()
        {
            {"HTML",new List<int>(){3,5,7 } },
            {"CSS",new List<int>(){70,80,90 } },
            {"SQL",new List<int>(){50,60 } },
            {"jQuery",new List<int>(){3,5,15} },

        };
        indeksListesi.Add("ASP.NET", new List<int>() { 40, 45 });
        indeksListesi.Add("FTP", new List<int>() { 25, 32 });
        Console.WriteLine("  Kavramlar  ve index sayfaları sıralı bir şekilde listelenmiştir\n");
        foreach (var kavram in indeksListesi)
        {
            Console.WriteLine(kavram.Key);
            kavram.Value.ForEach(v => Console.WriteLine($"   > {v} pp"));
        }
    }
    #region LinkedList ve Dictionary Örnekleri
    private static void DictionaryOrnegi2()
    {
        // Dictionary yapısı
        var personelListesi = new Dictionary<int, Personel>()
        {
            {100,new Personel("Zeynep","Coşkun",8500) },
            {105,new Personel("Ahmet","Coşkun",10000) },
            {110,new Personel("Sibel","Arık",15000) },
            {120,new Personel("Mustafa","Sucu",12000) }

        };
        personelListesi.Add(125, new Personel("Okan", "Kazıcı", 13000));
        foreach (var personel in personelListesi)
        {
            Console.WriteLine(personel);
        }
    }

    private static void DictionaryYapisiOrnegi()
    {
        //Dictionary
        // tanımlama
        var alanKodlari = new Dictionary<int, string>()
        {
            {332,"Konya"},
            {424,"Elazığ"},
            {466,"Art"},
            {322,"Adana"},

        };
        //hem yukarıdaki şekilde hem de aşağıdaki şekilde ekleme yapılabilir

        alanKodlari.Add(312, "Ankara");
        alanKodlari.Add(212, "İstanbul");
        alanKodlari.Add(216, "İstanbul");
        // ilk değer key ikinci değer value olarak çaşır ve aynı key iki defa yazılamaz.
        // koleksiyon yapısına sahip olduğu için içerisinde foreach ile dönebiliriz
        // 466 Art eksik bırakılmıştı değer değiştirmek için
        alanKodlari[466] = "Artvin"; //şeklinde değişiklik yapabiliriz
        Console.WriteLine("Bir telefon numarası alan kodu giriniz:");
        int alankodu = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Alan koduna bağlı şehir yada operatörü giriniz");
        string deger = Console.ReadLine(); //buralarda kontrol tanımlamaları yapılabilir ancak kullanıcının istenen değeri girdğini varsayıyoruz

        //ContainsKey ile sorgulama
        if (!alanKodlari.ContainsKey(alankodu))
        {
            Console.WriteLine("\aGirilen değere karşılık herhangi bir kayıt bulunamadı\n"); //  \a ifadesi alert - sesli uyarı için konuldu
            alanKodlari.Add(alankodu, deger);
            Console.WriteLine("Yeni kod eklendi\n");
        }
        else
        {
            Console.WriteLine("Kod zaten sitemde kayıtlı");
            Console.WriteLine(alanKodlari[alankodu]);
        }
        // Aşağıdaki kodlar için de yukarıdaki gibi interaktif kod yazılabilir- şimdilik zaman kaybetmemek için geçiyoruz- bu notları ben düştüm "Mehmet"
        Console.WriteLine("\nDevam etmek için bir tuşa basın\n");
        Console.ReadKey();

        // ContainsValue ile sorgulama
        if (!alanKodlari.ContainsValue("Malatya"))
        {
            Console.WriteLine("\n\aGirilen değer listede mevcut değil");
            alanKodlari.Add(422, "Malatya");
            Console.WriteLine("\n Yeni kod listeye eklendi");
        }

        // listeden silme işlemi
        alanKodlari.Remove(212); // 212 alankodlu İstanbul listeden silindi
        foreach (var s in alanKodlari)
        {
            Console.WriteLine(s);

        }
    }

    private static void LinkedListOrnegi()
    {
        //LinkedList Temelleri
        var sehirler = new LinkedList<string>();
        sehirler.AddFirst("Ordu");
        sehirler.AddFirst("Trabzon"); //ilk değer burası olur önceki first ileri atılır
        sehirler.AddLast("İstanbul");// son değer -bu değerler düğüm olarak da atlandırılabilir
        //araya değer eklemek içim
        sehirler.AddAfter(sehirler.Find("Ordu"), "Samsun");
        sehirler.AddBefore(sehirler.First.Next.Next, "Giresun"); //Samsunun öncesine Giresun ekle
        sehirler.AddAfter(sehirler.Last.Previous, "Sinop"); //Samsundan sonrasına sinop ekle ya da sondan bir öncesine sinop ekle
        sehirler.AddAfter(sehirler.Find("Sinop"), "Zonguldak");//sinobu bul sonrasına Zonguldak ekle
        //foreach (string s in sehirler)
        //{
        //    Console.WriteLine(s);
        //}
        //foreach yerine başka bir yolla hem gidiş hem dönüş güzergahı belirleyeceğiz
        Console.WriteLine();
        Console.WriteLine("Gidiş güzergahı\n");
        var eleman = sehirler.First;
        while (eleman != null)
        {
            Console.WriteLine(eleman.Value);
            eleman = eleman.Next;
        }
        Console.WriteLine();
        Console.WriteLine("Dönüş güzergahı\n");
        var gecici = sehirler.Last;
        while (gecici != null)
        {
            Console.WriteLine(gecici.Value);
            gecici = gecici.Previous;
        }
    }
    #endregion

    #region Kuyruk Örnekleri
    private static void KuyrukYapisiOrnegi2()
    {
        var sesliHarfler = new List<char>()
        {
            'a','e','ı','i','o','ö','u','ü'
        };
        ConsoleKeyInfo secim;
        var kuyruk = new Queue<char>();

        foreach (char k in sesliHarfler)
        {
            Console.WriteLine();
            Console.Write($"{k,-5} kuyruğa eklensin mi?  [e/h] ");
            secim = Console.ReadKey();
            Console.WriteLine();
            if (secim.Key == ConsoleKey.E)
            {
                kuyruk.Enqueue(k);
                Console.WriteLine($"{k,-5} kuyruğa eklendi");
                Console.WriteLine("kuyruktaki eleman sayısı : " + kuyruk.Count);
                Console.WriteLine();

            }

        }
        Console.WriteLine("Kuyruktaki elemanları temizlemekn için Esc tuşuna basın.\n");
        secim = Console.ReadKey();
        if (secim.Key == ConsoleKey.Escape)
        {
            while (kuyruk.Count > 0)
            {
                Console.WriteLine();
                Console.WriteLine($"\n{kuyruk.Peek(),5} kuyruktan çıarılıyor");
                Console.WriteLine($"{kuyruk.Dequeue(),5} kuyruktan çıkarıldı");
                Console.WriteLine("kuyruktaki eleman sayısı : " + kuyruk.Count);

            }
            Console.WriteLine("\nKuyruktan çıkarma işlemi tamamlandı");
        }
        Console.WriteLine("Program bitti");
    }
   
    private static void KuyrukYapisiOrnegi()
    {
        //Queue -Kuyruk yapısı
        // Tanımlama
        var karakterKuyrugu = new Queue<char>();
        karakterKuyrugu.Enqueue('a');
        karakterKuyrugu.Enqueue('b');
        karakterKuyrugu.Enqueue('c');
        karakterKuyrugu.Enqueue('d');
        karakterKuyrugu.Enqueue('e');
        karakterKuyrugu.Enqueue('f');
        Console.WriteLine($"Kuyruğun başındaki eleman  {karakterKuyrugu.Peek()}");
        Console.WriteLine($"Kuyruktaki elaman sayısı  {karakterKuyrugu.Count}");
        Console.WriteLine($"{karakterKuyrugu.Dequeue()} listeden çıkarıldı");
        Console.WriteLine($"Kuyruktaki elaman sayısı  {karakterKuyrugu.Count}");
        Console.WriteLine($"Kuyruğun başındaki eleman  {karakterKuyrugu.Peek()}");
        // diziye dönüştürülebilir
        Console.WriteLine("Diziden dönen değerler");
        var dizi = karakterKuyrugu.ToArray();
        for (int i = 0; i < karakterKuyrugu.Count; i++)
        {
            Console.Write(dizi[i] + " ");
        }
    }
    #endregion

    #region Yığın Örnekleri
    private static void YiginOrnegi3()
    {
        Console.WriteLine("Bir sayı giriniz");
        int sayi = Convert.ToInt32(Console.ReadLine());
        var yigin = new Stack<int>();
        while (sayi > 0)  //girilen sayıyı sondan başlayarak yığınaaktarıyoruz ve böylece enüstte ilk sayı oluyor
        {
            int k = sayi % 10;
            yigin.Push(k);
            sayi = sayi / 10;
        }

        int n = yigin.Count - 1;
        foreach (var s in yigin) // en üstteki ilk sayıyı alıp 10 üzeri n-1 ile işeme başlıyor her iterasyonda n değeri 1 azalıyor
        {
            Console.WriteLine($"\t{s,-1}\t x \t{Math.Pow(10, n),-5} \t= \t{s * Math.Pow(10, n),-5}");
            n--;
        }
    }
    
    private static void YiginOrnegi2()
    {
        var karakterYigini = new Stack<char>();
        for (int i = 65; i < 91; i++)
        {
            karakterYigini.Push((char)i);
            Console.WriteLine(karakterYigini.Peek() + " yığına eklendi");
            Console.WriteLine($"Yığındaki elaman sayısı{karakterYigini.Count()}");
        }
        //ek bilgi, yığınlar diziye aktarılabilir
        var dizi = karakterYigini.ToArray();
        Console.WriteLine("\nDizi içimndeki karakterler\n");
        foreach (var item in dizi)
        {
            Console.Write($"{item,-5}");
        }
        Console.WriteLine("\nYığından elaman çıkartmak için bir tuşa basınız\n\n");

        Console.ReadKey();
        //for (int i = karakterYigini.Count; 0 <i;  i--)
        //{
        //    Console.WriteLine(karakterYigini.Pop() + "  yığından çıkartıldı");
        //    Console.WriteLine($"Yığındaki elaman sayısı{karakterYigini.Count()}");

        //}
        // benzer döngüyü while ile de yapabiliriz
        while (karakterYigini.Count() > 0)
        {
            Console.WriteLine(karakterYigini.Pop() + "  yığından çıkartıldı");
            Console.WriteLine($"Yığındaki elaman sayısı{karakterYigini.Count()}");
        }
    }

    private static void YiginOrnegi()
    {
        // Stack tanımlama
        var karakterYigini = new Stack<char>();

        // Eklema
        karakterYigini.Push('a');
        Console.WriteLine("Yığının en üstünde " + karakterYigini.Peek() + " harfi var");
        karakterYigini.Push('b');
        Console.WriteLine("Yığının en üstünde " + karakterYigini.Peek() + " harfi var");
        karakterYigini.Push('c');
        Console.WriteLine("Yığının en üstünde " + karakterYigini.Peek() + " harfi var\n");

        // Yığından eleman çıkarma
        Console.WriteLine(karakterYigini.Pop() + "  yığından çıkartıldı.");
        Console.WriteLine(karakterYigini.Pop() + "  yığından çıkartıldı.");
        Console.WriteLine(karakterYigini.Pop() + "  yığından çıkartıldı.");
    }
    #endregion
}