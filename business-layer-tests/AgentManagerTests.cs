using AutoFixture;
using business_layer;
using data_access_layer;
using data_access_layer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;

namespace business_layer_tests
{
    [TestClass]
    public class AgentManagerTests
    {
        [TestMethod]
        public void Get()
        {
            var mockAgentRepository = new Mock<IAgentRepository>();
            var fixture = new Fixture();
            var fakeAgentDataModels = fixture.CreateMany<AgentDataModel>(2);

            mockAgentRepository.Setup(x => x.Get()).Returns(fakeAgentDataModels);

            var agentManager = new AgentManager(mockAgentRepository.Object);

            var result = agentManager.Get().ToList();

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(fakeAgentDataModels.First().Id, result.First().Id);
        }
    }
}
