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
    public class CustomerManagerTests
    {
        [TestMethod]
        public void Get()
        {
            var mockCustomerRepository = new Mock<ICustomerRepository>();
            var fixture = new Fixture();
            var fakeCustomerDataModels = fixture.CreateMany<CustomerDataModel>(2);

            mockCustomerRepository.Setup(x => x.Get()).Returns(fakeCustomerDataModels);

            var agentManager = new CustomerManager(mockCustomerRepository.Object);

            var result = agentManager.Get().ToList();

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(fakeCustomerDataModels.First().Id, result.First().Id);
        }
    }
}
