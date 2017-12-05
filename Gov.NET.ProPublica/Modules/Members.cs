using System.Linq;
using System.Collections.Generic;
using Gov.NET.Models;
using Gov.NET.ProPublica.Urls;
using Gov.NET.ProPublica.Util;
using Gov.NET.ProPublica.Util.MemberModels;
using Gov.NET.Util;

namespace Gov.NET.ProPublica.Modules
{
    /// <summary>Get information about members of congress.</summary>
    public class Members
    {
        private Congress _parent { get; }

        /// <summary>Stored information of senators retrieved so far.</summary>
        public Dictionary<string, Senator> Senators { get; }

        /// <summary>Stored information of representatives retrieved so far.</summary>
        public Dictionary<string, Representative> Representatives { get; }

        internal Members(Congress parent)
        {
            _parent = parent;
            Senators = new Dictionary<string, Senator>();
            Representatives = new Dictionary<string, Representative>();
        }

        /// <summary>Fetch all senators from given congress session.</summary>
        public Senator[] GetAllSenators(int congressNum)
        {
            using (var client = new HttpClient())
            {
                var url = string.Format(MemberUrls.AllSenators, congressNum);
                var result = client.Get<ResultWrapper<ContainerWrapper<ApiAllSenators>>>(url, _parent.Headers);
                return result?.results?[0].members?.Select(s => ApiAllSenators.Convert(s)).ToArray();
            }
        }

        /// <summary>Fetch all representatives from given congress session.</summary>
        public Representative[] GetAllRepresentatives(int congressNum)
        {
            using (var client = new HttpClient())
            {
                var url = string.Format(MemberUrls.AllRepresentatives, congressNum);
                var result = client.Get<ResultWrapper<ContainerWrapper<ApiAllReps>>>(url, _parent.Headers);
                return result?.results?[0].members?.Where(r => r.IsVotingMember()).Select(r => ApiAllReps.Convert(r)).ToArray();
            }
        }

        /// <summary>Find congress member by BioGuide ID.</summary>
        public Politician GetMemberByID(string id)
        {
            using (var client = new HttpClient())
            {
                var url = string.Format(MemberUrls.Member, id);
                var result = client.Get<ResultWrapper<ApiMember>>(url, _parent.Headers);
                return result?.results?.Where(r => r.IsVotingMember()).Select(p => ApiMember.Convert(p)).FirstOrDefault();
            }
        }

        /// <summary>Get full Politician info from a contract.</summary>
        public Politician GetMemberByID(IPolitician politician)
        {
            return GetMemberByID(politician.ID);
        }

        /// <summary>Fetch new congress members from given congress session.</summary>
        public PoliticianSummary[] GetNewMembers()
        {
            using (var client = new HttpClient())
            {
                var url = MemberUrls.NewMembers;
                var result = client.Get<ResultWrapper<NewMembersWrapper>>(url, _parent.Headers);
                return result?.results?[0].members?.Where(r => r.IsVotingMember()).Select(m => ApiNewMembers.Convert(m)).ToArray();
            }
        }

        /// <summary>Fetch both current senators from the given state enum.</summary>
        public SenatorSummary[] GetSenatorsByState(State state)
        {
            return GetSenatorsByState(EnumConvert.StateEnumToCode(state));
        }

        /// <summary>Fetch both current senators from the given state.</summary>
        public SenatorSummary[] GetSenatorsByState(string state)
        {
            using (var client = new HttpClient())
            {
                var url = string.Format(MemberUrls.SenatorsByState, state);
                var result = client.Get<ResultWrapper<ApiSenatorsByState>>(url, _parent.Headers);
                return result?.results?.Select(s => ApiSenatorsByState.Convert(s, state)).ToArray();
            }
        }

        /// <summary>Fetch all current representatives from the given state enum.</summary>
        public RepresentativeSummary[] GetRepresentaivesByState(State state)
        {
            return GetRepresentaivesByState(EnumConvert.StateEnumToCode(state));
        }

        /// <summary>Fetch all current representatives from the given state.</summary>
        public RepresentativeSummary[] GetRepresentaivesByState(string state)
        {
            using (var client = new HttpClient())
            {
                var url = string.Format(MemberUrls.RepresentativesByState, state);
                var result = client.Get<ResultWrapper<ApiRepresentativesByState>>(url, _parent.Headers);
                return result?.results?.Select(r => ApiRepresentativesByState.Convert(r, state)).ToArray();
            }
        }

        /// <summary>Fetch current representative from the given state enum and district.</summary>
        public RepresentativeSummary GetRepresentiveFromDistrict(State state, int district)
        {
            return GetRepresentiveFromDistrict(EnumConvert.StateEnumToCode(state), district);
        }

        /// <summary>Fetch current representative from the given state and district.</summary>
        public RepresentativeSummary GetRepresentiveFromDistrict(string state, int district)
        {
            using (var client = new HttpClient())
            {
                var url = string.Format(MemberUrls.RepresentativeFromDistrict, state, district);
                var result = client.Get<ResultWrapper<ApiRepresentativesByState>>(url, _parent.Headers);
                return result?.results?.Select(r => ApiRepresentativesByState.Convert(r, state)).FirstOrDefault();
            }
        }

        /// <summary>Fetch senators that were leaving office during the given congress session.</summary>
        public SenatorSummary[] GetSenatorsLeavingOffice(int congressNum)
        {
            using (var client = new HttpClient())
            {
                var url = string.Format(MemberUrls.SenatorsLeaving, congressNum);
                var result = client.Get<ResultWrapper<ContainerWrapper<ApiSenatorsLeaving>>>(url, _parent.Headers);
                return result?.results?[0].members.Select(r => ApiSenatorsLeaving.Convert(r)).ToArray();
            }
        }

        /// <summary>Fetch representatives that were leaving office during the given congress session.</summary>
        public RepresentativeSummary[] GetRepresentativesLeavingOffice(int congressNum)
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
