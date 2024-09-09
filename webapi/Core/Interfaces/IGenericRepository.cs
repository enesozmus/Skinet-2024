
using Core.Entities;

namespace Core.Interfaces;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<IReadOnlyList<T>> ListAllAsync();
    Task<T?> GetByIdAsync(int id);
    void Create(T entity);
    void Update(T entity);
    void Remove(T entity);
    Task<bool> IsSaveAllAsync();
    bool Exists(int id);
}