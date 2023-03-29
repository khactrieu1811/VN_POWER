using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.IRepository
{
    public interface IRepository<T> where T : class
    {
        IList<T> GetAll();
        IQueryable<T> GetAllData();
        IList<T> GetByFiler(Expression<Func<T, bool>> predicate);
        T GetById(int id);
        T GetByStringId(string id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        int Count(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetIncludes(params Expression<Func<T, Object>>[] includes);
        void UpdateEntities(IEnumerable<T> list);
        void InsertEntities(IEnumerable<T> list);
        void DeleteEntities(IEnumerable<T> list);
        void AttachEntities(IEnumerable<T> list);
        T InsertEntity(T entity);
        T UpdateEntity(T entity);
        IQueryable<T> GetDatabyFiler(Expression<Func<T, bool>> predicate);
        void InsertEntitiesWithoutSaveChange(IEnumerable<T> list);
        void UpdateEntitiesWithoutSaveChange(IEnumerable<T> list);
        void DeleteEntitiesWithoutSaveChange(IEnumerable<T> list);
      
        void SaveChanges();
    }
}
