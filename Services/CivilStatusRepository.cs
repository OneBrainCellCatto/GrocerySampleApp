using Grocery.Data;
using Grocery.Models;
using Grocery.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Grocery.Services
{
    public class CivilStatusRepository : ICivilStatusRepository
    {
        private readonly DataContext _context;
        public CivilStatusRepository(DataContext dataContext)
        {
            _context = dataContext;
        }
        public async Task<IEnumerable<CivilStatus>> GetCivilStatuses()
        {
            return await _context.CivilStatuses.AsNoTracking().ToListAsync();
        }
        public async Task<CivilStatus> GetCivilStatus(int id)
        {
            return await _context.CivilStatuses.FindAsync(id);
        }
    }
}
