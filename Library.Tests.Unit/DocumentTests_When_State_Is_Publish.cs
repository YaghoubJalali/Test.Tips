using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Tests.Unit
{
    public class DocumentTests_When_State_Is_Publish
    {
        private Document sut;
        public DocumentTests_When_State_Is_Publish()
        {
            sut = new Document();
            sut.Moderate();
            sut.Publish();
            sut.State.Should().BeOfType<PublishedState>();
        }

        public static IEnumerable<object[]> ValidTransitions()
        {
            return new List<object[]>
            {
                new object[] { new Action<Document>(a=> a.Archive()), typeof(ArchivedState)  },
            };
        }

        [Theory]
        [MemberData(nameof(ValidTransitions))]
        public void Should_change_state_on_valid_transitions(Action<Document> transitionAction, Type expectedState)
        {
            transitionAction.Invoke(sut);
            sut.State.Should().BeOfType(expectedState);
        }

        public static IEnumerable<object[]> InvalidTransitions()
        {
            return new List<object[]>
            {
                new object[] { new Action<Document>(a=> a.Moderate())},
                new object[] { new Action<Document>(a=> a.Draft())},
            };
        }

        [Theory]
        [MemberData(nameof(InvalidTransitions))]
        public void Should_throw_exception_on_invalid_transitions(Action<Document> transitionAction)
        {
            var action = new Action(() => transitionAction.Invoke(sut));

            action.Should().Throw<NotSupportedException>();
            sut.State.Should().BeOfType<PublishedState>();
        }
    }
}
