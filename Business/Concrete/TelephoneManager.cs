using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TelephoneManager : ITelephoneService
    {
        ITelephoneNumberDal _telephoneNumberDal;

        public TelephoneManager(ITelephoneNumberDal telephoneNumberDal)
        {
            _telephoneNumberDal = telephoneNumberDal;
        }

        public bool Guncelle(Telephone telephone)
        {
            bool dogruMu = false;
            if (CheckNameOrLastName(telephone))
            {
                _telephoneNumberDal.Guncelle(telephone);
                Console.WriteLine("Güncellendi");
                dogruMu = true;
            }
            return dogruMu;
        }

        public List<Telephone> IsmeArama(Telephone telephone)
        {
            return _telephoneNumberDal.IsmeArama(telephone);
        }
        public List<Telephone> TelefonNumara(Telephone telephone)
        {
            return _telephoneNumberDal.TelefonNumara(telephone);
        }
        public void Kaydet(Telephone telephone)
        {
            _telephoneNumberDal.Kaydet(telephone);
        }

        public List<Telephone> Listele()
        {
            return _telephoneNumberDal.Listele();
        }

        public bool Sil(Telephone telephone)
        {
            char secim = ' ';
            bool islemYapildiMi = true;
            if (CheckNameOrLastName(telephone))
            {
                Console.WriteLine(telephone.Ad + " isimli kişisi rehberden silinmek üzere, onaylıyor musunuz ? (y/n) ");
                secim = char.Parse(Console.ReadLine());
                if (secim == 'y')
                {
                    _telephoneNumberDal.Sil(telephone);
                    islemYapildiMi = true;
                    Console.WriteLine("Silindi");
                    Console.WriteLine(" ");
                }
                else
                {
                    Console.WriteLine("Onaylanmadı.Bu yüzden silinmedi");
                }

            }

            else
            {

                islemYapildiMi = false;
            }
            return islemYapildiMi;
        }

        private bool CheckNameOrLastName(Telephone telephone)
        {
            bool dogruMu = false;
            foreach (var item in _telephoneNumberDal.Listele())
            {
                if (item.Ad == telephone.Ad || item.Soyad == telephone.Soyad || item.TelefonNumarasi == telephone.TelefonNumarasi)
                {
                    dogruMu = true;
                    break;
                }
            }
            return dogruMu;
        }
    }
}
