using System.Net;
using Newtonsoft.Json.Linq;
using Gov.NET.ProPublica.Urls;

namespace Gov.NET.ProPublica.Modules
{
    public class Bills
    {
        private Congress _parent { get; }

        internal Bills(Congress parent)
        {
            _parent = parent;
        }
        
    }
}
