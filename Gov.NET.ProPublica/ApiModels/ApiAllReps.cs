using System;
using Gov.NET.Models;

namespace Gov.NET.ProPublica.ApiModels
{
    public class ApiAllReps : ApiAllMembers
    {
        public string district { get; set; }

        public static Representative Convert(ApiAllReps entity)
        {
            if (entity == null)
                return null;
            
            var rep = new Representative();
            rep.ID = entity.id;
            rep.FirstName = entity.first_name;
            rep.LastName = entity.last_name;
            rep.Party = entity.party;
            rep.State = entity.state;
            rep.Seniority = Int32.Parse(entity.seniority);
            rep.OcdID = entity.ocd_id;

            if (entity.district == "At-Large")
            {
                rep.District = 1;
                rep.AtLargeDistrict = true;
            }
            else
            {
                rep.District = Int32.Parse(entity.district);
                rep.AtLargeDistrict = false;
            }

            if (!string.IsNullOrEmpty(entity.middle_name))
                rep.MiddleName = entity.middle_name;

            return rep;
        }
    }
}
