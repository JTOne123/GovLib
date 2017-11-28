using System;
using Gov.NET.Models;
using Gov.NET.Models.Summaries;
using System.Globalization;
using Gov.NET.Util;

namespace Gov.NET.ProPublica.Util
{
    internal class ApiSenatorsByState
    {
        public string id { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public string party { get; set; }

        public static SenatorSummary Convert(ApiSenatorsByState entity, string state)
        {
            var sen = new SenatorSummary();

            sen.ID = entity.id;
            sen.FirstName = entity.first_name;
            sen.LastName = entity.last_name;
            sen.Party = entity.party;
            sen.State = (Enums.State) EnumConvert.StateCodeToEnum(state);

            if (!string.IsNullOrEmpty(entity.middle_name))
                sen.MiddleName = entity.middle_name;

            return sen;
        }
    }
}
