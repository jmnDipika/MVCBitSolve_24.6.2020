using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace Repository
{
     public  interface IBaseRepository<TEntity> where TEntity :class
    {
         IEnumerable<TEntity> GetAll();
         IEnumerable<TEntity> GetAll(string sp_Name, params object[] param);
         TEntity GetById(long id);
         TEntity GetById(Expression<Func<TEntity, bool>> whereClause);
         void Add(TEntity T);
         void Update(TEntity T);
         void Delete(int id);
         IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> whereClause);
         //IQueryable<TEntity> GetAll(PagingVM1 param, Expression<Func<TEntity, int>> order, Expression<Func<TEntity, bool>> whereClause);

    }
}
