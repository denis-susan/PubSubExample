using FakeItEasy;
using PubSubLib.Interfaces;
using PubSubLib.Memory;
using Xunit;

namespace PubSubTests
{
    public class HubTests
    {
        [Fact]
        public void Test_Hub_Pushes_Message_To_Subscribers()
        {
            var hub = new MemoryHub();

            var subFake = A.Fake<ISubscriber<int>>();

            hub.Subscribe(subFake);
            
            hub.Publish(1);

            A.CallTo(() => subFake.OnChange).WithAnyArguments().MustHaveHappened();
        }
    }
}