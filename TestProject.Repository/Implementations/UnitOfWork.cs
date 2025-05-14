using TestProject.Entity.Data;
using TestProject.Entity.Models;
using TestProject.Repository.Interfaces;

namespace TestProject.Repository.Implementations;

public class UnitOfWork : IUnitOfWork
{
    public IGenericRepository<User> User { get; private set; }
    public IGenericRepository<Role> Role { get; private set; }
    private ProjectContext _context;

    public UnitOfWork(ProjectContext context)
    {
        _context = context;
        User = new GenericRepository<User>(_context);
        Role = new GenericRepository<Role>(_context);
    }

    public async Task<ResultObject> SaveAsync()
    {
        try
        {
            await _context.SaveChangesAsync();
            return new() { Status = true, Message = "context Saved!" };
        }
        catch (System.Exception)
        {
            return new() { Status = false, Message = "Failed to save context." };
        }
    }
}
