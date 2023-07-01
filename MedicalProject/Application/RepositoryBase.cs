
using MedicalProject.Application.Interfaces;
using MedicalProject.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MedicalProject.Application
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        public DbSet<T> _dbset;

        public RepositoryBase(ApplicationDbContext db)
        {
            this._db = db;
            this._dbset = db.Set<T>();
        }
        public void Add(T entity)
        {
            _dbset.Add(entity);
           
        }

        public void Delete(T entity)
        {
           
            _dbset.Remove(entity);
        }

        public T Get(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            return _dbset.AsNoTracking().FirstOrDefault(filter);
        }

        public T Get(Expression<Func<T, bool>> filter, string include)
        {
            return _dbset.AsNoTracking().Include(include).FirstOrDefault(filter);
        }

        public IQueryable<T> GetAll()
        {
            return _dbset;
        }

        public IQueryable<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            return _dbset.Where(filter);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter, string include)
        {
            return _dbset.Include(include).Where(filter);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbset.Update(entity);
        }


    }
}
