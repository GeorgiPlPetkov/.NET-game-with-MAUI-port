namespace BattleshipClone.DB
{
    public interface IRepository<T>
    {
        public Task<List<T>> GetAll();

        public Task<T> GetById(int id);
        public void Create(T new_state);
        public void Update(T updated_state);
        public void Delete(T state);
       
    }
}
