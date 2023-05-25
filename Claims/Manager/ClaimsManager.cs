using Data.Repository;
using Domain;
using Errors;
using Microsoft.EntityFrameworkCore;

namespace Manager
{
    public class ClaimsManager : IClaimsManager
    {
        private readonly IClaimsRepository _repository;

        public ClaimsManager(IClaimsRepository repository)
        {
            _repository = repository;
        }
        public async Task AddClaimAsync(Claim claim)
        {
            await _repository.AddClaimAsync(claim);
        }

        public async Task<Claim> GetClaimByIdAsync(int id)
        {
            Claim claim = await _repository.GetClaimById(id).FirstAsync();
            if (claim == null) throw new ClaimNotFoundException("Claim Not Found with ID: " + id);
            return claim;
        }

        public async Task<IEnumerable<Claim>> GetClaimsAsync()
        {
            return await _repository.GetClaims().ToListAsync();
        }

        public async Task UpdateClaimAsync(Claim claim)
        {
            await _repository.UpdateClaimAsync(claim);
        }
    }
}
