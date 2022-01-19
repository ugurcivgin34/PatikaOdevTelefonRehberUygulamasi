using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ITelephoneNumberDal
    {
        void Kaydet(Telephone telephone);
        void Sil(Telephone telephone);
        void Guncelle(Telephone telephone);
        List<Telephone> IsmeArama(Telephone telephone);
        List<Telephone> TelefonNumara(Telephone telephone);
        List<Telephone> Listele();
    }
}
