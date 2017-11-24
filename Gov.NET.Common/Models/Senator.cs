using System;
using System.Collections.Generic;
using System.Text;

namespace Gov.NET.Models
{
    public class Senator : Politician
    {
        public string Rank { get; set; }
        public int? Class { get; set; }

        public override string ToString()
        {
            return $"Senator {FullName} ({Party}) [{State}]";
        }
    }
}
