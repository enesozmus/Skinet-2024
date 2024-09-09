using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class GenericRepository<T>(StoreContext context) : IGenericRepository<T> where T : BaseEntity
{
    public async Task<IReadOnlyList<T>> ListAllAsync() => await context.Set<T>().ToListAsync();

    public async Task<T?> GetByIdAsync(int id) => await context.Set<T>().FindAsync(id);

    public void Create(T entity) => context.Set<T>().Add(entity);

    public void Update(T entity)
    {
        context.Set<T>().Attach(entity);
        context.Entry(entity).State = EntityState.Modified;
    }

    public void Remove(T entity) => context.Set<T>().Remove(entity);

    public async Task<bool> IsSaveAllAsync() => await context.SaveChangesAsync() > 0;

    public bool Exists(int id) => context.Set<T>().Any(x => x.Id == id);
}