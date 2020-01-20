using data_access_layer.Models;
using System.Collections.Generic;

namespace data_access_layer
{
    public interface IAgentRepository
    {
        IEnumerable<AgentDataModel> Get();

        void Add(AgentDataModel agentDataModel);

        void Delete(int id);

        void Update(AgentDataModel agentDataModel);

        AgentDataModel FindById(int id);
    }
}
