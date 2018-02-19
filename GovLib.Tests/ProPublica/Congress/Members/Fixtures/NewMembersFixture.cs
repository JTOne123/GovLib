using GovLib.ProPublica;

namespace GovLib.Tests.ProPublica.Congress.Members
{
    public class NewMembersFixture : CongressFixture
    {
        public Politician[] NewMembers { get; }

        public NewMembersFixture()
        {
            NewMembers = Congress.Members.GetNewMembers();
        }
    }
}