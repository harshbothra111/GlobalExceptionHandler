using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            await _context.Policies.AddAsync(claim);
            await _context.SaveChangesAsync();
            return claim;
        }

        public async Task<Policy> GetPolicyByIdAsync(int id)
        {
            return await _context.Policies.FindAsync(id); 
        }

        public async Task<IEnumerable<Policy>> GetPolicysAsync()
        {
            return await _context.Policies.ToListAsync();
        }

        public async Task UpdatePolicyAsync(Policy claim)
        {
            _context.Entry(claim).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
