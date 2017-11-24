using System;
using System.Linq;
using System.Net;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Gov.NET;
using Gov.NET.Models;
using Gov.NET.ProPublica;
using Gov.NET.ProPublica.Urls;
using Gov.NET.ProPublica.ApiModels;
using Gov.NET.ProPublica.ApiModels.Wrappers;
using Gov.NET.Common.Models.Cards;

namespace Gov.NET.ProPublica.Util
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
                var url = string.Format(MemberUrls.AllMembers, congressNum, "senate");
                var result = client.Get<ResultWrapper<AllSenatorsWrapper>>(url, _parent.Headers);
                return result?.results?[0].members?.Select(s => ApiAllSenators.Convert(s)).ToArray();
            }
        }

        public Representative[] GetAllRepresentatives(int congressNum)
        {
            using (var client = new HttpClient())
            {
                var url = string.Format(MemberUrls.AllMembers, congressNum, "house");
                var result = client.Get<ResultWrapper<AllRepsWrapper>>(url, _parent.Headers);
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

        public RepresentativeCard GetRepresentaiveFromDistrict(string state, int district)
        {
            using (var client = new HttpClient())
            {
                var url = string.Format(MemberUrls.RepresentativeFromDistrict, state, district);
                var result = client.Get<ResultWrapper<ApiRepresentativesByState>>(url, _parent.Headers);
                return result?.results?.Select(r => ApiRepresentativesByState.Convert(r, state)).FirstOrDefault();
            }
        }

        public JObject GetSenatorsLeavingOffice(int congressNum)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("X-API-Key", _parent.ApiKey);
                var url = string.Format(MemberUrls.Leaving,  congressNum, "senate");
                var jsonStr = wc.DownloadString(url);
                return JObject.Parse(jsonStr);
            }
        }

        public JObject GetRepsLeavingOffice(int congressNum)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("X-API-Key", _parent.ApiKey);
                var url = string.Format(MemberUrls.Leaving, congressNum, "house");
                var jsonStr = wc.DownloadString(url);
                return JObject.Parse(jsonStr);
            }
        }

        public JObject GetVotingRecord(string govTrackID)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("X-API-Key", _parent.ApiKey);
                var url = string.Format(MemberUrls.VoteRecord, govTrackID);
                var jsonStr = wc.DownloadString(url);
                return JObject.Parse(jsonStr);
            }
        }

        public JObject CompareVotes(Senator s1, Senator s2, int congressNum)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("X-API-Key", _parent.ApiKey);
                var url = string.Format(MemberUrls.CompVote, s1.ID, s2.ID, congressNum, "senate");
                var jsonStr = wc.DownloadString(url);
                return JObject.Parse(jsonStr);
            }
        }

        public JObject CompareVotes(Representative r1, Representative r2, int congressNum)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("X-API-Key", _parent.ApiKey);
                var url = string.Format(MemberUrls.CompVote, r1.ID, r2.ID, congressNum, "house");
                var jsonStr = wc.DownloadString(url);
                return JObject.Parse(jsonStr);
            }
        }

        public JObject CompareSponsorship(Senator s1, Senator s2, int congressNum)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("X-API-Key", _parent.ApiKey);
                var url = string.Format(MemberUrls.CompSponsor, s1.ID, s2.ID, congressNum, "senate");
                var jsonStr = wc.DownloadString(url);
                return JObject.Parse(jsonStr);
            }
        }

        public JObject CompareSponsorship(Representative r1, Representative r2, int congressNum)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("X-API-Key", _parent.ApiKey);
                var url = string.Format(MemberUrls.CompSponsor, r1.ID, r2.ID, congressNum, "house");
                var jsonStr = wc.DownloadString(url);
                return JObject.Parse(jsonStr);
            }
        }

        public JObject GetCosponsoredBills(Senator s)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("X-API-Key", _parent.ApiKey);
                var url = string.Format(MemberUrls.Cosponsor, s.ID, "cosponsored");
                var jsonStr = wc.DownloadString(url);
                return JObject.Parse(jsonStr);
            }
        }

        public JObject GetCosponsoredBills(Representative r)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("X-API-Key", _parent.ApiKey);
                var url = string.Format(MemberUrls.Cosponsor, r.ID, "cosponsored");
                var jsonStr = wc.DownloadString(url);
                return JObject.Parse(jsonStr);
            }
        }

        public JObject GetWithdrawnBills(Senator s)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("X-API-Key", _parent.ApiKey);
                var url = string.Format(MemberUrls.Cosponsor, s.ID, "withdrawn");
                var jsonStr = wc.DownloadString(url);
                return JObject.Parse(jsonStr);
            }
        }

        public JObject GetWithdrawnBills(Representative r)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("X-API-Key", _parent.ApiKey);
                var url = string.Format(MemberUrls.Cosponsor, r.ID, "withdrawn");
                var jsonStr = wc.DownloadString(url);
                return JObject.Parse(jsonStr);
            }
        }




        public JObject GetCosponsoredBills(string r)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("X-API-Key", _parent.ApiKey);
                var url = string.Format(MemberUrls.Cosponsor, r, "cosponsored");
                var jsonStr = wc.DownloadString(url);
                return JObject.Parse(jsonStr);
            }
        }

        public JObject GetWithdrawnBills(string s)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("X-API-Key", _parent.ApiKey);
                var url = string.Format(MemberUrls.Cosponsor, s, "withdrawn");
                var jsonStr = wc.DownloadString(url);
                return JObject.Parse(jsonStr);
            }
        }

        public JObject CompareSenSponsorship(string s1, string s2, int congressNum)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("X-API-Key", _parent.ApiKey);
                var url = string.Format(MemberUrls.CompSponsor, s1, s2, congressNum, "senate");
                var jsonStr = wc.DownloadString(url);
                return JObject.Parse(jsonStr);
            }
        }

        public JObject CompareRepSponsorship(string r1, string r2, int congressNum)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("X-API-Key", _parent.ApiKey);
                var url = string.Format(MemberUrls.CompSponsor, r1, r2, congressNum, "senate");
                var jsonStr = wc.DownloadString(url);
                return JObject.Parse(jsonStr);
            }
        }

        public JObject CompareSenVotes(string s1, string s2, int congressNum)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("X-API-Key", _parent.ApiKey);
                var url = string.Format(MemberUrls.CompVote, s1, s2, congressNum, "senate");
                var jsonStr = wc.DownloadString(url);
                return JObject.Parse(jsonStr);
            }
        }

        public JObject CompareRepVotes(string r1, string r2, int congressNum)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("X-API-Key", _parent.ApiKey);
                var url = string.Format(MemberUrls.CompVote, r1, r2, congressNum, "house");
                var jsonStr = wc.DownloadString(url);
                return JObject.Parse(jsonStr);
            }
        }
    }
}
