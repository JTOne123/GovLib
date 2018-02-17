using System;
using System.Globalization;
using GovLib.Contracts;
using AutoMapper;
using Newtonsoft.Json;

namespace GovLib.ProPublica.Util.MemberModels
{
    internal class ApiAllReps : ApiAllMembers
    {
        private static readonly MapperConfiguration _mapperConfig =
            new MapperConfiguration(cfg => cfg.CreateMap<Politician, Representative>());
        private static readonly IMapper _mapper = _mapperConfig.CreateMapper();

        [JsonProperty("district")]
        public string District { get; set; }

        [JsonProperty("at_large")]
        public bool AtLarge { get; set; }

        internal static Representative Convert(ApiAllReps entity)
        {
            var rep = _mapper.Map<Representative>(ApiAllMembers.Convert(entity, Chamber.House));

            if (entity.District == "At-Large")
            {
                rep.District = 1;
                rep.AtLargeDistrict = true;
            }
            else
            {
                rep.District = Int32.Parse(entity.District);
                rep.AtLargeDistrict = false;
            }
            
            return rep;
        }

        internal bool IsVotingMember()
        {
            return this.Title == "Representative";
        }
    }
}
