using Infrastructure.Database;

namespace Infrastructure.Repositories.ShelfRepo
{
    public class ShelfRepository : IShelfRepository
    {
        private readonly MSB_Database _msbDatabase;
        public ShelfRepository(MSB_Database msbDatabase)
        {
            _msbDatabase = msbDatabase;
        }
    }
}
