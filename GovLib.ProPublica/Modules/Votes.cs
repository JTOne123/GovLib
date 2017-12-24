using System.Net;
using Newtonsoft.Json.Linq;
using GovLib.ProPublica.Urls;

namespace GovLib.ProPublica.Modules
{
    public class Votes
    {
        private Congress _parent { get; }

        internal Votes(Congress parent)
        {
            _parent = parent;
        }

        public JObject GetSenateRollCall(int congress, int session, int num)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("X-API-Key", _parent.ApiKey);
                var url = string.Format(VoteUrls.RollCall, congress, "senate", session, num);
                var jsonStr = wc.DownloadString(url);
                return JObject.Parse(jsonStr);
            }
        }

        public JObject GetHouseRollCall(int congress, int session, int num)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("X-API-Key", _parent.ApiKey);
                var url = string.Format(VoteUrls.RollCall, congress, "house", session, num);
                var jsonStr = wc.DownloadString(url);
                return JObject.Parse(jsonStr);
            }
        }

        public JObject GetSenateMissedVotes(int congress)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("X-API-Key", _parent.ApiKey);
                var url = string.Format(VoteUrls.RollCall, congress, "senate", "missed");
                var jsonStr = wc.DownloadString(url);
                return JObject.Parse(jsonStr);
            }
        }

        public JObject GetHouseMissedVotes(int congress)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("X-API-Key", _parent.ApiKey);
                var url = string.Format(VoteUrls.RollCall, congress, "house", "missed");
                var jsonStr = wc.DownloadString(url);
                return JObject.Parse(jsonStr);
            }
        }

        public JObject GetSenatePartyVotes(int congress)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("X-API-Key", _parent.ApiKey);
                var url = string.Format(VoteUrls.RollCall, congress, "senate", "party");
                var jsonStr = wc.DownloadString(url);
                return JObject.Parse(jsonStr);
            }
        }

        public JObject GetHousePartyVotes(int congress)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("X-API-Key", _parent.ApiKey);
                var url = string.Format(VoteUrls.RollCall, congress, "house", "party");
                var jsonStr = wc.DownloadString(url);
                return JObject.Parse(jsonStr);
            }
        }

        public JObject GetSenateLoneVotes(int congress)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("X-API-Key", _parent.ApiKey);
                var url = string.Format(VoteUrls.RollCall, congress, "senate", "loneno");
                var jsonStr = wc.DownloadString(url);
                return JObject.Parse(jsonStr);
            }
        }

        public JObject GetHouseLoneVotes(int congress)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("X-API-Key", _parent.ApiKey);
                var url = string.Format(VoteUrls.RollCall, congress, "house", "loneno");
                var jsonStr = wc.DownloadString(url);
                return JObject.Parse(jsonStr);
            }
        }

        public JObject GetSenatePerfectVotes(int congress)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("X-API-Key", _parent.ApiKey);
                var url = string.Format(VoteUrls.RollCall, congress, "senate", "perfect");
                var jsonStr = wc.DownloadString(url);
                return JObject.Parse(jsonStr);
            }
        }

        public JObject GetHousePerfectVotes(int congress)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("X-API-Key", _parent.ApiKey);
                var url = string.Format(VoteUrls.RollCall, congress, "house", "perfect");
                var jsonStr = wc.DownloadString(url);
                return JObject.Parse(jsonStr);
            }
        }

        public JObject GetSenateVotesByDate(int congress, int year, int month)
        {
            using (var wc = new WebClient())
            {
                var str = "";
                if (month < 10) str = $"0{month}";
                else str = month.ToString();
                wc.Headers.Add("X-API-Key", _parent.ApiKey);
                var url = string.Format(VoteUrls.RollCall, "senate", year, str);
                var jsonStr = wc.DownloadString(url);
                return JObject.Parse(jsonStr);
            }
        }

        public JObject GetHouseVotesByDate(int congress, int year, int month)
        {
            using (var wc = new WebClient())
            {
                var str = "";
                if (month < 10) str = $"0{month}";
                else str = month.ToString();
                wc.Headers.Add("X-API-Key", _parent.ApiKey);
                var url = string.Format(VoteUrls.RollCall, "house", year, str);
                var jsonStr = wc.DownloadString(url);
                return JObject.Parse(jsonStr);
            }
        }

        public JObject GetSenateVotesByRange(string d1, string d2)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("X-API-Key", _parent.ApiKey);
                var url = string.Format(VoteUrls.RollCall, "senate", d1, d2);
                var jsonStr = wc.DownloadString(url);
                return JObject.Parse(jsonStr);
            }
        }

        public JObject GetHouseVotesByRange(string d1, string d2)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("X-API-Key", _parent.ApiKey);
                var url = string.Format(VoteUrls.RollCall, "house", d1, d2);
                var jsonStr = wc.DownloadString(url);
                return JObject.Parse(jsonStr);
            }
        }

        public JObject GetNominationVotes(int congress)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("X-API-Key", _parent.ApiKey);
                var url = string.Format(VoteUrls.RollCall, congress);
                var jsonStr = wc.DownloadString(url);
                return JObject.Parse(jsonStr);
            }
        }
    }
}
