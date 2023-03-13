using Domain;

namespace Manager
{
    public interface IPoliciesManager
    {
        Task<Policy> AddPolicyAsync(Policy policy);
        public Task UpdatePolicyAsync(Policy policy);
        Task<IEnumerable<Policy>> GetPoliciesAsync();
        Task<Policy> GetPolicyByIdAsync(int id);
    }
}