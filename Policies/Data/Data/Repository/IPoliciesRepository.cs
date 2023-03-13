using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Data.Repository
{
    public interface IPoliciesRepository
    {
        Task<Policy> AddPolicyAsync(Policy claim);
        Task UpdatePolicyAsync(Policy claim);
        Task<IEnumerable<Policy>> GetPolicysAsync();
        Task<Policy> GetPolicyByIdAsync(int id);
    }
}
