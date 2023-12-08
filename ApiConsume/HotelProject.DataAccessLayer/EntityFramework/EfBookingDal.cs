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
    //Özel tanımları burada işlemek için tanımladım.
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public void BookingStatusChangeApproved(Booking booking)
        {
            var context = new Context();
            var values = context.Bookings.Where(x => x.BookingID == booking.BookingID).FirstOrDefault();
            values.Status = "Onaylandı.";
            context.SaveChanges();
        }

        public void BookingStatusChangeApprovedID(int id)
        {
            var context = new Context();
            var values = context.Bookings.Find(id);
            values.Status = "Onaylandı.";
            context.SaveChanges();
        }

        public int GetBookingCount()
        {
            using var context = new Context();
            var value = context.Bookings.Count();
            return value;
        }

        public List<Booking> Last6Bookings()
        {
            using var context = new Context();
            var value = context.Bookings.OrderByDescending(x => x.BookingID).Take(6).ToList();
            return value;
        }
    }
}
