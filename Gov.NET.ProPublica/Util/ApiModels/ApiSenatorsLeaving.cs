using System;
using Gov.NET.Models;
using Gov.NET.Common.Models.Cards;
using System.Globalization;
using Gov.NET.Util;

namespace Gov.NET.ProPublica.Util
{
    internal class ApiSenatorsLeaving
    {
        public string id { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public string party { get; set; }
        public string state { get; set; }

        public static SenatorCard Convert(ApiSenatorsLeaving entity)
        {
            var sen = new SenatorCard();

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
