using FluentAssertions;

namespace Library.Tests.Unit
{
    public class DocumentTests
    {
        [Fact]
        public void Constructor_Should_Construct_Document_In_Draft_State()
        {
            var doc = new Document();
            doc.State.Should().BeOfType<DraftState>();
        }
    }
}