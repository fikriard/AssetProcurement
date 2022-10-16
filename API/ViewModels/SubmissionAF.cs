﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModels
{
    public class SubmissionAF
    {
        public int Employee_Id { get; set; }
        public string AssetCode { get; set; }
        public string AssetName { get; set; }
        public int Volume { get; set; }
        public int AssetValue { get; set; }
        public int AssetLocation_Id { get; set; }
        public int YearsOfSubmission { get; set; }
    }
}