using System.Linq;
using FakeItEasy;
using PubSubLib.Interfaces;
using PubSubLib.Memory;
using Xunit;

namespace PubSubTests
{
    public class SubscriberTests
    {
        private IMessageHub _hub;

        public SubscriberTests()
        {
            _hub = A.Fake<IMessageHub>();
        }

        [Fact]
        public void Test_Subscriber_Receives_Message()
        {
            // Arrange
            var sub = new MemorySubscriber<int>(_hub);
            var expected = 1;
            
            //Assert (deferred)
            sub.OnChange += x => Assert.Equal(x, expected);

            A.CallTo(() => _hub.Publish(A.Dummy<int>())).WithAnyArguments().Invokes(x =>
            {
                var val = (int) x.Arguments.First();
                    sub.OnChange(val);
                });

            // Act
            _hub.Publish(expected);
        }
    }
}