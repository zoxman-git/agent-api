using data_access_layer.Models;
using System.Collections.Generic;
using System.Linq;

namespace data_access_layer
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IRepository<CustomerDataModel> _customerRepository;

        public CustomerRepository(IRepository<CustomerDataModel> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IEnumerable<CustomerDataModel> Get()
        {
            return _customerRepository.Get();
        }

        public IEnumerable<CustomerDataModel> GetByAgentId(int agentId)
        {
            return _customerRepository.Get().Where(x => x.AgentId == agentId);
        }

        public void Add(CustomerDataModel customerDataModel)
        {
            _customerRepository.Add(customerDataModel);
        }

        public void Delete(int id)
        {
            _customerRepository.Delete(id);
        }

        public void Update(CustomerDataModel customerDataModel)
        {
            _customerRepository.Update(customerDataModel);
        }

        public CustomerDataModel FindById(int id)
        {
            return _customerRepository.FindById(id);
        }
    }
}
