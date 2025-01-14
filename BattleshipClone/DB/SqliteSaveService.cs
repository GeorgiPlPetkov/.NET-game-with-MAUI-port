using SQLite;

namespace BattleshipClone.DB
{
    internal class SqliteSaveService
    {
        private const string DB_NAME = "save_data";
        private readonly SQLiteAsyncConnection connection;

        public SqliteSaveService() { 
            connection = new(DB_NAME);
            connection.CreateTableAsync<SavedGameState>();
        }

        public async Task<List<SavedGameState>> GetAllStates() { 
            return await connection.Table<SavedGameState>().ToListAsync();
        }

        public async Task<SavedGameState> GetByName(string name) {
            return await connection.Table<SavedGameState>().Where((sgs) => sgs.Name == name)
                                                    .FirstOrDefaultAsync();
        }

        public async Task Create(SavedGameState new_state) { 
            await connection.InsertAsync(new_state);
        }

        public async Task Update(SavedGameState new_state)
        {
            await connection.UpdateAsync(new_state);
        }

        public async Task Delete(SavedGameState state)
        {
            await connection.DeleteAsync(state);
        }
    }
}
