using Business.Concrete;
using DataAccess.Concrete.InMemoryDal;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static Telephone telephone1 = new Telephone();
        static Telephone telephone2 = new Telephone();
        static Telephone telephone3 = new Telephone();
        static TelephoneManager telephoneManager = new TelephoneManager(new TelephoneNumberDal());
        static List<Telephone> telephones = new List<Telephone>();
        static void Main(string[] args)
        {
            string secim = null;
            do
            {
                Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)");
                Console.WriteLine("*******************************************");
                Console.WriteLine("(1) Yeni Numara Kaydetmek");
                Console.WriteLine("(2) Varolan Numarayı Silmek");
                Console.WriteLine("(3) Varolan Numarayı Güncelleme");
                Console.WriteLine("(4) Rehberi Listelemek");
                Console.WriteLine("(5) Rehberde Arama Yapmak﻿");
                Console.WriteLine("Menüden çıkmak için lütfen çıkış yazın");
                secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        NumaraKaydet();
                        break;
                    case "2":
                        NumaraSil();
                        break;
                    case "3":
                        NumaraGuncelle();
                        break;
                    case "4":
                        NumaraListele();
                        break;
                    case "5":
                        NumaraAra();
                        break;
                    default:
                        Console.WriteLine("Lütfen doğru seçim yapınız");
                        break;
                }
            } while (secim != "çıkış");
        }
        private static void NumaraAra()
        {
            Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz ");
            Console.WriteLine("*******************************");
            Console.WriteLine(" İsim veya soyisime göre arama yapmak için: (1)");
            Console.WriteLine("Telefon numarasına göre arama yapmak için: (2)");
            int secim = int.Parse(Console.ReadLine());
            if (secim == 1)
            {
                Console.WriteLine("İsim veya soyisim giriniz :");
                string adSoyad = Console.ReadLine();
                telephone1.Ad = adSoyad;
                telephone1.Soyad = adSoyad;


                telephones = telephoneManager.IsmeArama(telephone1);
                foreach (var kisi in telephones)
                {
                    Console.WriteLine("isim: " + kisi.Ad + "\nSoyİsim: " + kisi.Soyad + " \nTelefon Numarası:" + kisi.TelefonNumarasi);
                    Console.WriteLine();
                }
            }
            if (secim == 2)
            {
                Console.WriteLine("Telefon numarası giriniz");
                string telefon = Console.ReadLine();

                telephone1.TelefonNumarasi = telefon;
                telephones = telephoneManager.TelefonNumara(telephone1);
                foreach (var kisi in telephones)
                {
                    Console.WriteLine("isim: " + kisi.Ad + "\nSoyİsim: " + kisi.Soyad + " \nTelefon Numarası:" + kisi.TelefonNumarasi);
                }
            }
        }

        private static void NumaraListele()
        {
            foreach (var kisiBilgi in telephoneManager.Listele())
            {
                Console.WriteLine("isim: " + kisiBilgi.Ad + "\nSoyİsim: " + kisiBilgi.Soyad + " \nTelefon Numarası:" + kisiBilgi.TelefonNumarasi);
            }
        }
        private static void NumaraGuncelle()
        {
            int secim = 0;
            bool basariliMi = true;
            do
            {
                Console.WriteLine("Lütfen ad giriniz");
                string ad = Console.ReadLine();
                Console.WriteLine("Lütfen soyad giriniz");
                string soyad = Console.ReadLine();
                Console.WriteLine("Telefon numarası giriniz :");
                string telefon = Console.ReadLine();
                telephone3.Ad = ad;
                telephone3.Soyad = soyad;
                telephone3.TelefonNumarasi = telefon;
                basariliMi = telephoneManager.Guncelle(telephone3);
                if (basariliMi)
                    break;
                if (basariliMi == false)
                {
                    Console.WriteLine("Aradığınız veri bulunamadı.Lütfen seçim yap ");
                    Console.WriteLine("Güncellenmeyi sonlandırmak için : (1)");
                    Console.WriteLine("Yeniden denemek için      : (2)");
                    secim = int.Parse(Console.ReadLine());
                }
            } while (secim != 1);
        }
        private static void NumaraSil()
        {
            int secim = 0;
            bool basariliMi = true;
            do
            {
                Console.WriteLine("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz:");
                string ifade = Console.ReadLine();
                telephone2.Ad = ifade;
                telephone2.Soyad = ifade;
                basariliMi = telephoneManager.Sil(telephone2);
                if (basariliMi)
                    break;
                if (basariliMi == false)
                {
                    Console.WriteLine("Aradığınız veri bulunamadı.Lütfen seçim yap ");
                    Console.WriteLine("Silmeyi sonlandırmak için : (1)");
                    Console.WriteLine("Yeniden denemek için      : (2)");
                    secim = int.Parse(Console.ReadLine());
                }
            } while (secim != 1);
        }

        private static void NumaraKaydet()
        {
            Console.Write("Lütfen isim giriniz : ");
            string isim = Console.ReadLine();
            Console.Write("Lütfen soyisim giriniz : ");
            string soyad = Console.ReadLine();
            Console.Write("Lütfen telefon numarası giriniz : ");
            string telefon = Console.ReadLine();
            telephone1.Ad = isim;
            telephone1.Soyad = soyad;
            telephone1.TelefonNumarasi = telefon;
            telephoneManager.Kaydet(telephone1);
        }
    }
}
