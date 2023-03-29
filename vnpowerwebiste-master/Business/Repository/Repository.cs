using Microsoft.EntityFrameworkCore;
using Business.IRepository;
using Entities.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Business.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly VNPowerContext context;
        public Repository(VNPowerContext context)
        {
            this.context = context;
        }

        private void Save() => context.SaveChanges();
        public void Add(T entity)
        {
            context.Add(entity);
            Save();

        }

        public int Count(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate).Count();
        }

        public void Delete(T entity)
        {
            context.Remove(entity);
            Save();

        }
        public IList<T> GetAll()
        {
            return context.Set<T>().AsQueryable().AsNoTracking().ToList();
        }
        public IQueryable<T> GetAllData()
        {
            return context.Set<T>().AsQueryable().AsNoTracking();
        }

        public IList<T> GetByFiler(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate).AsQueryable().AsNoTracking().ToList();
        }
        public IQueryable<T> GetDatabyFiler(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().AsNoTracking().Where(predicate).AsQueryable();
        }

        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public T GetByStringId(string id)
        {
            return context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            Save();
        }
        public void UpdateEntities(IEnumerable<T> list)
        {
            context.UpdateRange(list);
            Save();
        }
        public void InsertEntities(IEnumerable<T> list)
        {
            context.AddRange(list);
            Save();
        }
        public void DeleteEntities(IEnumerable<T> list)
        {
            context.RemoveRange(list);
            Save();

        }
        public void DeleteEntitiesWithoutSaveChange(IEnumerable<T> list)
        {
            context.RemoveRange(list);
        }
        public void UpdateEntitiesWithoutSaveChange(IEnumerable<T> list)
        {
            context.UpdateRange(list);
        }
        public void InsertEntitiesWithoutSaveChange(IEnumerable<T> list)
        {
            context.AddRange(list);
        }
        public void AttachEntities(IEnumerable<T> list)
        {
            context.AttachRange(list);
            Save();
        }
        public IQueryable<T> GetIncludes(params Expression<Func<T, Object>>[] includes)
        {
            try
            {
                IQueryable<T> query = context.Set<T>().Include(includes[0]);
                foreach (var include in includes.Skip(1))
                {
                    query = query.Include(include);
                }
                return query.AsQueryable().AsNoTracking();
            }
            catch { return null; }

        }

        public T InsertEntity(T entity)
        {
            var rs = context.Add(entity);
            Save();
            return rs.Entity;
        }

        public T UpdateEntity(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            Save();
            return entity;
        }

        public void SaveChanges()
        {
            Save();
        }

    }
}
