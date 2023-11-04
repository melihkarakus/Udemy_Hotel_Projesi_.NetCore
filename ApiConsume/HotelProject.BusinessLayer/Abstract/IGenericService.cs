using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Abstract
{
    //IGenericService kısmıda bir T sınıfı oluşturdu.
    public interface IGenericService<T> where T : class
    {
        void TInsert(T t);//T içinde ekleme, silme, update, List türünde hepsini getirme ve Id ile sadece 1 tane getirmek için 
        void TDelete(T t);
        void TUpdate(T t);
        List<T> TGetList();
        T TGetByID(int id);
    }
}
