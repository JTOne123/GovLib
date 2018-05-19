using System.Collections.Generic;
using GovLib.ProPublica;
using Xunit;

namespace GovLib.Tests.ProPublica.Congress.Members
{
    [Collection("ProPublica Test Collection")]
    public class BillCosponsorsTests : IClassFixture<CongressFixture>
    {
        public IEnumerable<string> BillCosponsors { get; }

        public BillCosponsorsTests(CongressFixture fixture)
        {
            BillCosponsors = fixture.Congress.Bills.GetBillCosponsors(115, "hr4249");
        }

        [Fact]
        public void CollectionIsNotNull()
        {
            Assert.NotNull(BillCosponsors);
        }

        [Fact]
        public void CollectionIsNotEmpty()
        {
            Assert.NotEmpty(BillCosponsors);
        }
    }
}