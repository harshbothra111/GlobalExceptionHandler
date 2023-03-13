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
    public class PoliciesManager : IPoliciesManager
    {
        private readonly IPoliciesRepository _repository;

        public PoliciesManager(IPoliciesRepository repository)
        {
            _repository = repository;
        }
        public async Task<Policy> AddPolicyAsync(Policy policy)
        {
            return await _repository.AddPolicyAsync(policy);
        }

        public async Task<Policy> GetPolicyByIdAsync(int id)
        {
            var policy = await _repository.GetPolicyByIdAsync(id);
            if(policy == null) throw new PolicyNotFoundException("Policy Not Found with ID: " + id);
            return policy;
        }

        public async Task<IEnumerable<Policy>> GetPoliciesAsync()
        {
            return await _repository.GetPolicysAsync();
        }

        public async Task UpdatePolicyAsync(Policy policy)
        {
           await _repository.UpdatePolicyAsync(policy);
        }
    }
}
