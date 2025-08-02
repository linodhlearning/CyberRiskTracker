using CyberRiskTracker.Data;
using CyberRiskTracker.Models;
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

        public async Task<List<RiskItem>> GetAllAsync()
        {
            return await _db.Risks.ToListAsync();
        }

        public async Task<RiskItem?> GetByIdAsync(int id)
        {
            return await _db.Risks.FindAsync(id);
        }

        public async Task SaveAsync(RiskItem risk)
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
