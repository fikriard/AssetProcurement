﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class AssetSubmission
    {
        [Key]
        public string AssetCode { get; set; }
        public string AssetName { get; set; }
        public int Volume { get; set; }
        public int prize { get; set; }
        public int AssetValue { get; set; }
        public Status Status { get; set; }
        public int? GoodAsset { get; set; }
        public int? BrokenAsset { get; set; }
        [ForeignKey("Employees")]
        public int Employee_Id { get; set; }
        public virtual Employees Employees { get; set; }

        [ForeignKey("AssetLocation")]
        public int AssetLocation_Id { get; set; }
        public virtual AssetLocation AssetLocation { get; set; }

        [ForeignKey("AssetCategory")]
        public int AssetCategory_Id { get; set; }
        public virtual AssetCategory AssetCategory { get; set; }

        [ForeignKey("YearsProcurement")]
        public int YearsOfSubmission { get; set; }
        public virtual YearsProcurement YearsProcurement{ get; set; }

    }
    public enum Status
    {
        Draft,
        Posted,
        Approved,
        Rejected,
        Canceled,
        ApprovedByManager,
        ApprovedByFinance,
        RejectedByManager,
        RejectedByFinance,
    }

}
