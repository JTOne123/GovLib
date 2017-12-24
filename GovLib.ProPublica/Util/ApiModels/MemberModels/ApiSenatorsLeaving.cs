using System;
using GovLib.Models;
using System.Globalization;
using GovLib.Util;

namespace GovLib.ProPublica.Util.MemberModels
{
    internal class ApiSenatorsLeaving
    {
        public string id { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public string party { get; set; }
        public string state { get; set; }

        internal static SenatorSummary Convert(ApiSenatorsLeaving entity)
        {
            var sen = new SenatorSummary();

            sen.ID = entity.id;
            sen.FirstName = entity.first_name;
            sen.LastName = entity.last_name;
            sen.Party = entity.party;
            sen.State = (State) EnumConvert.StateCodeToEnum(entity.state);

            if (!string.IsNullOrEmpty(entity.middle_name))
                sen.MiddleName = entity.middle_name;

            return sen;
        }
    }
}
