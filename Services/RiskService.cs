using CyberRiskTracker.Models;
using CyberRiskTracker.Repositories;

namespace CyberRiskTracker.Services
{
    public class RiskService
    {
        private readonly IRiskRepository _repository;

        public RiskService(IRiskRepository repository)
        {
            _repository = repository;
        }

        public Task<List<RiskItem>> GetAllRisksAsync() => _repository.GetAllAsync();

        public Task<RiskItem?> GetRiskByIdAsync(int id) => _repository.GetByIdAsync(id);

        public Task SaveRiskAsync(RiskItem risk) => _repository.SaveAsync(risk);

        public Task DeleteRiskAsync(int id) => _repository.DeleteAsync(id);
    }

}
