using data_access_layer.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;

namespace business_layer
{
    public interface ICustomerManager
    {
        IEnumerable<CustomerDomainModel> Get();

        IEnumerable<CustomerNameAddressDomainModel> GetByAgentId(int agentId);

        void Add(CustomerDomainModel customerDomainModel);

        void Delete(int id);

        void Update(CustomerDomainModel customerDomainModel);

        void Patch(int id, JsonPatchDocument<CustomerDomainModel> customerDomainModel);

        CustomerDomainModel FindById(int id);
    }
}
