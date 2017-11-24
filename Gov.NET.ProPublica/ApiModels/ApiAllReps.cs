using System;
using System.Globalization;
using Gov.NET.Models;
using AutoMapper;

namespace Gov.NET.ProPublica.ApiModels
{
    public class ApiAllReps : ApiAllMembers
    {
        private static readonly MapperConfiguration _mapperConfig =
            new MapperConfiguration(cfg => cfg.CreateMap<Politician, Representative>());
        private static readonly IMapper _mapper = _mapperConfig.CreateMapper();

        public string district { get; set; }
        public bool at_large { get; set; }

        public static Representative Convert(ApiAllReps entity)
        {
            var rep = _mapper.Map<Representative>(ApiAllMembers.Convert(entity));

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
            return this.title == "Representative";
        }
    }
}
