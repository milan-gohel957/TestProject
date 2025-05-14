using System.Linq.Expressions;

namespace TestProject.Repository.Interfaces;

public interface IGenericRepository<TEntity> where TEntity : class
{
    public IQueryable<TEntity> Table { get; }
    Task<TEntity?> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>>? expression = null, bool? getDeleted = false, Func<IQueryable<TEntity>, IQueryable<TEntity>>? includes = null);



}
