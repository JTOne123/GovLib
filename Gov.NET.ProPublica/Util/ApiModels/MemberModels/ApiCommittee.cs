using System;

namespace Gov.NET.ProPublica.Util.MemberModels
{
    internal class ApiCommittee
    {
        public string name {get;set;}
        public string code {get;set;}
        public string api_url {get;set;}
        public string rank_in_party {get;set;}
        public string begin_date{get;set;}
        public string end_date {get;set;}
    }
}
