using Domain;

namespace Data.Repository
{
    public class ClaimsRepository : IClaimsRepository
    {
        private readonly DataContext _context;

        public ClaimsRepository(DataContext context)
        {
            _context = context;
        }
        public async Task AddClaimAsync(Claim claim)
        {
            await _context.Claims.AddAsync(claim);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Claim> GetClaimById(int id)
        {
            return _context.Claims.Where(x => x.Id == id);
        }

        public IQueryable<Claim> GetClaims()
        {
            return _context.Claims;
        }

        public async Task UpdateClaimAsync(Claim claim)
        {
            _context.Update(claim);
            await _context.SaveChangesAsync();
        }
    }
}
