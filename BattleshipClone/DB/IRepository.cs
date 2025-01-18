namespace BattleshipClone.DB
{
    public interface IRepository<T>
    {
        public Task<List<T>> GetAll();

        public Task<T?> GetById(int id);
        public Task<int> Create(T new_state);
        public Task<int> Update(T updated_state);
        public Task<int> Delete(T state);
       
    }
}
