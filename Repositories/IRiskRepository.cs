using CyberRiskTracker.Models;

namespace CyberRiskTracker.Repositories
{
    public interface IRiskRepository
    {
        Task<List<RiskItem>> GetAllAsync();
        Task<RiskItem?> GetByIdAsync(int id);
        Task SaveAsync(RiskItem risk);
        Task DeleteAsync(int id);
    }
}
