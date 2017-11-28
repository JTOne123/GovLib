using System;
using System.Collections.Generic;
using Gov.NET.Common.Models.Contracts;

namespace Gov.NET.Models
{
    public class Representative : Politician, IRepresentative
    {
        public int District { get; set; }
        public bool AtLargeDistrict { get; set; }

        public override string ToString()
        {
            return $"Representative {FullName} ({Party}) [{State}-{District}]";
        }
    }
}
