using System;
using System.Collections.Generic;
using Gov.NET.Models.Contracts;
using Gov.NET.Models.Summaries;

namespace Gov.NET.Models
{
    public class Representative : Politician, IRepresentative
    {
        public int District { get; set; }
        public bool AtLargeDistrict { get; set; }
    }
}
