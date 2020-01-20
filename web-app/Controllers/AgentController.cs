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
    public class AgentController : ControllerBase
    {
        private readonly IAgentManager _agentManager;
        private readonly ILogger<AgentController> _logger;

        public AgentController(ILogger<AgentController> logger, IAgentManager agentManager)
        {
            _logger = logger;
            _agentManager = agentManager;
        }

        [HttpGet]
        public IEnumerable<AgentDomainModel> Get()
        {
            return _agentManager.Get();
        }

        [HttpPost]
        public void Add(AgentDomainModel agentDomainModel)
        {
            _agentManager.Add(agentDomainModel);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _agentManager.Delete(id);
        }

        [HttpPut]
        public void Update(AgentDomainModel agentDomainModel)
        {
            _agentManager.Update(agentDomainModel);
        }

        [HttpPatch("{id}")]
        public void Patch(int id, [FromBody] JsonPatchDocument<AgentDomainModel> agentDomainModel)
        {
            _agentManager.Patch(id, agentDomainModel);
        }

        [HttpGet("{id}")]
        public AgentDomainModel FindById(int id)
        {
            return _agentManager.FindById(id);
        }
    }
}
