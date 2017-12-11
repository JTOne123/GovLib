using System.Net;
using Newtonsoft.Json.Linq;
using Gov.NET.ProPublica.Urls;
using Gov.NET.Models;
using Gov.NET.ProPublica.Util;
using Gov.NET.Util;
using Gov.NET.ProPublica.Util.ApiModels.BillModels;
using System.Linq;

namespace Gov.NET.ProPublica.Modules
{
    /// <summary> Get information about bills introduced to congress.</summary>
    public class Bills
    {
        private Congress _parent { get; }

        internal Bills(Congress parent)
        {
            _parent = parent;
        }

        /// <summary> Get recent bills by status.</summary>
        public Bill[] GetRecentBills(Chamber chamber, int congress, BillStatus status)
        {
            using (var client = new HttpClient())
            {
                var chamberString = EnumConvert.ChamberEnumToString(chamber);
                var statusString = EnumConvert.BillStatusEnumToString(status);
                var url = string.Format(BillUrls.RecentBills, congress, chamberString, statusString);
                var result = client.Get<ResultWrapper<BillsWrapper<ApiRecentBills>>>(url, _parent.Headers);
                return result?.results?[0].bills.Select(b => ApiRecentBills.Convert(b)).ToArray();
            }
        }
    }
}
