using data_access_layer.Models;
using System.Collections.Generic;

namespace data_access_layer
{
    public class AgentRepository : IAgentRepository
    {
        private readonly IRepository<AgentDataModel> _agentRepository;

        public AgentRepository(IRepository<AgentDataModel> agentRepository)
        {
            _agentRepository = agentRepository;
        }

        public IEnumerable<AgentDataModel> Get()
        {
            return _agentRepository.Get();
        }

        public void Add(AgentDataModel agentDataModel)
        {
            _agentRepository.Add(agentDataModel);
        }

        public void Delete(int id)
        {
            _agentRepository.Delete(id);
        }

        public void Update(AgentDataModel agentDataModel)
        {
            _agentRepository.Update(agentDataModel);
        }

        public AgentDataModel FindById(int id)
        {
            return _agentRepository.FindById(id);
        }
    }
}
