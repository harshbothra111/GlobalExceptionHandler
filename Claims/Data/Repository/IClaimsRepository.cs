using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Data.Repository
{
    public interface IClaimsRepository
    {
        Task<Claim> AddClaimAsync(Claim claim);
        Task UpdateClaimAsync(Claim claim);
        Task<IEnumerable<Claim>> GetClaimsAsync();
        Task<Claim> GetClaimByIdAsync(int id);
    }
}
