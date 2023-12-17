using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Abstract
{
    //Özel Tanımlar için oluşturuldu.
    public interface IBookingDal : IGenericDal<Booking>
    {
        int GetBookingCount();
        List<Booking> Last6Bookings();
        void BookingStatusChangeApproved2(int id);
        void BookingStatusChangeCancel(int id);
        void BookingStatusChangeWait(int id);
    }
}
