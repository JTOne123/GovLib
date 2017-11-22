using System;
using Gov.NET.Models;

namespace Gov.NET.ProPublica.ApiModels
{
    public class ApiAllReps : ApiAllMembers
    {
        public string district { get; set; }

        public static Gov.NET.Models.Representative Convert(ApiAllReps entity)
        {
            if (entity == null)
                return null;

            var rep = new Gov.NET.Models.Representative
            {
                ID = entity.id,
                FirstName = entity.first_name,
                LastName = entity.last_name,
                Party = entity.party,
                State = entity.state,
                Seniority = Int32.Parse(entity.seniority),
                OcdID = entity.ocd_id,
                District = Int32.Parse(entity.district)
            };

            if (!string.IsNullOrEmpty(entity.middle_name))
                rep.MiddleName = entity.middle_name;

            return rep;
        }
    }
}
