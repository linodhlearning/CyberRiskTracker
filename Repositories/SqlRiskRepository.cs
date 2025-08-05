using CyberRiskTracker.Data;
using CyberRiskTracker.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CyberRiskTracker.Repositories
{
    public class SqlRiskRepository : IRiskRepository
    {
        private readonly CyberRiskDbContext _db;

        public SqlRiskRepository(CyberRiskDbContext db)
        {
            _db = db;
        }

        public async Task<List<RiskItemEntity>> GetAllAsync()
        {
            return await _db.Risks.AsNoTracking().ToListAsync();
        }

        public async Task<RiskItemEntity?> GetByIdAsync(int id)
        {
            return await _db.Risks.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task SaveAsync(RiskItemEntity risk)
        {
            _db.Risks.Update(risk);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var risk = await _db.Risks.FindAsync(id);
            if (risk != null)
            {
                _db.Risks.Remove(risk);
                await _db.SaveChangesAsync();
            }
        }
    }

}
