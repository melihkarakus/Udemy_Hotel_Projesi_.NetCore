using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Abstract
{
    //IGenericDal dan bir T nesnesi oluiturulup bu bir sınıf olacaktır.
    public interface IGenericDal<T> where T : class
    {
        void Insert(T t);//T içinde ekleme, silme, update, List türünde hepsini getirme ve Id ile sadece 1 tane getirmek için 
        void Delete(T t);
        void Update(T t);
        List<T> GetList(T t);
        T GetByID(int id);
    }
}
