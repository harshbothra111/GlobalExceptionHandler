using Domain;
using Manager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoliciesController : ControllerBase
    {
        private readonly IPoliciesManager _policiesManager;

        public PoliciesController(IPoliciesManager policiesManager)
        {
            _policiesManager = policiesManager;
        }
        // GET: api/<PoliciesController>
        [HttpGet]
        public async Task<IEnumerable<Policy>> Get()
        {
            return await _policiesManager.GetPoliciesAsync();
        }

        // GET api/<PoliciesController>/5
        [HttpGet("{id}")]
        public async Task<Policy> Get(int id)
        {
            return await _policiesManager.GetPolicyByIdAsync(id);
        }

        // POST api/<PoliciesController>
        [HttpPost]
        public async Task<Policy> Post(Policy claim)
        {
            return await _policiesManager.AddPolicyAsync(claim);
        }

        // PUT api/<PoliciesController>/5
        [HttpPut]
        public async Task Put(Policy claim)
        {
            await _policiesManager.UpdatePolicyAsync(claim);
        }
    }
}
