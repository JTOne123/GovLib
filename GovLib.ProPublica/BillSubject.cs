using System;
using System.Globalization;
using Newtonsoft.Json;

namespace GovLib.ProPublica.Util.ApiModels.BillModels
{
    public class BillSubject
    {
        public string Name { get; set; }
        public string UrlName { get; set; }
    }
}