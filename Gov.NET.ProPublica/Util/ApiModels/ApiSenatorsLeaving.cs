using System;
using Gov.NET.Models;
using Gov.NET.Models.Summaries;
using System.Globalization;
using Gov.NET.Util;

namespace Gov.NET.ProPublica.Util
{
    internal class ApiSenatorsLeaving
    {
        private string id { get; set; }
        private string first_name { get; set; }
        private string middle_name { get; set; }
        private string last_name { get; set; }
        private string party { get; set; }
        private string state { get; set; }

        internal static SenatorSummary Convert(ApiSenatorsLeaving entity)
        {
            var sen = new SenatorSummary();

            sen.ID = entity.id;
            sen.FirstName = entity.first_name;
            sen.LastName = entity.last_name;
            sen.Party = entity.party;
            sen.State = (Enums.State) EnumConvert.StateCodeToEnum(entity.state);

            if (!string.IsNullOrEmpty(entity.middle_name))
                sen.MiddleName = entity.middle_name;

            return sen;
        }
    }
}
