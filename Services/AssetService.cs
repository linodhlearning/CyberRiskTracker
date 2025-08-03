namespace CyberRiskTracker.Services
{
    using CyberRiskTracker.Models;
    using CyberRiskTracker.Repositories;

    public class AssetService
    {
        private readonly IAssetRepository _repository;

        public AssetService(IAssetRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Asset>> GetAllAsync() => _repository.GetAllAsync();
        public Task SaveAsync(Asset asset) => _repository.SaveAsync(asset);
        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}