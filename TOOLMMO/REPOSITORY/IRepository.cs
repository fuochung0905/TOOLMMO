﻿using Microsoft.Data.SqlClient;
using System.Linq.Expressions;
namespace REPOSITORY
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate, string[] includes = null);
        T GetById(Guid id);
        T Find(Expression<Func<T, bool>> match);
        IQueryable<T> FindAll();
        IQueryable<T> FindAllAsync();
        Task<T> FindAsync(Expression<Func<T, bool>> match);
        void add(T entity);
        void addRange(IEnumerable<T> entity);
        void update(T entity);
        void delete(T entity);
        void delete(Guid id);
        void DeleteRange(IEnumerable<T> entity);
        bool Exists(Guid id);
        int SaveChange();
        int Count();
        IEnumerable<T> ExcuteStoredProcedure(string nameOfStored, object model);
        IEnumerable<T> ExcuteStoredProcedure(string nameofStored, SqlParameter[]? parameters);
        IQueryable<T> ExcuteStoredQuery(string query);
    }
}
