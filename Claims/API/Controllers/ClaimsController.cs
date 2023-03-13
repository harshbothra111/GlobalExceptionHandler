using Domain;
using Manager;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimsController : ControllerBase
    {
        private readonly IClaimsManager _claimsManager;

        public ClaimsController(IClaimsManager claimsManager)
        {
            _claimsManager = claimsManager;
        }
        // GET: api/<ClaimsController>
        [HttpGet]
        public async Task<IEnumerable<Claim>> Get()
        {
            return await _claimsManager.GetClaimsAsync();
        }

        // GET api/<ClaimsController>/5
        [HttpGet("{id}")]
        public async Task<Claim> Get(int id)
        {
            return await _claimsManager.GetClaimByIdAsync(id);
        }

        // POST api/<ClaimsController>
        [HttpPost]
        public async Task<Claim> Post(Claim claim)
        {
            return await _claimsManager.AddClaimAsync(claim);
        }

        // PUT api/<ClaimsController>/5
        [HttpPut]
        public async Task Put(Claim claim)
        {
            await _claimsManager.UpdateClaimAsync(claim);
        }
    }
}
