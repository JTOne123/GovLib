using System;
using GovLib.Contracts;
using System.Globalization;
using GovLib.Util;

namespace GovLib.ProPublica.Util.MemberModels
{
    internal class ApiNewMembers
    {
        public string id { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public string party { get; set; }
        public string chamber { get; set; }
        public string state { get; set; }
        public string district { get; set; }

        internal bool IsVotingMember() =>
            EnumConvert.StateCodeToEnum(this.state) != null;
    }
}
