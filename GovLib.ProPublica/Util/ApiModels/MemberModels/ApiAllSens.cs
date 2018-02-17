using System;
using System.Globalization;
using GovLib.Contracts;
using GovLib.Util;
using AutoMapper;
using Newtonsoft.Json;

namespace GovLib.ProPublica.Util.MemberModels
{
    internal class ApiAllSenators : ApiAllMembers
    {
        private static readonly IMapper _mapper = 
            new MapperConfiguration(cfg => cfg.CreateMap<Politician, Senator>()).CreateMapper();
            
        [JsonProperty("senate_class")]
        public string SenateClass { get; set; }

        [JsonProperty("state_rank")]
        public string StateRank { get; set; }

        internal static Senator Convert(ApiAllSenators entity)
        {
            var sen = _mapper.Map<Senator>(ApiAllMembers.Convert(entity, Chamber.Senate));

            sen.Class = Int32.Parse(entity.SenateClass);

            if (sen.InOffice)
            {
                if (entity.StateRank == "") sen.Rank = "Junior";
                else sen.Rank = TextHelper.Capitalize(entity.StateRank);
            }
            
            return sen;
        }
    }
}
