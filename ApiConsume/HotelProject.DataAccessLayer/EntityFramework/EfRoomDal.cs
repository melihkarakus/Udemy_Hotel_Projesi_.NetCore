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
    public class EfRoomDal : GenericRepository<Room>, IRoomDal
    {
        public int RoomCount()
        {
            using var context = new Context();
            var value = context.Rooms.Count();
            return value;
        }
    }
}
