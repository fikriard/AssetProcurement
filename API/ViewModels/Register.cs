using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModels
{
    public class Register
    {
        public string NIK { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender{ get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Job_Id { get; set; }
        public int Department_Id { get; set; }
    }
}
