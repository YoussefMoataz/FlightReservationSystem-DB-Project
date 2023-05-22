using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem_DB_Project
{
    public class Admin
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public Int32 SSN { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public Int32 Age { get; set; }
        public string DateOfBirth { get; set; }
        public string AccessLevel { get; set; }
    }
}
