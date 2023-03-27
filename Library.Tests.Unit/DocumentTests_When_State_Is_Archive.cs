using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Tests.Unit
{
    public class DocumentTests_When_State_Is_Archive
    {
        private Document sut;
        public DocumentTests_When_State_Is_Archive()
        {
            sut = new Document();
            sut.Moderate();
            sut.Publish();
            sut.Archive();
            sut.State.Should().BeOfType<ArchivedState>();
        }

        public static IEnumerable<object[]> InvalidTransitions()
        {
            return new List<object[]>
            {
                new object[] { new Action<Document>(a=> a.Moderate())},
                new object[] { new Action<Document>(a=> a.Publish())},
                new object[] { new Action<Document>(a=> a.Draft())},
            };
        }

        [Theory]
        [MemberData(nameof(InvalidTransitions))]
        public void Should_throw_exception_on_invalid_transitions(Action<Document> transitionAction)
        {
            var action = new Action(() => transitionAction.Invoke(sut));

            action.Should().Throw<NotSupportedException>();
            sut.State.Should().BeOfType<ArchivedState>();
        }
    }
}
