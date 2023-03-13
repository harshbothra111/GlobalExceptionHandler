using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ClaimsRepository : IClaimsRepository
    {
        private readonly DataContext _context;

        public ClaimsRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Claim> AddClaimAsync(Claim claim)
        {
            await _context.Claims.AddAsync(claim);
            await _context.SaveChangesAsync();
            return claim;
        }

        public async Task<Claim> GetClaimByIdAsync(int id)
        {
            return await _context.Claims.FindAsync(id); 
        }

        public async Task<IEnumerable<Claim>> GetClaimsAsync()
        {
            return await _context.Claims.ToListAsync();
        }

        public async Task UpdateClaimAsync(Claim claim)
        {
            _context.Entry(claim).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
