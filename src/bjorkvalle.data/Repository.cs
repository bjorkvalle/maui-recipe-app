using SQLite;

namespace bjorkvalle.data
{
    public interface IRepository<T> where T : new()
    {
        Task CreateAsync(T entity);
        Task DeleteAsync(Guid id);
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task UpdateAsync(T entity);
    }

    public class Repository<T> : IRepository<T> where T : new()
    {
        private readonly DatabaseContext _context;
        private SQLiteAsyncConnection _connection;

        public Repository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            await Init();
            var entity = await _connection.FindAsync<T>(id);
            return entity;
        }

        public async Task<List<T>> GetAllAsync()
        {
            await Init();
            var entities = await _connection.Table<T>().ToListAsync();
            return entities;
        }

        public async Task CreateAsync(T entity)
        {
            await Init();
            await _connection.InsertAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            await Init();
            var updatedRows = await _connection.UpdateAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            await Init();
            var removedRows = await _connection.DeleteAsync<T>(id);
        }

        private async Task Init()
        {
            _connection = await _context.TryGetConnectionOrDefault();

            if (_connection == null)
                throw new Exception("Lost db connection");
        }
    }
}
