using Microsoft.VisualBasic;
using SQLite;

namespace bjorkvalle.data
{
    public class DatabaseHandler<T>
        where T : new()
    {
        private SQLiteAsyncConnection _connection;
        private string _dbName, _dbFilePath;

        public async Task CreateDatabase(string folderPath, string dbName)
        {
            var filePath = Path.Combine(folderPath, dbName);
            _dbName = dbName;
            _dbFilePath = filePath;
            await Init();
        }

        public bool IsDbExists(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                return false;

            _dbFilePath = filePath;
            _connection = new SQLiteAsyncConnection(filePath);
            return File.Exists(filePath);
        }

        //public void ConnectToDatabase(string filePath)
        //{
        //    if (string.IsNullOrEmpty(filePath))
        //        throw new Exception("Missing db filepath");

        //    //_dbFilePath = filePath;
        //    _connection = new SQLiteAsyncConnection(filePath);
        //}

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
            var updatedRows = await _connection.InsertAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            await Init();
            var removedRows = await _connection.DeleteAsync<T>(id);
        }

        private async Task Init()
        {
            if (_connection is not null)
                return;

            _connection = new SQLiteAsyncConnection(_dbFilePath);
            await _connection.CreateTableAsync<Recipe>();
        }

        //public string GetActiveDbName(string folderPath)
        //{
        //    _databasePath = Path.Combine(folderPath, _dbName);
        //    _connection = new SQLiteAsyncConnection(_databasePath);
        //    return _connection != null ? _dbName : "none";
        //}

        //public string GetActiveDbFullPath(string folderPath)
        //{
        //    _databasePath = Path.Combine(folderPath, _dbName);
        //    _connection = new SQLiteAsyncConnection(_databasePath);
        //    return _connection != null ? _databasePath : "none";
        //}

        //public void ChangeDbName(string name)
        //{
        //    _dbName = name;
        //}
    }
}
