using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Repository;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    //Tanımlanan özel kodu buraya çağırıp burada işlem yaptırıyoruz. 
    public class EfAboutDal : GenericRepository<About>, IAboutDal
    {
    }
}
