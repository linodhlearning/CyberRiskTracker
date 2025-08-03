
using CyberRiskTracker.Data;
using CyberRiskTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace CyberRiskTracker.Repositories
{
    public interface IAssetRepository
    {
        Task<List<Asset>> GetAllAsync();
        Task<Asset?> GetByIdAsync(int id);
        Task SaveAsync(Asset asset);
        Task DeleteAsync(int id);
    }

    public class SqlAssetRepository : IAssetRepository
    {
        private readonly CyberRiskDbContext _db;

        public SqlAssetRepository(CyberRiskDbContext db)
        {
            _db = db;
        }

        public async Task<List<Asset>> GetAllAsync()
        {
            return await _db.Assets.ToListAsync();
        }

        public async Task<Asset?> GetByIdAsync(int id)
        {
            return await _db.Assets.FindAsync(id);
        }

        public async Task SaveAsync(Asset asset)
        {
            if (asset.Id == 0)
            {
                _db.Assets.Add(asset);
            }
            else
            {
                var trackedAsset = await _db.Assets.FindAsync(asset.Id);
                if (trackedAsset != null)
                {
                    _db.Entry(trackedAsset).CurrentValues.SetValues(asset);
                }
                else
                {
                    _db.Assets.Attach(asset);
                    _db.Entry(asset).State = EntityState.Modified;
                }
            }

            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var asset = await _db.Assets.FindAsync(id);
            if (asset != null)
            {
                _db.Assets.Remove(asset);
                await _db.SaveChangesAsync();
            }
        }
    }
}
