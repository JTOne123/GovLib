using System;
using System.Globalization;
using Gov.NET.Models;
using Gov.NET.Util;
using AutoMapper;

namespace Gov.NET.ProPublica.ApiModels
{
    public class ApiAllSenators : ApiAllMembers
    {
        private static readonly MapperConfiguration _mapperConfig =
            new MapperConfiguration(cfg => cfg.CreateMap<Politician, Senator>());
        private static readonly IMapper _mapper = _mapperConfig.CreateMapper();

        public string senate_class { get; set; }
        public string state_rank { get; set; }

        public static Senator Convert(ApiAllSenators entity)
        {
            var sen = _mapper.Map<Senator>(ApiAllMembers.Convert(entity));

            sen.Class = Int32.Parse(entity.senate_class);

            if (sen.InOffice)
            {
                sen.Rank = Text.Capitalize(entity.state_rank);
            }
            
            return sen;
        }
    }
}
