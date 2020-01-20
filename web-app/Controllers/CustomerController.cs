using business_layer;
using data_access_layer.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace web_app.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerManager _customerManager;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger, ICustomerManager customerManager)
        {
            _logger = logger;
            _customerManager = customerManager;
        }

        [HttpGet]
        public IEnumerable<CustomerDomainModel> Get()
        {
            return _customerManager.Get();
        }

        [HttpGet("/GetByAgent/{agentId}")]
        public IEnumerable<CustomerNameAddressDomainModel> GetByAgent(int agentId)
        {
            return _customerManager.GetByAgentId(agentId);
        }

        [HttpPost]
        public void Add(CustomerDomainModel customerDomainModel)
        {
            _customerManager.Add(customerDomainModel);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _customerManager.Delete(id);
        }

        [HttpPut]
        public void Update(CustomerDomainModel customerDomainModel)
        {
            _customerManager.Update(customerDomainModel);
        }

        [HttpPatch("{id}")]
        public void Patch(int id, [FromBody] JsonPatchDocument<CustomerDomainModel> customerDomainModel)
        {
            _customerManager.Patch(id, customerDomainModel);
        }

        [HttpGet("{id}")]
        public CustomerDomainModel FindById(int id)
        {
            return _customerManager.FindById(id);
        }
    }
}
