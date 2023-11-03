using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Abstract
{
    //Service için özel tanımlamalar buradan olacaktır.
    public interface IServiceDal : IGenericDal<Service>
    {
    }
}
