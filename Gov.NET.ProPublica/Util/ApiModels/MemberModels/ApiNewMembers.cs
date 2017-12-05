using System;
using Gov.NET.Models;
using System.Globalization;
using Gov.NET.Util;

namespace Gov.NET.ProPublica.Util.MemberModels
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

        public static PoliticianSummary Convert(ApiNewMembers entity)
        {
            if (entity == null)
                return null;

            var chamber = entity.chamber.ToLower();
            PoliticianSummary pol;

            if (chamber == "senate")
                pol = new SenatorSummary();
            else
                pol = new RepresentativeSummary();

            pol.ID = entity.id;
            pol.FirstName = entity.first_name;
            pol.LastName = entity.last_name;
            pol.Party = entity.party;
            pol.State = (State) EnumConvert.StateCodeToEnum(entity.state);

            if (!string.IsNullOrEmpty(entity.middle_name))
                pol.MiddleName = entity.middle_name;

            if (chamber == "senate")
                return pol;
            else
                return ConvertRepresentative((RepresentativeSummary) pol, entity);
        }

        private static RepresentativeSummary ConvertRepresentative(RepresentativeSummary rep, ApiNewMembers entity)
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
        
        internal bool IsVotingMember()
        {
            return EnumConvert.StateCodeToEnum(this.state) != null;
        }
    }
}
