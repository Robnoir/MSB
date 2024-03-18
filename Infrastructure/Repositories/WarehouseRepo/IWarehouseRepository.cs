using Domain.Models.Warehouse;

namespace Infrastructure.Repositories.WarehouseRepo
{
    public interface IWarehouseRepository
    {
        Task<WarehouseModel> AddWarehouseAsync(WarehouseModel warehouse);
        Task<WarehouseModel> DeleteWarehouseAsync(int id);
        Task DeleteWarehouseAsync(Guid warehouseId);
        Task<IEnumerable<WarehouseModel>> GetAllWarehousesAsync();
        Task<WarehouseModel> GetWarehouseById(int id);
        Task<WarehouseModel> GetWarehouseByIdAsync(Guid warehouseId);
    }
}
