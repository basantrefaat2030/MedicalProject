
using MedicalProject.Application.Interfaces;
using MedicalProject.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

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
            return _dbset.FirstOrDefault(filter);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbset.ToList();
        }

        public IEnumerable<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            return _dbset.Where(filter).ToList();
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
