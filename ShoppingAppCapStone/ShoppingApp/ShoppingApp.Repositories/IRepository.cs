using MongoDB.Bson;
using MongoDB.Driver;
using ShoppingApp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingApp.Repositories;

public interface IRepository<T> where T : class
{
  Task<List<T>> GetAllAsync();
  Task<T?> GetByIdAsync(string id);
  Task CreateAsync(T entity);
  Task UpdateAsync(string id, T entity);
  Task DeleteAsync(string id);
}