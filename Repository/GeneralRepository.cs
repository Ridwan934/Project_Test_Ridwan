using Test_Case_API.Models;
using Test_Case_API.Contract;
using Test_Case_API.Contract.cs;
using Test_Case_API.Data;
using Microsoft.EntityFrameworkCore;

namespace Test_Case_API.Repository;
public class GeneralRepository<TEntity> : IGeneralRepository<TEntity>
    where TEntity : class
{
    protected readonly TestDbContext _dbContext;

    public GeneralRepository(TestDbContext testDbContext)
    {
        _dbContext = testDbContext;
    }

    public IEnumerable<TEntity> GetAll()
    {
        return _dbContext.Set<TEntity>().ToList();
    }

    public TEntity? GetByGuid(Guid guid)
    {
        var entity = _dbContext.Set<TEntity>().Find(guid);
        _dbContext.ChangeTracker.Clear();
        return entity;
    }

    public TEntity? Create(TEntity entity)
    {
        try
        {
            _dbContext.Set<TEntity>().Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }
        catch
        {
            return null;
        }
    }

    public bool Update(TEntity entity)
    {
        try
        {
            _dbContext.Set<TEntity>().Update(entity);
            _dbContext.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
    public bool Delete(TEntity entity)
    {
        try
        {
            _dbContext.Set<TEntity>().Remove(entity);
            _dbContext.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
}

