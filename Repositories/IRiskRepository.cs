using CyberRiskTracker.Data.Entities; 

namespace CyberRiskTracker.Repositories
{
    public interface IRiskRepository
    {
        Task<List<RiskItemEntity>> GetAllAsync();
        Task<RiskItemEntity?> GetByIdAsync(int id);
        Task SaveAsync(RiskItemEntity risk);
        Task DeleteAsync(int id);
    }
}
