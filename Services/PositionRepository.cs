using Grocery.Data;
using Grocery.Models;
using Grocery.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Grocery.Services
{
    public class PositionRepository : IPositionRepository
    {
        private readonly DataContext _context;
        public PositionRepository(DataContext context)
        {
            _context = context;
        }

        public void AddPosition(Position position)
        {
            _context.Positions.Add(position);
        }

        public void DeletePosition(Position position)
        {
            _context.Positions.Remove(position);
        }

        public async Task<Position> GetPosition(int id)
        {
            return await _context.Positions.FindAsync(id);
        }

        public async Task<IEnumerable<Position>> GetPositions()
        {
            return await _context.Positions.AsNoTracking().OrderBy(x => x.PositionName).ToListAsync();
        }

        public void RemovePosition(Position position)
        {
            _context.Positions.Remove(position);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void UpdatePosition(Position position)
        {
            _context.Positions.Update(position);
        }
    }
}
