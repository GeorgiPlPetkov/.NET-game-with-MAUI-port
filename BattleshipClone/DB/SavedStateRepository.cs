using SQLite;

namespace BattleshipClone.DB
{
    public class SavedStateRepository : ISavedStateRepository
    {
        private string db_name = "..";
        private SQLiteAsyncConnection connection;
        public SavedStateRepository() {
            Init();
        }
        private void Init() {
            db_name = Path.Combine(SQLiteConstants.DatabasePath);
            connection = new(db_name);
            connection.CreateTableAsync<SavedGameState>();
        }
        public Task<List<SavedGameState>> GetAll() {
            Init();
            return connection.Table<SavedGameState>().ToListAsync();
        }

        public Task<SavedGameState?> GetById(int id) {
            Init();
            return connection.Table<SavedGameState?>().Where(sgs => sgs.StateId == id)
                                                     .FirstOrDefaultAsync();
        }

        public async Task<int> Create(SavedGameState new_state) { 
            Init();
            return await connection.InsertAsync(new_state);
        }

        public async Task<int> Update(SavedGameState updated_state)
        {
            Init();
            return await connection.UpdateAsync(updated_state);
        }

        public async Task<int> Delete(SavedGameState state)
        {
            Init();
            return await connection.DeleteAsync(state);
        }
    }
}
