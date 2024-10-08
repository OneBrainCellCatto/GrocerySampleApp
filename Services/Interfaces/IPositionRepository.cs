using Grocery.Models;

namespace Grocery.Services.Interfaces
{
    public interface IPositionRepository
    {
        Task<IEnumerable<Position>> GetPositions();
        Task<Position> GetPosition(int id);
        void AddPosition(Position position);
        void RemovePosition(Position position);
        void UpdatePosition(Position position);
        void DeletePosition(Position position);
        Task<bool> SaveChangesAsync();
    }
}
