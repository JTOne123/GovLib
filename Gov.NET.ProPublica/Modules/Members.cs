using System;
using System.Linq;
using System.Net;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Gov.NET;
using Gov.NET.Models;
using Gov.NET.ProPublica;
using Gov.NET.ProPublica.Urls;
using Gov.NET.ProPublica.Util;
using Gov.NET.ProPublica.ApiModels;
using Gov.NET.ProPublica.ApiModels.Wrappers;
using Gov.NET.Common.Models.Cards;

namespace Gov.NET.ProPublica.Modules
{
    public class Members
    {
        private Congress _parent { get; }
        public Dictionary<string, Senator> Senators { get; }
        public Dictionary<string, Representative> Representatives { get; }

        internal Members(Congress parent)
        {
            _parent = parent;
            Senators = new Dictionary<string, Senator>();
            Representatives = new Dictionary<string, Representative>();
        }

        public Senator[] GetAllSenators(int congressNum)
        {
            using (var client = new HttpClient())
            {
                var url = string.Format(MemberUrls.AllSenators, congressNum);
                var result = client.Get<ResultWrapper<ContainerWrapper<ApiAllSenators>>>(url, _parent.Headers);
                return result?.results?[0].members?.Select(s => ApiAllSenators.Convert(s)).ToArray();
            }
        }

        public Representative[] GetAllRepresentatives(int congressNum)
        {
            using (var client = new HttpClient())
            {
                var url = string.Format(MemberUrls.AllRepresentatives, congressNum);
                var result = client.Get<ResultWrapper<ContainerWrapper<ApiAllReps>>>(url, _parent.Headers);
                return result?.results?[0].members?.Where(r => r.IsVotingMember()).Select(r => ApiAllReps.Convert(r)).ToArray();
            }
        }

        public Politician GetMemberByID(string id)
        {
            using (var client = new HttpClient())
            {
                var url = string.Format(MemberUrls.Member, id);
                var result = client.Get<ResultWrapper<ApiMember>>(url, _parent.Headers);
                return result?.results?.Select(p => ApiMember.Convert(p)).FirstOrDefault();
            }
        }

        public PoliticianCard[] GetNewMembers()
        {
            using (var client = new HttpClient())
            {
                var url = MemberUrls.NewMembers;
                var result = client.Get<ResultWrapper<NewMembersWrapper>>(url, _parent.Headers);
                return result?.results?[0].members?.Select(m => ApiNewMembers.Convert(m)).ToArray();
            }
        }

        public SenatorCard[] GetSenatorsByState(string state)
        {
            using (var client = new HttpClient())
            {
                var url = string.Format(MemberUrls.SenatorsByState, state);
                var result = client.Get<ResultWrapper<ApiSenatorsByState>>(url, _parent.Headers);
                return result?.results?.Select(s => ApiSenatorsByState.Convert(s, state)).ToArray();
            }
        }

        public RepresentativeCard[] GetRepresentaivesByState(string state)
        {
            using (var client = new HttpClient())
            {
                var url = string.Format(MemberUrls.RepresentativesByState, state);
                var result = client.Get<ResultWrapper<ApiRepresentativesByState>>(url, _parent.Headers);
                return result?.results?.Select(r => ApiRepresentativesByState.Convert(r, state)).ToArray();
            }
        }

        public RepresentativeCard GetRepresentiveFromDistrict(string state, int district)
        {
            using (var client = new HttpClient())
            {
                var url = string.Format(MemberUrls.RepresentativeFromDistrict, state, district);
                var result = client.Get<ResultWrapper<ApiRepresentativesByState>>(url, _parent.Headers);
                return result?.results?.Select(r => ApiRepresentativesByState.Convert(r, state)).FirstOrDefault();
            }
        }

        public SenatorCard[] GetSenatorsLeavingOffice(int congressNum)
        {
            using (var client = new HttpClient())
            {
                var url = string.Format(MemberUrls.SenatorsLeaving, congressNum);
                var result = client.Get<ResultWrapper<ContainerWrapper<ApiSenatorsLeaving>>>(url, _parent.Headers);
                return result?.results?[0].members.Select(r => ApiSenatorsLeaving.Convert(r)).ToArray();
            }
        }

        public RepresentativeCard[] GetRepresentativesLeavingOffice(int congressNum)
        {
            using (var client = new HttpClient())
            {
                var url = string.Format(MemberUrls.RepresentativesLeaving, congressNum);
                var result = client.Get<ResultWrapper<ContainerWrapper<ApiRepsLeaving>>>(url, _parent.Headers);
                return result?.results?[0].members.Select(r => ApiRepsLeaving.Convert(r)).ToArray();
            }
        }
    }
}
