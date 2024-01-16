
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UsersApi.Data.Repositories.Interfaces;

namespace UsersApi.Data.Repositories;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly AppDbContext _context;

    protected BaseRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<T> GetAsync(object id, CancellationToken cancellationToken)
    {
        return await _context.Set<T>().FindAsync(new[] { id }, cancellationToken: cancellationToken);

    }


    public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Set<T>().ToListAsync(cancellationToken);
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken)
    {
        await _context.Set<T>().AddAsync(entity, cancellationToken);
    }

    public async Task AddRangeAsync(List<T> entities, CancellationToken cancellationToken)
    {
        await _context.Set<T>().AddRangeAsync(entities, cancellationToken);
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }

    public void UpdateRange(List<T> entities)
    {
        _context.Set<T>().UpdateRange(entities);
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public void DeleteRange(List<T> entities)
    {
        _context.Set<T>().RemoveRange(entities);

    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}