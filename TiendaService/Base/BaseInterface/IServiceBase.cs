using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace TiendaService.Base.BaseInterface
{
    public interface IServiceBase<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        bool Exist(Expression<Func<T, bool>> expression);
        T GetOne(int Id);
        int Create(T entity);
        T Update(T entity);
        void Delete(int Id);
    }
}
