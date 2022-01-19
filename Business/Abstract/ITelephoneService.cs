using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface ITelephoneService
    {
        void Kaydet(Telephone telephone);
        bool Sil(Telephone telephone);
        bool Guncelle(Telephone telephone);
        List<Telephone> IsmeArama(Telephone telephone);
        List<Telephone> TelefonNumara(Telephone telephone);
        List<Telephone> Listele();
    }
}
