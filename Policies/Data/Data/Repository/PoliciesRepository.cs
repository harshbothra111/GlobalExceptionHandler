using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class PoliciesRepository : IPoliciesRepository
    {
        private readonly DataContext _context;

        public PoliciesRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Policy> AddPolicyAsync(Policy claim)
        {
            await _context.Policies.AddAsync(claim).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return claim;
        }

        public async Task<Policy> GetPolicyByIdAsync(int id)
        {
            return await _context.Policies.FindAsync(id).ConfigureAwait(true);
        }

        public async Task<IEnumerable<Policy>> GetPolicysAsync()
        {
            return await _context.Policies.ToListAsync().ConfigureAwait(true);
        }

        public async Task UpdatePolicyAsync(Policy claim)
        {
            _context.Entry(claim).State = EntityState.Modified;
            await _context.SaveChangesAsync().ConfigureAwait(true);
        }
    }
}
