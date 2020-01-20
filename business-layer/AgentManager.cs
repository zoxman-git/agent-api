using data_access_layer;
using data_access_layer.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Linq;

namespace business_layer
{
    public class AgentManager : IAgentManager
    {
        private readonly IAgentRepository _agentRepository;

        public AgentManager(IAgentRepository agentRepository)
        {
            _agentRepository = agentRepository;
        }

        public IEnumerable<AgentDomainModel> Get()
        {
            var agentDomainModels = new List<AgentDomainModel>();
            var agentDataModels = _agentRepository.Get();

            agentDomainModels.AddRange(agentDataModels.Select(x =>
            new AgentDomainModel()
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                City = x.City,
                State = x.State,
                ZipCode = x.ZipCode,
                Tier = x.Tier,
                Phone = new AgentDomainModel.AgentPhone()
                {
                    Primary = x.Phone.Primary,
                    Mobile = x.Phone.Mobile
                }
            }));

            return agentDomainModels;
        }

        public void Add(AgentDomainModel agentDomainModel)
        {
            var agentDataModel = new AgentDataModel()
            {
                Id = agentDomainModel.Id,
                Name = agentDomainModel.Name,
                Address = agentDomainModel.Address,
                City = agentDomainModel.City,
                State = agentDomainModel.State,
                ZipCode = agentDomainModel.ZipCode,
                Tier = agentDomainModel.Tier,
                Phone = new AgentDataModel.AgentPhone()
                {
                    Primary = agentDomainModel.Phone.Primary,
                    Mobile = agentDomainModel.Phone.Mobile
                }
            };

            _agentRepository.Add(agentDataModel);
        }

        public void Delete(int id)
        {
            _agentRepository.Delete(id);
        }

        public void Update(AgentDomainModel agentDomainModel)
        {
            var agentDataModel = new AgentDataModel()
            {
                Id = agentDomainModel.Id,
                Name = agentDomainModel.Name,
                Address = agentDomainModel.Address,
                City = agentDomainModel.City,
                State = agentDomainModel.State,
                ZipCode = agentDomainModel.ZipCode,
                Tier = agentDomainModel.Tier,
                Phone = new AgentDataModel.AgentPhone()
                {
                    Primary = agentDomainModel.Phone.Primary,
                    Mobile = agentDomainModel.Phone.Mobile
                }
            };

            _agentRepository.Update(agentDataModel);
        }

        public void Patch(int id, JsonPatchDocument<AgentDomainModel> agentDomainModel)
        {
            var agentToPatchDataModel = _agentRepository.FindById(id);
            var agentToPatchDomainModel = new AgentDomainModel();

            agentToPatchDomainModel.Id = agentToPatchDataModel.Id;
            agentToPatchDomainModel.Name = agentToPatchDataModel.Name;
            agentToPatchDomainModel.Address = agentToPatchDataModel.Address;
            agentToPatchDomainModel.City = agentToPatchDataModel.City;
            agentToPatchDomainModel.State = agentToPatchDataModel.State;
            agentToPatchDomainModel.ZipCode = agentToPatchDataModel.ZipCode;
            agentToPatchDomainModel.Tier = agentToPatchDataModel.Tier;
            agentToPatchDomainModel.Phone = new AgentDomainModel.AgentPhone()
            {
                Primary = agentToPatchDataModel.Phone.Primary,
                Mobile = agentToPatchDataModel.Phone.Mobile
            };

            agentDomainModel.ApplyTo(agentToPatchDomainModel);

            var patchedAgentDataModel = new AgentDataModel()
            {
                Id = agentToPatchDomainModel.Id,
                Name = agentToPatchDomainModel.Name,
                Address = agentToPatchDomainModel.Address,
                City = agentToPatchDomainModel.City,
                State = agentToPatchDomainModel.State,
                ZipCode = agentToPatchDomainModel.ZipCode,
                Tier = agentToPatchDomainModel.Tier,
                Phone = new AgentDataModel.AgentPhone()
                {
                    Primary = agentToPatchDomainModel.Phone.Primary,
                    Mobile = agentToPatchDomainModel.Phone.Mobile
                }
            };

            _agentRepository.Update(patchedAgentDataModel);
        }

        public AgentDomainModel FindById(int id)
        {
            var agentDomainModel = new AgentDomainModel();
            var agentDataModel = _agentRepository.FindById(id);

            agentDomainModel.Id = agentDataModel.Id;
            agentDomainModel.Name = agentDataModel.Name;
            agentDomainModel.Address = agentDataModel.Address;
            agentDomainModel.City = agentDataModel.City;
            agentDomainModel.State = agentDataModel.State;
            agentDomainModel.ZipCode = agentDataModel.ZipCode;
            agentDomainModel.Tier = agentDataModel.Tier;
            agentDomainModel.Phone = new AgentDomainModel.AgentPhone()
            {
                Primary = agentDataModel.Phone.Primary,
                Mobile = agentDataModel.Phone.Mobile
            };

            return agentDomainModel;
        }
    }
}
