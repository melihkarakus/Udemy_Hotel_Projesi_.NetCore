using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Abstract
{
    // ekleme silme işlemleri haricinde özel bir tanımlama için buraya tanımlanacak.
    public interface IAboutDal : IGenericDal<About>
    {
    }
}
