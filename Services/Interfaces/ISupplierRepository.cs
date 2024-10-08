using Grocery.Models;

namespace Grocery.Services.Interfaces
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<Supplier>> GetSuppliersAsync();
        Task<Supplier> GetSupplierAsync(int id);
        void AddSupplier(Supplier supplier);
        void UpdateSupplier(Supplier supplier);
        void DeleteSupplier(Supplier supplier);
        Task<bool> SaveChangesAsync();


    }
}
