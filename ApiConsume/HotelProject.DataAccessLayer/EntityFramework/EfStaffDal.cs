using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repository;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    //Tanımlanan özel metodları buraya çağırıp işlem yaptırmak için gerekli bir Katman
    public class EfStaffDal : GenericRepository<Staff>, IStaffDal
    {
        public int GetStaffCount()
        {
            using var context = new Context();
            var value = context.Staffs.Count();
            return value;
        }

        public List<Staff> Last4Staff()
        {
            using var context = new Context();
            var value = context.Staffs.OrderByDescending(x => x.StaffID).Take(4).ToList();
            return value;
        }
    }
}
