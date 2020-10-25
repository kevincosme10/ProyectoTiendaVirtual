using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TiendaData.Interfaces.Base;
using TiendaEntities;
using TiendaEntities.Models;

namespace TiendaData.Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity, new()
    {
    
        protected TiendaDataContext RepositoryContext { get; set; }
        protected readonly DbSet<T> entities;
        public BaseRepository(TiendaDataContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
            entities = RepositoryContext.Set<T>();
        }
        public virtual int Create(T entity)
        {
         
            entity.CreateDate = DateTime.Now;
            entity.Estado = true;
            var result = entities.Add(entity);
            this.RepositoryContext.SaveChanges();
            return Convert.ToInt32(result.Property("Id").CurrentValue.ToString());
        }
        public async Task<int> CommitChanges() => await this.RepositoryContext.SaveChangesAsync();
        private int Save => this.RepositoryContext.SaveChanges();
        public virtual void Delete(int Id)
        {
            var entity = this.GetOne(Id);
            entity.Estado = false;
            this.Update(entity);
        }
        public virtual IQueryable<T> FindAll()
        {
            var result = this.entities.Where(c => c.Estado).OrderByDescending(c => c.Id).AsNoTracking();
            //PropertyInfo propertyInfo = result.GetType().GetGenericArguments()[0].GetProperty("CreatedBy");

            return result;
        }

        public virtual IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        }

        public virtual T GetOne(int Id)
        {
            return this.RepositoryContext.Set<T>().Find(Id);
        }
        public virtual T Update(T entity)
        {
            entity.Estado = false;
            entity.LastUpdate = DateTime.Now;
            this.RepositoryContext.Set<T>().Update(entity);
            this.RepositoryContext.SaveChanges();
            return entity;
        }

        public bool Exist(Expression<Func<T, bool>> expression) => (this.RepositoryContext.Set<T>().Any(expression));

    }
}
