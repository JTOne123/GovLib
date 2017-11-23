using System;
using Gov.NET.Models;

namespace Gov.NET.ProPublica.ApiModels
{
    public class ApiNewMembers
    {
        public string id { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public string party { get; set; }
        public string chamber { get; set; }
        public string state { get; set; }
        public string start_date { get; set; }
        public string district { get; set; }
    
        public static Politician Convert(ApiNewMembers entity)
        {
            if (entity == null)
                return null;

            Politician politician;

            if (entity.chamber == "Senate")
            {
                politician = new Senator();
            }
            else
            {
                politician = new Representative()
                {
                    District = Int32.Parse(entity.district)
                };
            }

            politician.ID = entity.id;
            politician.FirstName = entity.first_name;

            if (!string.IsNullOrEmpty(entity.middle_name))
                politician.MiddleName = entity.middle_name;

            politician.LastName = entity.last_name;
            politician.Party = entity.party;
            politician.State = entity.state;

            return politician;
        }
    }
}
