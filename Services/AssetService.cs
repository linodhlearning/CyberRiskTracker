
using AutoMapper;
using CyberRiskTracker.Data.Entities; 
using CyberRiskTracker.Models;
using CyberRiskTracker.Repositories;

namespace CyberRiskTracker.Services
{
    public class AssetService
    {
        private readonly IAssetRepository _repository;
        private readonly IMapper _mapper;

        public AssetService(IAssetRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<Asset>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<List<Asset>>(entities);
        }

        public async Task SaveAsync(Asset asset)
        {
            var entity = _mapper.Map<AssetEntity>(asset);
            await _repository.SaveAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
