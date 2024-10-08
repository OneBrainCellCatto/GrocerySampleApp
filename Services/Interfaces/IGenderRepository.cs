using Grocery.Models;

namespace Grocery.Services.Interfaces
{
    public interface IGenderRepository
    {
        Task<IEnumerable<Gender>> GetGenders();
        Task<Gender> GetGenderAsync(int id);
        void AddGender(Gender gender);
        void DeleteGender(Gender gender);
        void EditGender(Gender gender);
        Task<bool> Save();
    }
}
