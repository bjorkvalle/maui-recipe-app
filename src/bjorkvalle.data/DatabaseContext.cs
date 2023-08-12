using SQLite;

namespace bjorkvalle.data
{
    public class DatabaseContext
    {
        private SQLiteAsyncConnection _connection;
        private string _dbName, _dbFilePath;

        public async Task CreateDatabase(string folderPath, string dbName)
        {
            var filePath = Path.Combine(folderPath, dbName);
            _dbName = dbName;
            _dbFilePath = filePath;
            _connection = new SQLiteAsyncConnection(_dbFilePath);
            await _connection.CreateTableAsync<Recipe>();
        }

        public async Task ConnectDatabase(string folderPath, string dbName)
        {
            var filePath = Path.Combine(folderPath, dbName);
            _dbName = dbName;
            _dbFilePath = filePath;
            _connection = new SQLiteAsyncConnection(filePath);
            await Task.CompletedTask;
        }

        public bool TryDbConnection(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                return false;

            _dbFilePath = filePath;
            var fileExists = File.Exists(filePath);

            if (fileExists)
                _connection = new SQLiteAsyncConnection(filePath);

            return fileExists && _connection != null;
        }

        internal async Task<SQLiteAsyncConnection> TryGetConnectionOrDefault(SQLiteAsyncConnection defaultValue = null)
        {
            if (_connection is null)
                return defaultValue;

            return await Task.FromResult(_connection);
        }
    }
}
