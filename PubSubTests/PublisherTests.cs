using System;
using FakeItEasy;
using PubSubLib.Interfaces;
using PubSubLib.Memory;
using Xunit;

namespace PubSubTests
{
    public class PublisherTests
    {
        private IMessageHub _hub;

        public PublisherTests()
        {
            _hub = A.Fake<IMessageHub>();
        }
        
        [Fact]
        public void Test_Publish_Called_In_Hub()
        {
            // Arrange
            var publisher = new MemoryPublisher<int>(_hub);

            // Act
            publisher.Publish(1);

            //Assert
            A.CallTo(() => _hub.Publish(A.Dummy<int>())).WithAnyArguments().MustHaveHappened();
        }

        [Fact]
        public void Test_Publish_Called_With_Null_Hub()
        {
            // Arrange
            var publisher = new MemoryPublisher<int>(null);
            A.CallTo(() => _hub.Publish(A.Dummy<int>())).Throws<NullReferenceException>();
            
            // Act & Assert
            Assert.Throws<NullReferenceException>(() => publisher.Publish(1));
        }
    }
}