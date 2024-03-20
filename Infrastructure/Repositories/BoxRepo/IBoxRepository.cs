using Domain.Models.BoxModel;

namespace Infrastructure.Repositories.BoxRepo
{
    public interface IBoxRepository
    {
        Task<BoxModel> AddBoxAsync(BoxModel box);
        Task<IEnumerable<BoxModel>> GetAllBoxesAsync();
        Task<BoxModel> GetBoxByIdAsync(Guid boxId);
        Task<BoxModel> UpdateBoxAsync(BoxModel box);
        Task DeleteBoxAsync(Guid boxId);
    }
}
