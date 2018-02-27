using System.Linq;
using System.Collections.Generic;
using GovLib.Contracts;
using GovLib.ProPublica.Urls;
using GovLib.ProPublica.Util;
using GovLib.ProPublica.Util.MemberModels;
using GovLib.Util;
using GovLib.ProPublica.Util.ApiModels.Wrappers;
using Newtonsoft.Json;

namespace GovLib.ProPublica.Modules
{
    /// <summary>
    /// Get information about members of congress.
    /// </summary>
    public class MembersApi
    {
        private Congress _parent { get; }

        /// <summary>
        /// Stored information of senators retrieved so far.
        /// </summary>
        public Dictionary<string, Senator> Senators { get; }

        /// <summary>
        /// Stored information of representatives retrieved so far.
        /// </summary>
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

        /// <summary>
        /// Fetch all senators from the current congress session.
        /// </summary>
        /// <returns><see cref="Senator" />array</returns>
        public Senator[] GetAllSenators()
        {
            return GetAllSenators(_parent.CurrentCongress);
        }

        /// <summary>
        /// Fetch all senators from given congress session.
        /// </summary>
        /// <param name="congressNum">Congress number</param>
        /// <returns><see cref="Senator" />array.</returns>
        public Senator[] GetAllSenators(int congressNum)
        {
            ValidateCache(congressNum);

            var url = string.Format(MemberUrls.AllSenators, congressNum);
            var result = _parent.HttpClient.Get(url, _parent.Headers);
            var json = JsonConvert.DeserializeObject<ResultWrapper<MembersWrapper<ApiAllSenators>>>(result);
            var sens = json?.Results?[0].Members?.Select(s => ApiAllSenators.Convert(s));
            _parent.Cache[congressNum].UpdateMembers(sens);
            return sens.ToArray();
        }

        /// <summary>
        /// Fetch all representatives from the current congress session.
        /// </summary>
        /// <returns><see cref="Representative" />array.</returns>
        public Representative[] GetAllRepresentatives()
        {
            return GetAllRepresentatives(_parent.CurrentCongress);
        }

        /// <summary>
        /// Fetch all representatives from given congress session.
        /// </summary>
        /// <param name="congressNum">Congress number</param>
        /// <returns><see cref="Representative" />array.</returns>
        public Representative[] GetAllRepresentatives(int congressNum)
        {
            ValidateCache(congressNum);

            var url = string.Format(MemberUrls.AllRepresentatives, congressNum);
            var result = _parent.HttpClient.Get(url, _parent.Headers);
            var json = JsonConvert.DeserializeObject<ResultWrapper<MembersWrapper<ApiAllReps>>>(result);
            var reps = json?.Results?[0].Members?.Where(r => r.IsVotingMember()).Select(r => ApiAllReps.Convert(r));
            _parent.Cache[congressNum].UpdateMembers(reps);
            return reps.ToArray();
        }

        /// <summary>
        /// Find congress member by BioGuide ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns><see cref="Politician" /></returns>
        public Politician GetMemberByID(string id)
        {
            PopulateCache(_parent.CurrentCongress);

            var url = string.Format(MemberUrls.Member, id);
            var result = _parent.HttpClient.Get(url, _parent.Headers);
            var json = JsonConvert.DeserializeObject<ResultWrapper<ApiMember>>(result);
            return json?.Results?.Where(r => r.IsVotingMember()).Select(p => ApiMember.Convert(p)).FirstOrDefault();
        }

        /// <summary>
        /// Get full Politician info from a contract.
        /// </summary>
        /// <param name="politician"><see cref="ICongressMember" /></param>
        /// <returns><see cref="Politician" /></returns>
        public Politician GetMemberByID(ICongressMember politician)
        {
            return GetMemberByID(politician.CongressID);
        }

        /// <summary>
        /// Fetch new congress members from given congress session.
        /// </summary>
        /// <returns><see cref="Politician" /></returns>
        public Politician[] GetNewMembers()
        {
            PopulateCache(_parent.CurrentCongress);

            var url = MemberUrls.NewMembers;
            var result = _parent.HttpClient.Get(url, _parent.Headers);
            var json = JsonConvert.DeserializeObject<ResultWrapper<NewMembersWrapper>>(result);
            var newMembers = json?.Results?[0].Members?.Where(r => r.IsVotingMember());
            return newMembers.Select(m => _parent.Cache[_parent.CurrentCongress].Search(m.ID)).Where(m => m != null).ToArray();
        }

        /// <summary>
        /// Fetch both current senators from the given state enum.
        /// </summary>
        /// <param name="state"><see cref="State" /></param>
        /// <returns><see cref="Senator" />array.</returns>
        public Senator[] GetSenatorsByState(State state)
        {
            return GetSenatorsByState(EnumConvert.StateEnumToCode(state));
        }

        /// <summary>
        /// Fetch both current senators from the given state.
        /// </summary>
        /// <param name="state">State code.</param>
        /// <returns><see cref="Senator" />array.</returns>
        public Senator[] GetSenatorsByState(string state)
        {
            PopulateCache(_parent.CurrentCongress);

            var url = string.Format(MemberUrls.SenatorsByState, state);
            var result = _parent.HttpClient.Get(url, _parent.Headers);
            var json = JsonConvert.DeserializeObject<ResultWrapper<ApiSenatorsByState>>(result);
            return json?.Results?.Select(s => _parent.Cache[_parent.CurrentCongress].Senators[s.ID]).ToArray();
        }

        /// <summary>
        /// Fetch all current representatives from the given state enum.
        /// </summary>
        /// <param name="state"><see cref="State" /></param>
        /// <returns><see cref="Representative" />array.</returns>
        public Representative[] GetRepresentativesByState(State state)
        {
            return GetRepresentaivesByState(EnumConvert.StateEnumToCode(state));
        }

        /// <summary>
        /// Fetch all current representatives from the given state.
        /// </summary>
        /// <param name="state">State code.</param>
        /// <returns><see cref="Representative" />array.</returns>
        public Representative[] GetRepresentaivesByState(string state)
        {
            PopulateCache(_parent.CurrentCongress);

            var url = string.Format(MemberUrls.RepresentativesByState, state);
            var result = _parent.HttpClient.Get(url, _parent.Headers);
            var json = JsonConvert.DeserializeObject<ResultWrapper<ApiRepresentativesByState>>(result);
            return json?.Results?.Select(r => _parent.Cache[_parent.CurrentCongress].Representatives[r.ID]).ToArray();
        }

        /// <summary>
        /// Fetch current representative from the given state enum and district.
        /// </summary>
        /// <param name="state"><see cref="State" /></param>
        /// <param name="district">District number.</param>
        /// <returns><see cref="Representative" /></returns>
        public Representative GetRepresentiveFromDistrict(State state, int district)
        {
            return GetRepresentiveFromDistrict(EnumConvert.StateEnumToCode(state), district);
        }

        /// <summary>
        /// Fetch current representative from the given state and district.
        /// </summary>
        /// <param name="state">State code.</param>
        /// <param name="district">District number.</param>
        /// <returns><see cref="Representative" /></returns>
        public Representative GetRepresentiveFromDistrict(string state, int district)
        {
            PopulateCache(_parent.CurrentCongress);

            var url = string.Format(MemberUrls.RepresentativeFromDistrict, state, district);
            var result = _parent.HttpClient.Get(url, _parent.Headers);
            var json = JsonConvert.DeserializeObject<ResultWrapper<ApiRepresentativeFromDistrict>>(result);
            return json?.Results?.Select(r => _parent.Cache[_parent.CurrentCongress].Representatives[r.ID]).FirstOrDefault();
        }

        /// <summary>
        /// Fetch all senators from the current congress session.
        /// </summary>
        /// <returns><see cref="Senator" />array.</returns>
        public Senator[] GetSenatorsLeavingOffice()
        {
            return GetSenatorsLeavingOffice(_parent.CurrentCongress);
        }

        /// <summary>
        /// Fetch senators that were leaving office during the given congress session.
        /// </summary>
        /// <param name="congressNum">Congress number</param>
        /// <returns><see cref="Senator" />array.</returns>
        public Senator[] GetSenatorsLeavingOffice(int congressNum)
        {
            PopulateCache(_parent.CurrentCongress);

            var url = string.Format(MemberUrls.SenatorsLeaving, congressNum);
            var result = _parent.HttpClient.Get(url, _parent.Headers);
            var json = JsonConvert.DeserializeObject<ResultWrapper<MembersWrapper<ApiSenatorsLeaving>>>(result);
            return json?.Results?[0].Members.Select(s => _parent.Cache[_parent.CurrentCongress].Senators[s.ID]).ToArray();
        }

        /// <summary>
        /// Fetch all senators from the current congress session.
        /// </summary>
        /// <returns><see cref="Representative" />array.</returns>
        public Representative[] GetRepresentativesLeavingOffice()
        {
            return GetRepresentativesLeavingOffice(_parent.CurrentCongress);
        }

        /// <summary>
        /// Fetch representatives that were leaving office during the given congress session.
        /// </summary>
        /// <param name="congressNum">Congress number</param>
        /// <returns><see cref="Representative" />array.</returns>
        public Representative[] GetRepresentativesLeavingOffice(int congressNum)
        {
            PopulateCache(_parent.CurrentCongress);

            var url = string.Format(MemberUrls.RepresentativesLeaving, congressNum);
            var result = _parent.HttpClient.Get(url, _parent.Headers);
            var json = JsonConvert.DeserializeObject<ResultWrapper<MembersWrapper<ApiRepsLeaving>>>(result);
            return json?.Results?[0].Members.Select(r => _parent.Cache[_parent.CurrentCongress].Representatives[r.ID]).ToArray();
        }
    }
}
