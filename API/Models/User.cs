using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class User
    {
        [Key]
        [ForeignKey("Employees")]
        public string Id { get; set; }
        public virtual Employees Employees { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
