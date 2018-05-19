using System;
using System.Globalization;
using Newtonsoft.Json;

namespace GovLib.ProPublica.Util.ApiModels.BillModels
{
    internal class ApiSubject
    {
        [JsonProperty("name")]
        internal string Name { get; set; }

        [JsonProperty("url_name")]
        internal string UrlName { get; set; }

        internal static BillSubject Convert(ApiSubject entity)
        {
            return new BillSubject
            {
                Name = entity.Name,
                UrlName = entity.UrlName
            };
        }
    }
}