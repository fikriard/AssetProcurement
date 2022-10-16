using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class YearsProcurement
    {
        [Key]
        public int Id { get; set; }
        public int years { get; set; }
        public int Maxfund { get; set; }
        public int? Total { get; set; }
    }
}
