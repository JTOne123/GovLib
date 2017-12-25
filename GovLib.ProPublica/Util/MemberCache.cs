using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GovLib.ProPublica.Util
{
    internal class MemberCache
    {
        internal int CongressNum { get; }
        internal Dictionary<string, Senator> Senators { get; }
        internal Dictionary<string, Representative> Representatives { get; }

        internal MemberCache(int congressNum)
        {
            Senators = new Dictionary<string, Senator>();
            Representatives = new Dictionary<string, Representative>();
        }

        internal void UpdateMembers(IEnumerable<Senator> senators)
        {
            foreach (var senator in senators)
                Senators[senator.CongressID] = senator;
        }

        internal void UpdateMembers(IEnumerable<Representative> representatives)
        {
            foreach (var representative in representatives)
                Representatives[representative.CongressID] = representative;
        }

        internal void UpdateMember(Senator senator)
        {
            Senators[senator.CongressID] = senator;
        }

        internal void UpdateMember(Representative representative)
        {
            Representatives[representative.CongressID] = representative;
        }

        internal Politician Search(string id)
        {
            var memberInSenate = Senators.ContainsKey(id);
            var memberInHouse = Representatives.ContainsKey(id);
            
            if (memberInHouse && memberInSenate)
                return Senators[id];
            else if (memberInSenate)
                return Senators[id];
            else if (memberInHouse)
                return Representatives[id];
            else
                return null;
        }
    }
}