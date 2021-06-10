using Microsoft.EntityFrameworkCore;
using POS.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace POS.Data.Repositories
{
    public abstract class RepositoryBase<T> where T : class
    {
        #region Properties

        private readonly DbSet<T> dbSet;

        public DbContext DbContext { get; private set; }
        // public ganaderiaContext DbContext { get; private set; }

        #endregion

        //protected RepositoryBase(DbContext dbContext)
        //{
        //    DbContext = dbContext;
        //    dbSet = DbContext.Set<T>();
        //}

        protected RepositoryBase(POSContext dbContext)
        {
            DbContext = dbContext;
            dbSet = DbContext.Set<T>();
        }
        #region Implementation
        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                dbSet.Remove(obj);
        }

        public virtual T GetById(object id)
        {
            return dbSet.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).ToList();
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).FirstOrDefault<T>();
        }

        #endregion

    }
}
