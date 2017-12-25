using System;
using System.Globalization;
using GovLib.Contracts;
using GovLib.Util;
using AutoMapper;

namespace GovLib.ProPublica.Util.MemberModels
{
    internal class ApiAllSenators : ApiAllMembers
    {
        private static readonly IMapper _mapper = 
            new MapperConfiguration(cfg => cfg.CreateMap<Politician, Senator>()).CreateMapper();
            
        public string senate_class { get; set; }
        public string state_rank { get; set; }

        internal static Senator Convert(ApiAllSenators entity)
        {
            var sen = _mapper.Map<Senator>(ApiAllMembers.Convert(entity, Chamber.Senate));

            sen.Class = Int32.Parse(entity.senate_class);

            if (sen.InOffice)
            {
                sen.Rank = TextHelper.Capitalize(entity.state_rank);
            }
            
            return sen;
        }
    }
}
