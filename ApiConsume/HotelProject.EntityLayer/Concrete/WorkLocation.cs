using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.EntityLayer.Concrete
{
    public class WorkLocation
    {
        public int WorklocationID { get; set; }
        public string WorkLocationName { get; set; }
        public string WorkLocationCity { get; set; }
        public List<AppUser> AppUsers { get; set; }
    }
}
