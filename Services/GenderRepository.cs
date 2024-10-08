using Grocery.Data;
using Grocery.Models;
using Grocery.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Grocery.Services
{
    public class GenderRepository : IGenderRepository
    {
        private readonly DataContext _context;
        public GenderRepository(DataContext context)
        {
            _context = context;
        }
        public void AddGender(Gender gender)
        {
            _context.Add(gender);
        }

        public void DeleteGender(Gender gender)
        {
            _context.Genders.Remove(gender);
        }

        public void EditGender(Gender gender)
        {
            _context.Genders.Update(gender);
        }

        public async Task<Gender> GetGenderAsync(int id)
        {
            return await _context.Genders.FindAsync(id);
        }

        public async Task<IEnumerable<Gender>> GetGenders()
        {
            return await _context.Genders.ToListAsync();
        }

        public async Task<bool> Save()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
