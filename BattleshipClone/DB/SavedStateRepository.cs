using SQLite;

namespace BattleshipClone.DB
{
    public class SavedStateRepository : ISavedStateRepository
    {
        private string db_name = Path.Combine("..", "battleship.db");
        private SQLiteAsyncConnection connection;

        private void Init() {
            db_name = Path.Combine(SQLiteConstants.DatabasePath);
            connection = new(db_name);
            connection.CreateTableAsync<SavedGameState>();
        }
        public Task<List<SavedGameState>> GetAll() {
            Init();
            return connection.Table<SavedGameState>().ToListAsync();
        }

        public Task<SavedGameState> GetById(int id) {
            Init();
            return connection.Table<SavedGameState>().Where((sgs) => sgs.StateId == id)
                                                     .FirstOrDefaultAsync();
        }

        public void Create(SavedGameState new_state) { 
            Init();
            connection.InsertAsync(new_state);
        }

        public void Update(SavedGameState updated_state)
        {
            Init();
            connection.UpdateAsync(updated_state);
        }

        public void Delete(SavedGameState state)
        {
            Init();
            connection.DeleteAsync(state);
        }
    }
}
