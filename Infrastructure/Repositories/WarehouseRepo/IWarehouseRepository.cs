using Domain.Models.Warehouse;

namespace Infrastructure.Repositories.WarehouseRepo
{
    public interface IWarehouseRepository
    {
        Task<WarehouseModel> AddWarehouseAsync(WarehouseModel warehouse);
        Task<WarehouseModel?> DeleteWarehouseAsync(Guid id);
        Task<IEnumerable<WarehouseModel>> GetAllWarehousesAsync();
        Task<WarehouseModel> GetWarehouseByIdAsync(Guid warehouseId);
        Task<WarehouseModel> UpdateWarehouseAsync(WarehouseModel warehouse);
    }
}
