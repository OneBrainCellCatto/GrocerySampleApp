using Grocery.Models;

namespace Grocery.Services.Interfaces
{
    public interface ICivilStatusRepository
    {
        public Task<IEnumerable<CivilStatus>> GetCivilStatuses();
        public Task<CivilStatus> GetCivilStatus(int id);
    }
}
