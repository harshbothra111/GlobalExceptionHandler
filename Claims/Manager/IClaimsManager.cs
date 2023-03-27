using Domain;

namespace Manager
{
    public interface IClaimsManager
    {
        Task AddClaimAsync(Claim claim);
        public Task UpdateClaimAsync(Claim claim);
        Task<IEnumerable<Claim>> GetClaimsAsync();
        Task<Claim> GetClaimByIdAsync(int id);
    }
}