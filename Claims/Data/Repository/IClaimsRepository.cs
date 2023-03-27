using Domain;

namespace Data.Repository
{
    public interface IClaimsRepository
    {
        Task AddClaimAsync(Claim claim);
        Task UpdateClaimAsync(Claim claim);
        IQueryable<Claim> GetClaims();
        IQueryable<Claim> GetClaimById(int id);
    }
}
