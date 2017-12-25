using System.Linq;
using System.Collections.Generic;
using GovLib.Contracts;
using GovLib.ProPublica.Urls;
using GovLib.ProPublica.Util;
using GovLib.ProPublica.Util.MemberModels;
using GovLib.Util;

namespace GovLib.ProPublica.Modules
{
    /// <summary>Get information about members of congress.</summary>
    public class MembersApi
    {
        private Congress _parent { get; }

        /// <summary>Stored information of senators retrieved so far.</summary>
        public Dictionary<string, Senator> Senators { get; }

        /// <summary>Stored information of representatives retrieved so far.</summary>
        public Dictionary<string, Representative> Representatives { get; }

        internal MembersApi(Congress parent)
        {
            _parent = parent;
            Senators = new Dictionary<string, Senator>();
            Representatives = new Dictionary<string, Representative>();
        }

        internal void ValidateCache(int congressNum)
        {
            if (!_parent.Cache.ContainsKey(congressNum))
                _parent.Cache[congressNum] = new MemberCache(congressNum);
        }

        internal void PopulateCache(int congressNum)
        {
            ValidateCache(congressNum);
            
            if (!_parent.Cache[congressNum].Senators.Any())
                GetAllSenators(congressNum);
            if (!_parent.Cache[congressNum].Representatives.Any())
                GetAllRepresentatives(congressNum);
        }

        /// <summary>Fetch all senators from the current congress session.</summary>
        public Senator[] GetAllSenators()
        {
            return GetAllSenators(_parent.CurrentCongress);
        }

        /// <summary>Fetch all senators from given congress session.</summary>
        public Senator[] GetAllSenators(int congressNum)
        {
            ValidateCache(congressNum);

            using (var client = new HttpClient())
            {
                var url = string.Format(MemberUrls.AllSenators, congressNum);
                var result = client.Get<ResultWrapper<MembersWrapper<ApiAllSenators>>>(url, _parent.Headers);
                var sens = result?.results?[0].members?.Select(s => ApiAllSenators.Convert(s));
                _parent.Cache[congressNum].UpdateMembers(sens);
                return sens.ToArray();
            }
        }

        /// <summary>Fetch all senators from the current congress session.</summary>
        public Representative[] GetAllRepresentatives()
        {
            return GetAllRepresentatives(_parent.CurrentCongress);
        }

        /// <summary>Fetch all representatives from given congress session.</summary>
        public Representative[] GetAllRepresentatives(int congressNum)
        {
            ValidateCache(congressNum);

            using (var client = new HttpClient())
            {
                var url = string.Format(MemberUrls.AllRepresentatives, congressNum);
                var result = client.Get<ResultWrapper<MembersWrapper<ApiAllReps>>>(url, _parent.Headers);
                var reps = result?.results?[0].members?.Where(r => r.IsVotingMember()).Select(r => ApiAllReps.Convert(r));
                _parent.Cache[congressNum].UpdateMembers(reps);
                return reps.ToArray();
            }
        }

        /// <summary>Find congress member by BioGuide ID.</summary>
        public Politician GetMemberByID(string id)
        {
            PopulateCache(_parent.CurrentCongress);
            
            using (var client = new HttpClient())
            {
                var url = string.Format(MemberUrls.Member, id);
                var result = client.Get<ResultWrapper<ApiMember>>(url, _parent.Headers);
                return result?.results?.Where(r => r.IsVotingMember()).Select(p => ApiMember.Convert(p)).FirstOrDefault();
            }
        }

        /// <summary>Get full Politician info from a contract.</summary>
        public Politician GetMemberByID(ICongressMember politician)
        {
            return GetMemberByID(politician.CongressID);
        }

        /// <summary>Fetch new congress members from given congress session.</summary>
        public Politician[] GetNewMembers()
        {
            PopulateCache(_parent.CurrentCongress);

            using (var client = new HttpClient())
            {
                var url = MemberUrls.NewMembers;
                var result = client.Get<ResultWrapper<NewMembersWrapper>>(url, _parent.Headers);
                var newMembers = result?.results?[0].members?.Where(r => r.IsVotingMember());
                return newMembers.Select(m => _parent.Cache[_parent.CurrentCongress].Search(m.id)).Where(m => m != null).ToArray();
            }
        }

        /// <summary>Fetch both current senators from the given state enum.</summary>
        public Senator[] GetSenatorsByState(State state)
        {
            return GetSenatorsByState(EnumConvert.StateEnumToCode(state));
        }

        /// <summary>Fetch both current senators from the given state.</summary>
        public Senator[] GetSenatorsByState(string state)
        {
            PopulateCache(_parent.CurrentCongress);

            using (var client = new HttpClient())
            {
                var url = string.Format(MemberUrls.SenatorsByState, state);
                var result = client.Get<ResultWrapper<ApiSenatorsByState>>(url, _parent.Headers);
                return result?.results?.Select(s => _parent.Cache[_parent.CurrentCongress].Senators[s.id]).ToArray();
            }
        }

        /// <summary>Fetch all current representatives from the given state enum.</summary>
        public Representative[] GetRepresentaivesByState(State state)
        {
            return GetRepresentaivesByState(EnumConvert.StateEnumToCode(state));
        }

        /// <summary>Fetch all current representatives from the given state.</summary>
        public Representative[] GetRepresentaivesByState(string state)
        {
            PopulateCache(_parent.CurrentCongress);

            using (var client = new HttpClient())
            {
                var url = string.Format(MemberUrls.RepresentativesByState, state);
                var result = client.Get<ResultWrapper<ApiRepresentativesByState>>(url, _parent.Headers);
                return result?.results?.Select(r => _parent.Cache[_parent.CurrentCongress].Representatives[r.id]).ToArray();
            }
        }

        /// <summary>Fetch current representative from the given state enum and district.</summary>
        public Representative GetRepresentiveFromDistrict(State state, int district)
        {
            return GetRepresentiveFromDistrict(EnumConvert.StateEnumToCode(state), district);
        }

        /// <summary>Fetch current representative from the given state and district.</summary>
        public Representative GetRepresentiveFromDistrict(string state, int district)
        {
            PopulateCache(_parent.CurrentCongress);

            using (var client = new HttpClient())
            {
                var url = string.Format(MemberUrls.RepresentativeFromDistrict, state, district);
                var result = client.Get<ResultWrapper<ApiRepresentativesByState>>(url, _parent.Headers);
                return result?.results?.Select(r => _parent.Cache[_parent.CurrentCongress].Representatives[r.id]).FirstOrDefault();
            }
        }

        /// <summary>Fetch all senators from the current congress session.</summary>
        public Senator[] GetSenatorsLeavingOffice()
        {
            return GetSenatorsLeavingOffice(_parent.CurrentCongress);
        }

        /// <summary>Fetch senators that were leaving office during the given congress session.</summary>
        public Senator[] GetSenatorsLeavingOffice(int congressNum)
        {
            PopulateCache(_parent.CurrentCongress);

            using (var client = new HttpClient())
            {
                var url = string.Format(MemberUrls.SenatorsLeaving, congressNum);
                var result = client.Get<ResultWrapper<MembersWrapper<ApiSenatorsLeaving>>>(url, _parent.Headers);
                return result?.results?[0].members.Select(s => _parent.Cache[_parent.CurrentCongress].Senators[s.id]).ToArray();
            }
        }

        /// <summary>Fetch all senators from the current congress session.</summary>
        public Representative[] GetRepresentativesLeavingOffice()
        {
            return GetRepresentativesLeavingOffice(_parent.CurrentCongress);
        }

        /// <summary>Fetch representatives that were leaving office during the given congress session.</summary>
        public Representative[] GetRepresentativesLeavingOffice(int congressNum)
        {
            PopulateCache(_parent.CurrentCongress);

            using (var client = new HttpClient())
            {
                var url = string.Format(MemberUrls.RepresentativesLeaving, congressNum);
                var result = client.Get<ResultWrapper<MembersWrapper<ApiRepsLeaving>>>(url, _parent.Headers);
                return result?.results?[0].members.Select(r => _parent.Cache[_parent.CurrentCongress].Representatives[r.id]).ToArray();
            }
        }
    }
}
