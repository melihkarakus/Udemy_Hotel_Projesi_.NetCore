using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Abstract
{
    //Testimonial özel işlemler için burada tanımlanacak
    public interface ITestimonialDal : IGenericDal<Testimonial>
    {
    }
}
