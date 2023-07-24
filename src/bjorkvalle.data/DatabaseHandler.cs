using SQLite;

namespace bjorkvalle.data
{
    public class DatabaseHandler<T> where T : new()
    {
        private SQLiteAsyncConnection _connection;
        private string _dbName, _databasePath;

        public async Task CreateDatabase(string folderPath, string dbName)
        {
            _dbName = dbName;
            _databasePath = Path.Combine(folderPath, _dbName);
            _connection = new SQLiteAsyncConnection(_databasePath);
            await _connection.CreateTableAsync<Recipe>();
            await _connection.CloseAsync();
        }


        public bool ConnectionExists(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                return false;

            _databasePath = filePath;// Path.Combine(folderPath, _dbName);
            _connection = new SQLiteAsyncConnection(_databasePath);
            return _connection != null;
        }

        public string GetActiveDbName(string folderPath)
        {
            _databasePath = Path.Combine(folderPath, _dbName);
            _connection = new SQLiteAsyncConnection(_databasePath);
            return _connection != null ? _dbName : "none";
        }

        public string GetActiveDbFullPath(string folderPath)
        {
            _databasePath = Path.Combine(folderPath, _dbName);
            _connection = new SQLiteAsyncConnection(_databasePath);
            return _connection != null ? _databasePath : "none";
        }

        public void ChangeDbName(string name)
        {
            _dbName = name;
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            var entity = await _connection.FindAsync<T>(id);
            return entity;
        }

        public async Task<List<T>> GetAllAsync()
        {
            var entities = await _connection.Table<T>().ToListAsync();
            return entities;
        }
    }
}
