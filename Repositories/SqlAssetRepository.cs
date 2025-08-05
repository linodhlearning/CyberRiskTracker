using CyberRiskTracker.Data;
using CyberRiskTracker.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CyberRiskTracker.Repositories
{
    public interface IAssetRepository
    {
        Task<List<AssetEntity>> GetAllAsync();
        Task<AssetEntity?> GetByIdAsync(int id);
        Task SaveAsync(AssetEntity asset);
        Task DeleteAsync(int id);
    }

    public class SqlAssetRepository : IAssetRepository
    {
        private readonly CyberRiskDbContext _db;

        public SqlAssetRepository(CyberRiskDbContext db)
        {
            _db = db;
        }

        public async Task<List<AssetEntity>> GetAllAsync()
        {
            return await _db.Assets.AsNoTracking().ToListAsync();
        }

        public async Task<AssetEntity?> GetByIdAsync(int id)
        {
            return await _db.Assets.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task SaveAsync(AssetEntity asset)
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
