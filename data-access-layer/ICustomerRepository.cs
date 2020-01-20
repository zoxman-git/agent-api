using data_access_layer.Models;
using System.Collections.Generic;

namespace data_access_layer
{
    public interface ICustomerRepository
    {
        IEnumerable<CustomerDataModel> Get();

        IEnumerable<CustomerDataModel> GetByAgentId(int agentId);

        void Add(CustomerDataModel customerDataModel);

        void Delete(int id);

        void Update(CustomerDataModel agentDataModel);

        CustomerDataModel FindById(int id);
    }
}
