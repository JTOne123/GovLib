using System;
using System.Collections.Generic;
using Gov.NET.Models.Contracts;
using Gov.NET.Models.Summaries;

namespace Gov.NET.Models
{
    /// <summary>Full implementation for a house representative.</summary>
    public class Representative : Politician, IRepresentative
    {
        #pragma warning disable CS1591

        public int District { get; set; }
        public bool AtLargeDistrict { get; set; }
        
        #pragma warning restore CS1591
    }
}
