using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModels
{
    public class SubmissionFinance
    {
        public string AssetCode { get; set; }
        public string AssetName { get; set; }
        public int Volume { get; set; }
        public int prize { get; set; }
        public int AssetValue { get; set; }
        public int Status { get; set; }
        public int? GoodAsset { get; set; }
        public int? BrokenAsset { get; set; }
        public string Employee_Id { get; set; }
        public int AssetLocation_Id { get; set; }
        public int AssetCategory_Id { get; set; }
        public int YearsOfSubmission { get; set; }

        
    }
}
