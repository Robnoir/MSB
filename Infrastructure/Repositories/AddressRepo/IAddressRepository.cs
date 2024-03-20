using Domain.Models.Address;


namespace Infrastructure.Repositories.AddressRepo
{
    public interface IAddressRepository
    {
        Task<AddressModel> AddAddressAsync(AddressModel address);
        Task<IEnumerable<AddressModel>> GetAllAddressesAsync();
        Task<AddressModel> GetAddressByIdAsync(Guid addressId);
        Task<AddressModel> UpdateAddressAsync(AddressModel address);
        Task DeleteAddressAsync(Guid addressId);
    }
}

