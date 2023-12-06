using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{//gönderilen iş kurallarını bulunduran bir sınıf tek tek managerde yamıztık burada topluyor olacagız
    //params: params tipinde istediğimiz kadar Iresultu  array olarak gönderiyoruz.liste de kullanılabılırdı
    public static class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {//parametre ıle gonderılen kuralların basarısız olanları busınessa haber edıyoruz
            foreach (var logic in logics)
            {//kurala uymayanı dondur
                if (!logic.Success)
                {
                    return logic;
                }
            }
            return null;
        }

    }
}
