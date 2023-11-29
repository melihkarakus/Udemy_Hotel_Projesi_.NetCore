using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repository;
using HotelProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfSenderMessageDal : GenericRepository<SendMessage>, ISendMessageDal
    {
        public int GetSendMessageCount()
        {
            var context = new Context();
            return context.sendMessages.Count();
        }
    }
}
