using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq.Expressions;

namespace MedicalProject.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {

        // Marks an entity as new
        void Add(T entity);
        // Marks an entity as modified
        void Update(T entity);
        // Marks an entity to be removed
        void Delete(T entity);
        T Get(Expression<Func<T, bool>> filter, string include);
        T Get(Expression<Func<T, bool>> filter);
        // Gets all entities of type T

        IQueryable<T> GetAll();

        IQueryable<T> GetAll(Expression<Func<T, bool>> filter);

        IQueryable<T> GetAll(Expression<Func<T, bool>> filter , string include);

        void Save();
    }
}
