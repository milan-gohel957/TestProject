using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TestProject.Entity.Data;
using TestProject.Repository.Interfaces;

namespace TestProject.Repository.Implementations;

public class GenericRepository<TEntity> :IGenericRepository<TEntity> where TEntity :class  
{
    private readonly ProjectContext _projectContext;
    private readonly DbSet<TEntity> _dbSet;

    public GenericRepository(ProjectContext projectContext)
    {
        _projectContext = projectContext;
        _dbSet = _projectContext.Set<TEntity>();
    }

    public IQueryable<TEntity> Table => _dbSet;
    public IQueryable<TEntity> NonDeletedQuery()
    {
        return _dbSet.Where(e => EF.Property<bool>(e, "IsDeleted") == false);
    }
    public async Task<TEntity?> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>>? expression = null, bool? getDeleted = false, Func<IQueryable<TEntity>, IQueryable<TEntity>>? includes = null)
    {
        if(expression == null) return await _dbSet.FirstOrDefaultAsync();
        includes?.Invoke(_dbSet);
        return getDeleted == true ? await _dbSet.FirstOrDefaultAsync(expression) : await NonDeletedQuery().FirstOrDefaultAsync(expression);
        
    }


    
}
