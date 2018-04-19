using System;
using System.Collections.Generic;
using GovLib.ProPublica.Util;

namespace GovLib.ProPublica
{
    public class Vote
    {
        #pragma warning disable CS1591

        public int Congress { get; internal set; }
        public Chamber Chamber { get; internal set; }
        public int Session { get; internal set; }
        public int RollCall { get; internal set; }
        public string BillID { get; internal set; }
        public IList<string> AmendmentIDs { get; internal set; }
        public string Question { get; internal set; }
        public string Description { get; internal set; }
        public string VoteType { get; internal set; }
        public DateTime TimeStamp { get; internal set; }
        public bool Passed { get; internal set; }

        public VoteResult DemocraticVotes { get; internal set; }
        public VoteResult RepublicanVotes { get; internal set; }
        public VoteResult IndependentVotes { get; internal set; }
        public VoteResult TotalVotes { get; internal set; }
    }
}