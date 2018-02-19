using GovLib.ProPublica;

namespace GovLib.Tests.ProPublica.Congress.Members
{
    public class SenatorsLeavingFixture : CongressFixture
    {
        public Senator[] Senators { get; }

        public SenatorsLeavingFixture()
        {
            Senators = Congress.Members.GetSenatorsLeavingOffice(115);
        }
    }
}