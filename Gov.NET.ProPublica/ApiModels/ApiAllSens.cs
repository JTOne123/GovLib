using System;
using Gov.NET.Util;

namespace Gov.NET.ProPublica.ApiModels
{
    public class ApiAllSenators : ApiAllMembers
    {
        public string senate_class { get; set; }
        public string state_rank { get; set; }

        public static Gov.NET.Models.Senator Convert(ApiAllSenators entity)
        {
            if (entity == null)
                return null;

            var sen = new Gov.NET.Models.Senator
            {
                ID = entity.id,
                FirstName = entity.first_name,
                LastName = entity.last_name,
                Party = entity.party,
                State = entity.state,
                Seniority = Int32.Parse(entity.seniority),
                OcdID = entity.ocd_id,
                Class = Int32.Parse(entity.senate_class),
                Rank = Text.Capitalize(entity.state_rank)
            };

            if (!string.IsNullOrEmpty(entity.middle_name))
                sen.MiddleName = entity.middle_name;

            return sen;
        }
    }
}
