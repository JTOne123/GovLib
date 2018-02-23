using GovLib.ProPublica;
using Xunit;

namespace GovLib.Tests.ProPublica.Congress.Bills
{
    [Collection("MainTestCollection")]
    public class SubjectsByTerm : IClassFixture<CongressFixture>
    {
        public BillSubject[] Subjects { get; }

        public SubjectsByTerm(CongressFixture fixture)
        {
            Subjects = fixture.Congress.Bills.GetSubjects("climate");
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