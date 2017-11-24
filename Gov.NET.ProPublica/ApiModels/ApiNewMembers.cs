using System;
using Gov.NET.Models;
using Gov.NET.Common.Models.Cards;
using System.Globalization;

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

        public static PoliticianCard Convert(ApiNewMembers entity)
        {
            if (entity == null)
                return null;

            var chamber = entity.chamber.ToLower();
            PoliticianCard pol;

            if (chamber == "senate")
                pol = new SenatorCard();
            else
                pol = new RepresentativeCard();

            pol.ID = entity.id;
            pol.FirstName = entity.first_name;
            pol.LastName = entity.last_name;
            pol.Party = entity.party;
            pol.State = entity.state;
            pol.StartDate = DateTime.ParseExact(entity.start_date, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            if (!string.IsNullOrEmpty(entity.middle_name))
                pol.MiddleName = entity.middle_name;

            if (chamber == "senate")
                return pol;
            else
                return ConvertRepresentative((RepresentativeCard) pol, entity);
        }

        private static RepresentativeCard ConvertRepresentative(RepresentativeCard rep, ApiNewMembers entity)
        {
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

            return rep;
        }
    }
}
