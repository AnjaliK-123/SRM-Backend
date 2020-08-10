using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRegistration1.Models
{
    public class UpdateModel
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public long Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
