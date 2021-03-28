using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Repositories;

namespace WebApplication1.RepoImp
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbSet<TEntity> DbSet;
        private readonly Accounts_DBEntities DB;
        public Repository(Accounts_DBEntities db)
        {
            DB = db;
            DbSet = DB.Set<TEntity>();
        }
        public TEntity Add(TEntity entity)
        {
            var ent = DB.Set<TEntity>().Add(entity);
            DB.SaveChanges();
            return ent;
        }

        public void Edit(TEntity entity)
        {
            DB.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            DB.SaveChanges();
        }

        public IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public TEntity GetById(int id)
        {
            return DB.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity entity)
        {
            DB.Set<TEntity>().Remove(entity);
            DB.SaveChanges();
        }
    }
}
