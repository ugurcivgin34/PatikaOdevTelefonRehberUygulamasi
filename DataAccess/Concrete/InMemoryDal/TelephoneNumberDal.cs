using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemoryDal
{
    public class TelephoneNumberDal : ITelephoneNumberDal
    {
        List<Telephone> _telephones;
        List<Telephone> bilgiler = new List<Telephone>();
        public TelephoneNumberDal()
        {
            _telephones = new List<Telephone>
            {
                new Telephone{Ad="Uğur Okan" , Soyad="Çivgin" , TelefonNumarasi="05385839563" },
                new Telephone{Ad="Sait" , Soyad="Çivgin" , TelefonNumarasi="05385695412" },
                new Telephone{Ad="Önder" , Soyad="Özben" , TelefonNumarasi="05321587456" },
                new Telephone{Ad="Çoşkun" , Soyad="Özben" , TelefonNumarasi="05348956352" },
                new Telephone{Ad="Ali" , Soyad="Özdemir" , TelefonNumarasi="05321456985" }
            };
        }
        public List<Telephone> IsmeArama(Telephone telephone)
        {
            foreach (var item in _telephones)
            {
                if (item.Ad == telephone.Ad || item.Soyad == telephone.Soyad)
                    bilgiler.Add(item);
            }
            return bilgiler;
        }

        public List<Telephone> TelefonNumara(Telephone telephone)
        {
            foreach (var item in _telephones)
            {
                if (item.TelefonNumarasi == telephone.TelefonNumarasi)
                    bilgiler.Add(item);
            }
            return bilgiler;
        }
        public void Guncelle(Telephone telephone)
        {
            Telephone telephoneToUpdate;
            telephoneToUpdate = _telephones.SingleOrDefault(t => t.TelefonNumarasi == telephone.TelefonNumarasi);
            telephoneToUpdate.Ad = telephone.Ad;
            telephoneToUpdate.Soyad = telephone.Soyad;
            telephoneToUpdate.TelefonNumarasi = telephone.TelefonNumarasi;
        }

        public void Kaydet(Telephone telephone)
        {
            _telephones.Add(telephone);
        }

        public List<Telephone> Listele()
        {
            return _telephones;
        }

        public void Sil(Telephone telephone)
        {
            Telephone telephoneToDelete = new Telephone();
            foreach (var item in _telephones)
            {
                if (item.Ad == telephone.Ad || item.Soyad == telephone.Soyad)
                {
                    telephoneToDelete = item;
                    break;
                }
            }
            _telephones.Remove(telephoneToDelete);
        }
    }
}
