using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class AssetHistory
    {
        [Key]
        [ForeignKey("AssetSubmission")]
        public string AssetCode { get; set; }
        public virtual AssetSubmission AssetSubmission { get; set; }
        public int VolumeDelete { get; set; }
        public int YearsDelete { get; set; }
    }
}
