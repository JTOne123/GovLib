using System;
using System.Collections.Generic;


namespace Gov.NET.Models
{
    public class Representative : Politician
    {
        public int District { get; set; }

        public override string ToString()
        {
            return $"Representative {FullName} ({Party}) [{State}-{District}]";
        }
    }
}
