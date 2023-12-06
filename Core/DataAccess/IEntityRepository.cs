using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{//car, color,brand ile  ilgili veritabanında yapacagım operasyonları içeren interfaceim
    //operasyonlar=> ekle,güncelle,silme,filtrele,tümünü listele gibi gibi
    //interface metoddları default olarak publictir
    public interface IEntityRepository<T> where T : class, new()
    {
        List<T> GetAll(Expression<Func<T, bool>>? filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
