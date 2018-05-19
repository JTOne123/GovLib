using System.Collections.Generic;
using GovLib.ProPublica;
using Xunit;

namespace GovLib.Tests.ProPublica.Congress.Bills
{
    [Collection("ProPublica Test Collection")]
    public class SubjectsByTerm : IClassFixture<CongressFixture>
    {
        public IEnumerable<BillSubject> Subjects { get; }

        public SubjectsByTerm(CongressFixture fixture)
        {
            Subjects = fixture.Congress.Bills.GetSubjectsByTerm("climate");
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