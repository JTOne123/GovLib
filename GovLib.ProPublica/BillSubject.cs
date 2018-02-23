using System;
using System.Globalization;
using Newtonsoft.Json;

namespace GovLib.ProPublica
{
    /// <summary>
    /// Search term object.
    /// </summary>
    public class BillSubject
    {
        #pragma warning disable CS1591

        public string Name { get; set; }
        public string UrlName { get; set; }
    }
}