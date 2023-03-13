using Data;
using Data.Repository;
using Domain;
using Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public class ClaimsManager : IClaimsManager
    {
        private readonly IClaimsRepository _repository;

        public ClaimsManager(IClaimsRepository repository)
        {
            _repository = repository;
        }
        public async Task<Claim> AddClaimAsync(Claim claim)
        {
            return await _repository.AddClaimAsync(claim);
        }

        public async Task<Claim> GetClaimByIdAsync(int id)
        {
            Claim claim = await _repository.GetClaimByIdAsync(id);
            if (claim == null) throw new ClaimNotFoundException("Claim Not Found with ID: " + id);
            return claim;
        }

        public async Task<IEnumerable<Claim>> GetClaimsAsync()
        {
            return await _repository.GetClaimsAsync();
        }

        public async Task UpdateClaimAsync(Claim claim)
        {
           await _repository.UpdateClaimAsync(claim);
        }
    }
}
