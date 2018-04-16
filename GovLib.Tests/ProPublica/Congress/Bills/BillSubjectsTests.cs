using GovLib.ProPublica;
using Xunit;

namespace GovLib.Tests.ProPublica.Congress.Bills
{
    [Collection("ProPublica Test Collection")]
    public class BillSubjectsTests : IClassFixture<CongressFixture>
    {
        public BillSubject[] Subjects { get; }

        public BillSubjectsTests(CongressFixture fixture)
        {
            Subjects = fixture.Congress.Bills.GetBillSubjects(115, "hr2810");
        }

        [Fact]
        public void CollectionIsNotNull()
        {
            Assert.NotNull(Subjects);
        }

        [Fact]
        public void CollectionIsNotEmpty()
        {
            Assert.NotEmpty(Subjects);
        }

        [Fact]
        public void BillSubjectsHaveAName()
        {
            foreach (var subject in Subjects)
                Assert.NotNull(subject.Name);
        }

        [Fact]
        public void BillSubjectsHaveAUrlName()
        {
            foreach (var subject in Subjects)
                Assert.NotNull(subject.UrlName);
        }
    }
}