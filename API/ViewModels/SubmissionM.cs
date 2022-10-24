using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModels
{
    public class SubmissionM
    {
        public virtual YearsProcurement YearsProcurement { get; set; }
        public virtual AssetLocation AssetLocation { get; set; }
        public virtual Employees Employees { get; set; }
        public virtual AssetCategory AssetCategory { get; set; }
        public string AssetCode { get; set; }
        public string AssetName { get; set; }
        public int Volume { get; set; }
        public int AssetValue { get; set; }
        public int Status { get; set; }
        public int AssetLocation_Id { get; set; }
        public int YearsOfSubmission { get; set; }
    }
}
