using data_access_layer.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;

namespace business_layer
{
    public interface IAgentManager
    {
        IEnumerable<AgentDomainModel> Get();

        void Add(AgentDomainModel agentDomainModel);

        void Delete(int id);

        void Update(AgentDomainModel agentDomainModel);

        void Patch(int id, JsonPatchDocument<AgentDomainModel> agentDomainModel);

        AgentDomainModel FindById(int id);
    }
}
