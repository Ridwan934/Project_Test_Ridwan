namespace Test_Case_API.Contract.cs
{
        public interface IGeneralRepository<TEntity>
        {
            IEnumerable<TEntity> GetAll();
            TEntity? GetByGuid(Guid guid);
            TEntity? Create(TEntity entity);
            bool Update(TEntity entity);
            bool Delete(TEntity entity);
            bool IsExits(Guid guid);
        }
}
