using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Employees
    {
        [Key]
        public int NIK { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public virtual Jobs Jobs { get; set; }
        [ForeignKey("Jobs")]
        public int Job_Id { get; set; }
        public virtual Department Department { get; set; }
        [ForeignKey("Department")]
        public int Department_Id { get; set; }
    }
}
