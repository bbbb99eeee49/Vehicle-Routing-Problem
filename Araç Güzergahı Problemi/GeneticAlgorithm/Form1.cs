//Barış UYAR - 190204053 GENETİK ALGORİTMA
//EKMEK FABRİKASI ARAÇ GÜZERGAHI PROBLEMİ 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneticAlgorithm
{
    public partial class Form1 : Form
    {
        public List<Musteri> MusteriListesi = new List<Musteri>();//ilki depo diğerleri müşteriler
        public List<Arac> AracListesi = new List<Arac>();//tüm araç isimleri ve kapasiteleri
        public List<Birey> ilkToplum = new List<Birey>();//ilki depo diğerleri müşteriler
        public List<Birey> yeniToplum = new List<Birey>();//ilki depo diğerleri müşteriler
       
        public int NesilSayisi = 200;//ardarda toplum dönüşümünü içerir nesil sayısı
        int BireySayisi = 300;//işlemlerdeki çözüm sayısıdır birey sayısı
        int ElitSayisi = 2;//en iyiler seçilirken gerıye kalanlar, çaprazlama uygulanacaklar
        int MutasyonSayisi = 1;//burada mutasyona ugrayacak gen sayısı belirlenebilir
        int MutasyonOranı = 1; //mutasyon oranını buradan düzenlenebilir
        int GenSayisi;//müşteri sayısına göre şekillenecek
       string anaharfler = "ABCDEFGHIJKLMNOPRSTUVYZ";
       

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //Bu kısımda güzergahımızda bulunan rotaların enlem boylam ve talep miktarları veriliyor.
            //NOT! GÜZERGAH NOKTALARI TABLODA KARIŞIK OLARAK VERİLMİŞTİR. GENETİK ALGORİTMA PROGRAMIMIZ BİZİM İÇİN EN İYİ GÜZERGAHI KENDİSİ ÇİZECEKTİR.
            Musteri depo = new Musteri("Depo",39.84617447897217, 33.517761148958876, 712, 0); //YURTİÇİ KARGO GÜRLER 
            MusteriListesi.Add(depo);

            depo = new Musteri("A", 39.856189879376075, 33.484694830303845, 132, 0);     //PODİUM AVM
            MusteriListesi.Add(depo);
            depo = new Musteri("B", 39.840967973361735, 33.512761465387676, 34, 0);      //CarrefourSA
            MusteriListesi.Add(depo);
            depo = new Musteri("C", 39.87094792532678  , 33.45627846795215, 18, 0);      //AYBİMAŞ MARKET
            MusteriListesi.Add(depo);
            depo = new Musteri("D", 39.856372364927275, 33.484622742804916, 41, 0);      //KIRIKKALE OTOGARI
            MusteriListesi.Add(depo);
            depo = new Musteri("E", 39.86196573424522, 33.48309438564966, 29, 0);        //KIRIKKALE YÜKSEK İHTİSAS HASTANESİ
            MusteriListesi.Add(depo);
            depo = new Musteri("F", 39.8511904155852, 33.49368562132508, 24, 0);         //KIRIKKALE POLİS EVİ                
            MusteriListesi.Add(depo);
            depo = new Musteri("G", 39.84049439282357, 33.50059827924683, 32, 0);        //KIRIKKALE ADALET SARAYI
            MusteriListesi.Add(depo);
            depo = new Musteri("H", 39.86081056952189, 33.542872307236564, 32, 0);       //DOĞA PARK SİTESİ
            MusteriListesi.Add(depo);
            depo = new Musteri("I", 39.86602507598874, 33.45999512437387, 8, 0);         //CİĞERCİ BAHRİ
            MusteriListesi.Add(depo); 
            depo = new Musteri("J", 39.86215017730261, 33.502157581427994, 13, 0);       //YENİÇAĞ MARKET
            MusteriListesi.Add(depo);
            depo = new Musteri("K", 39.8448417249324, 33.509252965188345, 31, 0);        //KIRIKKALE BELEDİYESİ
            MusteriListesi.Add(depo);
            depo = new Musteri("L", 39.84448095115291, 33.500802152418295, 27, 0);       //ATATÜRK PARKI 
            MusteriListesi.Add(depo);
            depo = new Musteri("M", 39.87202103129301, 33.4529929937709, 35, 0);         //KIRIKKALE ÜNİVERSİTESİ TIP FAKÜLTESİ HASTANESİ
            MusteriListesi.Add(depo);
            depo = new Musteri("N", 39.86801224694222, 33.455208041686966, 19, 0);       //ZİRAAT BANKASI YAHŞİHAN/KIRIKKALE ŞUBESİ 
            MusteriListesi.Add(depo);
            depo = new Musteri("O", 39.868957680390935, 33.45558231296427, 29, 0);       //KIRIKKALE VR & Playstation 5 Cafe
            MusteriListesi.Add(depo);
            depo = new Musteri("P", 39.85016700435409, 33.500828146736005, 37, 0);       //ÖZEL YAŞAM HASTANESİ
            MusteriListesi.Add(depo);
            depo = new Musteri("R", 39.87168723709241, 33.45737891515665, 12, 0);        //KİM MARKET
            MusteriListesi.Add(depo);
            depo = new Musteri("S", 39.87634268393422, 33.458225129681246, 50, 0);       //TÜRKAN HATUN ERKEK ÖĞRENCİ YURDU
            MusteriListesi.Add(depo);
            depo = new Musteri("T", 39.87323871090256, 33.458607893899, 13, 0);          //TATLI KRİZİ
            MusteriListesi.Add(depo);
            depo = new Musteri("U", 39.85583511154651, 33.55978544240909, 18, 0);        //KIRIKKALE ATATÜRK ANADOLU LİSESİ
            MusteriListesi.Add(depo);
            depo = new Musteri("V", 39.88314080272683, 33.45259354274867, 48, 0);        //RESİDORM
            MusteriListesi.Add(depo);
            depo = new Musteri("Y", 39.91866865338675, 33.43435299601455, 17, 0);        //KÖFTECİ YUSUF
            MusteriListesi.Add(depo);
            depo = new Musteri("Z", 39.85985810020425, 33.52523602009928, 13, 0);        //KIRIKKALE GÜZEL SANATLAR LİSESİ
            MusteriListesi.Add(depo);

            //Bu kısımda ise araçlarımız ve araçlarımızın taşıma kapasitesi veriliyor. Araçlar şimdilik kullanılmadığı için false konumunda.
            Arac arac = new Arac("Transit ", 130, false);
            AracListesi.Add(arac);
            arac = new Arac("Transit  ", 130, false);
            AracListesi.Add(arac);
            arac = new Arac("Transit ", 130, false);
            AracListesi.Add(arac);
            arac = new Arac("Transit  ", 100, false);
            AracListesi.Add(arac);
            arac = new Arac("Transit  ", 100, false);
            AracListesi.Add(arac);
            arac = new Arac("Transit  ", 70, false);
            AracListesi.Add(arac);
            arac = new Arac("Elektrikli Araç Pilly  ", 15, false);
            AracListesi.Add(arac);
            arac = new Arac("Elektrikli Araç Pilly  ", 15, false);
            AracListesi.Add(arac);
            arac = new Arac("Elektrikli Araç Pilly  ", 15, false);
            AracListesi.Add(arac);
            arac = new Arac("Elektrikli Araç Pilly  ", 15, false);
            AracListesi.Add(arac);




            //StringBuilder System.Text isim uzayı altında yer alan ve metinsel ifadeleri birleştirmek için kullanılan bir sınıftır.
            //baslangic.Appendline ile yeni bir satır oluşturuyoruz.
            //Daha sonrasında for döngüsü içerisinde, müşteri listemizin değeri kadar bu işlemi döndürüyoruz.
            StringBuilder baslangic = new StringBuilder();
            baslangic.AppendLine("Adı - Enlem - Boylam - Talep Miktarı");
            for (int i = 0; i < MusteriListesi.Count; i++)
            {
                Musteri item = MusteriListesi[i];
                baslangic.AppendLine(String.Format("{0} - {1}  - {2}  - {3} - {4} ", i, item.Adi, item.Enlem, item.Boylam, item.SiparisMiktari));
            }
            baslangicdurumu.Text = baslangic.ToString();
            //başlangıcımızı string olarak almıştık. ardından girdiğimiz int değerlerin hata vermemesi için burada
            //baslangic.ToString komutu ile string ifadeye çevirmeyi gerçekleştiriyoruz.
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ilk toplumumuz burada oluşturuluyor.
            ilkToplum = ToplumOlustur();
            ROTALAR.Items.Clear();
            String sonucekraniyazisi = "İlk Toplum tüm bireyleri oluşturuldu.";
            
            ROTALAR.Items.Add(sonucekraniyazisi);
            

            

            //her nesil için döngü gerçekleşecek ve döngünün en iyisi ekrana yazılacak
            //for döngüsünün içinde de belirtildiği gibi nesil sayımız kadar işlemimiz tekrar edecek.       
            for (int i_nesil = 0; i_nesil < NesilSayisi; i_nesil++)
            {
               
                //foreach komutu Birey listesi içerisindeki "birey" değişkenlerini ilkToplumda kullanmamıza yardımcı olacaktır
                foreach (Birey birey in ilkToplum)
                {
                    
                    //AracListesi içerisindeki verileri bireyinAraclari olarak oluşturduğumuz listeye kopyalıyoruz.
                    List<Arac> bireyinAraclari = AracListesi.CloneList().ToList();
                    
                    

                   

                    //uygunluk hesaplanırken kromozomlar tek tek dolaşılarak hesaplanıcak
                    for (int i_kromozom = 0; i_kromozom < birey.Kromozom.Length; i_kromozom++)
                    {
                        //her kromozom bir müşterimiz olacak. depodan başlayıp her kromozoma ait müşterinin uzaklığı hesaplanacak, sonra bir sonraki müşteriye 
                        //giderken ki mesafe hesaplanacak. Uzaklık dışında eldeki araç miktarı en son kaç tane kullanılmışsa ona göre değerlendirilecek.
                        //örneğin bireyin tüm kromozomları dolaşılıp mesafeler ve ihtiyaç olan taşıma araç sayıları belirlendikten sonra
                        //puanlama yapılacak. bu puanlama uygun değerini temsil edecek. yani bizim uygunluk hesabımız hem en az araç kullanabilmeye göre
                        //hem de en az masrafla güzergahı tamamlayabilmeye odaklı olacak.
                        //puan hesaplanırken toplam ihtiyaç miktarını en çok yük alan araçı gönderirken güzergahın kaç tanesi yapabileceği tespit edilecek. Ardından 
                        //ikinci en çok yük alabilen aracın kaç tane yapabileceği tespit edilir ve tümünde sırasıyla kaç aracın devreye gireceği netleştirilir.
                        //her aracın yapacağı mesafeler hesaplanarak toplam miktar uygunluk değeri olarak alınır. Böylece toplam miktar en az olan bizim için en iyi güzergahtır.
                        //örneğin toplam talep miktarı 3 araçla 4500 km yol gidilerek karşılayan bir güzergah ile 2 araçla 3800 km yol gidilebilecek şekilde daha iyi bir 
                        //rotalama yapılabilir. 

                        Char harf = birey.Kromozom[i_kromozom];
                        Char oncekiharf = birey.Kromozom[i_kromozom == 0 ? i_kromozom : i_kromozom - 1];
                        Musteri oncekiMusteri = MusteriListesi.Where(c => c.Adi == oncekiharf.ToString()).FirstOrDefault();
                        if (i_kromozom == 0)
                        {
                            oncekiMusteri = MusteriListesi[0];
                        }
                        Musteri suankiMusteri = MusteriListesi.Where(c => c.Adi == harf.ToString()).FirstOrDefault();

                        //önce araba kapasitesinin yeterliliği kontrol edilecek yetmezse yeni arac harekete başlayacak
                        //ve sonra arabanın kapastesi azaltılacak 
                        //işlem yapacağımız müşterinin sipariş miktarını integer olarak atıyoruz
                        int SiparisMiktari = suankiMusteri.SiparisMiktari;
                        
                        //sıradaki aracımızın kullanılıp kullanılmadığına bakıyoruz
                        int siradakaracindexi = bireyinAraclari.FindIndex(c => c.Kullanildimi == false);
                        
                        //burada ise araç kapasitelerimiz ile sipariş miktarlarını karşılaştıracağız.
                        //eğer kapasitemiz sipariş miktarından fazlaysa aracımızı ekmek ile yüklüyoruz.
                        //aracımızı yüklediğimiz için kalan kapasite miktarını bulmak için ise sipariş miktarını çıkartıyoruz.
                        try
                        {
                            if (bireyinAraclari[siradakaracindexi].Kapasite >= SiparisMiktari)
                            {
                                bireyinAraclari[siradakaracindexi].Kapasite -= SiparisMiktari;
                                birey.AraclarinGuzergahi += harf;
                            }
                            else
                            {
                                //burada yeterli gelmediğinde diğer araca geçilmiştir. Dolayısıyla mesafe depodan bu noktaya göre yapılır
                                bireyinAraclari[siradakaracindexi].Kullanildimi = true;
                                siradakaracindexi++;
                                bireyinAraclari[siradakaracindexi].Kapasite -= SiparisMiktari;
                                //araç değiştirildiği için ceza 2000
                                birey.Uygunluk += 2000;
                                birey.AraclarinGuzergahi += " -- "+harf;
                            }
                        }
                        //try komutunda hata olması halinde kodumuz buradan itibaren devam edebilmesi ve
                        //hata vermemesi için "catch" komutunu kullanıyoruz
                        catch (Exception)
                        {
                        }
                        //double kullanmamızın sebebi çok sayıda ondalık dilim içeren sayılar kullandığımız içindir
                        //ardından iki güzergah arası mesafeyi hesaplıyoruz
                        double aradakiMesafe = Geography.CalculateDistance(suankiMusteri.Enlem, suankiMusteri.Boylam, oncekiMusteri.Enlem, oncekiMusteri.Boylam);
                        birey.Uygunluk += (int)aradakiMesafe / 1000;
                        birey.ToplamYol += (int)aradakiMesafe / 1000;


                    }

                    birey.AraclarSirasi = bireyinAraclari;
                }
                //uygunluk hesaplamaları bitti en iyiler kontrol edilecek
                var minUygunluk = ilkToplum.Min(obj => obj.Uygunluk);
                Birey buneslineniyibireyi = ilkToplum.Where(obj => obj.Uygunluk == minUygunluk).FirstOrDefault();
                int KullanilanAracSayisi = buneslineniyibireyi.AraclarSirasi.FindIndex(c => c.Kullanildimi == false);
                
                //neslin en iyi bireyini burada yazdıracağız
                ROTALAR.Items.Add(String.Format("{0}. Neslin en iyi Bireyinin \nGüzergahı: {1}, \nToplam Yol: {2}, \nKullandığı Araç Sayısı: {3}", i_nesil + 1, buneslineniyibireyi.AraclarinGuzergahi, buneslineniyibireyi.ToplamYol, KullanilanAracSayisi + 1));
                yeniToplum = new List<Birey>();
                Birey b = (Birey)buneslineniyibireyi.Clone();
                //yeni toplum açılıyor ve neslin en iyi bireyleri buraya kopyalanıyor
                //yani elitizm uygulanıyor
                yeniToplum.Add(b);
                yeniToplum.Add(b);

                //çaprazlama ile yeni toplumun elemanları oluşturuluyor. İlk nesilimizde bireylerimizi oluşturabilmek adına random bir şekilde
                //çaprazlama yapılabilmesi için kromozomlarımız oluşturuluyor
                //sıralamaya dayalı çaprazlama yapılmaktadır
                Random rnd = new Random();
                for (int i_caprazlama = 0; i_caprazlama < BireySayisi - 2; i_caprazlama = i_caprazlama + 2)
                {
                    Birey caprazlama_ilkbirey = ilkToplum[rnd.Next(BireySayisi)];
                    Birey caprazlama_ikincibirey = ilkToplum[rnd.Next(BireySayisi)];
                      Birey caprazlama_ilkfinalist;
                      //çaprazlama yapmadan önce iki birey burada karşılaştırılıyor
                      //Turnuva seçilimi yöntemi ile uygunluğu iyi olan birey bir üst nesile aktarılıyor
                      if (caprazlama_ilkbirey.Uygunluk < caprazlama_ikincibirey.Uygunluk)
                      {
                          caprazlama_ilkfinalist = caprazlama_ilkbirey;
                      }
                      else
                      {
                          caprazlama_ilkfinalist = caprazlama_ikincibirey;
                      }
                      //diğer iki birey arasında da yukarıdaki işlem yapılıyor
                      //Turnuva seçilimi yöntemi ile uygunluğu iyi olan birey bir üst nesile aktarılıyor.
                      Birey caprazlama_ucuncubirey = ilkToplum[rnd.Next(BireySayisi)];
                      Birey caprazlama_dortuncubirey = ilkToplum[rnd.Next(BireySayisi)];
                      Birey caprazlama_ikincifinalist;
                      if (caprazlama_ucuncubirey.Uygunluk < caprazlama_dortuncubirey.Uygunluk)
                      {
                          caprazlama_ikincifinalist = caprazlama_ucuncubirey;
                      }
                      else
                      {
                          caprazlama_ikincifinalist = caprazlama_dortuncubirey;
                      }

                      int caprazlanacakKromozomBogumu = rnd.Next(1, anaharfler.Length-1);
                      //Substring komutumuz ile kromozom içeriğimizin bir kısmı tutuluyor ve geriye kalan kısmı ise atılıyor
                      //çaprazlamayı bir nevi bu komut ile yapıyoruz diyebiliriz
                      //iyi olan iki bireyimiz arasında çaprazlama gerçekleştiriliyor ve daha iyi bireyler elde etmek amaçlanıyor.
                      String ilkparcailk = caprazlama_ilkfinalist.Kromozom.Substring(0, caprazlanacakKromozomBogumu);
                      String kalanparcailk = caprazlama_ikincifinalist.Kromozom;
                      for (int i_caprazlama_kromozom = 0; i_caprazlama_kromozom < kalanparcailk.Length; i_caprazlama_kromozom++)
                      {
                          Char harf = kalanparcailk[i_caprazlama_kromozom];
                          if (!ilkparcailk.Contains(harf))
                          {
                              ilkparcailk += harf.ToString();
                          }
                      }

                      //ilk çaprazlama sonucu elde ettiğimiz bireyi yeni toplumumuza ekliyoruz
                      caprazlama_ilkfinalist.Kromozom = ilkparcailk;
                      caprazlama_ilkfinalist.Uygunluk = 0;
                      caprazlama_ilkfinalist.ToplamYol = 0;
                       b = (Birey)caprazlama_ilkfinalist.Clone();
                      yeniToplum.Add(b);

                      String ilkparcaikinci = caprazlama_ikincifinalist.Kromozom.Substring(0, caprazlanacakKromozomBogumu);
                      String kalanparcaikinci = caprazlama_ilkfinalist.Kromozom;
                      for (int i_caprazlama_kromozom = 0; i_caprazlama_kromozom < kalanparcaikinci.Length; i_caprazlama_kromozom++)
                      {
                          Char harf = kalanparcaikinci[i_caprazlama_kromozom];
                          if (!ilkparcaikinci.Contains(harf))
                            {
                              ilkparcaikinci += harf.ToString();
                          }
                      }
                      //ikinci çaprazlama sonucu elde ettiğimiz bireyi yeni toplumumuza ekliyoruz
                      caprazlama_ikincifinalist.Kromozom = ilkparcaikinci;
                      caprazlama_ikincifinalist.Uygunluk = 0;
                      caprazlama_ikincifinalist.ToplamYol = 0;

                      b = (Birey)caprazlama_ikincifinalist.Clone();
                      yeniToplum.Add(b);

                }

                //mutasyonla toplumdaki bir bireyin kromozomlarından sadece birisi random bir şekilde yer değiştiriyor
                //Bu sayede çözüm kısır döngüye girmiyor
                int mutasyonluBirey = rnd.Next(BireySayisi);
                String  mutasyon_bireyin_kromozomu = yeniToplum[mutasyonluBirey].Kromozom;
                int mutasyonaugrayacakbirinciKromozom_int=rnd.Next(1, anaharfler.Length-1);
                int mutasyonaugrayacakikinciKromozom_int = rnd.Next(1, anaharfler.Length - 1);
                //SwapCharacters komutumuz mutasyonun gerçekleşmesini sağlayan komuttur
                yeniToplum[mutasyonluBirey].Kromozom = Geography.SwapCharacters(yeniToplum[mutasyonluBirey].Kromozom, mutasyonaugrayacakbirinciKromozom_int, mutasyonaugrayacakikinciKromozom_int);
               

             
                ilkToplum = yeniToplum.CloneList().ToList();
                //yeni oluşturduğumuz bu toplum bizim ilkToplumumuz olarak atanıyor
                for (int i = 0; i < ilkToplum.Count; i++)
                {
                    ilkToplum[i].Uygunluk = 0;
                    ilkToplum[i].ToplamYol = 0;
                    ilkToplum[i].AraclarinGuzergahi = "";
                }
 
            }
        }
        //ardından yeni bir toplum oluşturuyoruz ve aynı işlemleri tekrarlıyoruz
        public List<Birey> ToplumOlustur()
        {
            List<Birey> toplum = new List<Birey>();
           
            Random rastgele = new Random();
            while (toplum.Count < BireySayisi)
            {
                string harflerharfler = anaharfler;
                Birey islemyapilacakBirey = new Birey("","", 0,0, new List<Arac>());
                
                while (islemyapilacakBirey.Kromozom.Length < anaharfler.Length)
                {
                    int rastint = rastgele.Next(harflerharfler.Length);
                    Char harf = harflerharfler[rastint];

                    if (!islemyapilacakBirey.Kromozom.Contains(harf))
                    {
                        islemyapilacakBirey.Kromozom += harf;
                        harflerharfler = harflerharfler.Remove(rastint, 1);
                    }
                }

                toplum.Add(islemyapilacakBirey);

            }
            return toplum;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }


    internal static class Extensions
    {
        public static IList<T> CloneList<T>(this IList<T> list) where T : ICloneable
        {
            return list.Select(item => (T)item.Clone()).ToList();
        }
    }

}
