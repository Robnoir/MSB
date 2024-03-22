using Domain.Models.BoxModel;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.BoxRepo
{
    public class BoxRepository : IBoxRepository
    {
        private readonly MSB_Database _database;
        public BoxRepository(MSB_Database mSB_database)
        {
            _database = mSB_database;
        }

        public async Task<BoxModel> AddBoxAsync(BoxModel box)
        {
            _database.Boxes.AddAsync(box);
            _database.SaveChanges();

            return await Task.FromResult(box);
        }



        async Task IBoxRepository.DeleteBoxAsync(Guid boxId)
        {
            var box = await _database.Boxes.FindAsync(boxId);
            if (box != null)
            {
                _database.Boxes.Remove(box);
                await _database.SaveChangesAsync();
            }
        }

        async Task<IEnumerable<BoxModel>> IBoxRepository.GetAllBoxesAsync()
        {
            return await _database.Boxes.ToListAsync();
        }

        async Task<BoxModel> IBoxRepository.GetBoxByIdAsync(Guid boxId)
        {
            return await _database.Boxes.FindAsync(boxId);
        }

        async Task<BoxModel> IBoxRepository.UpdateBoxAsync(BoxModel box)
        {
            _database.Boxes.Update(box);
            _database.SaveChangesAsync();

            return box;
        }
    }
}
