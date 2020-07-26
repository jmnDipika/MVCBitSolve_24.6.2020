using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repository
{
    
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly DbSet<TEntity> _dbSet;
        public BaseRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _dbSet = _unitOfWork.dbContext.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this._dbSet.ToList();
        }

        public IEnumerable<TEntity> GetAll(string sp_Name, params object[] param)
        {
            return this._dbSet.SqlQuery(sp_Name, param);
            
        }

        public TEntity GetById(long id)
        {
            return this._dbSet.Find(id);
        }

        public TEntity GetById(System.Linq.Expressions.Expression<Func<TEntity, bool>> whereClause)
        {
            return this._dbSet.Where(whereClause).FirstOrDefault();

        }

        public void Add(TEntity T)
        {
            try
            {
                this._dbSet.Add(T);
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw e;
            }
        }

        public void Update(TEntity T)
        {
            this._dbSet.Attach(T);
            this._unitOfWork.dbContext.Entry(T).State = System.Data.EntityState.Modified;
        }

        public void Delete(int id)
        {
            TEntity T = this._dbSet.Find(id);
            this._dbSet.Remove(T);
        }

        public IEnumerable<TEntity> GetAll(System.Linq.Expressions.Expression<Func<TEntity, bool>> whereClause)
        {
            return this._dbSet.Where(whereClause).AsQueryable();
        }

        //public IQueryable<TEntity> GetAll(PagingVM1 param, System.Linq.Expressions.Expression<Func<TEntity, int>> order, System.Linq.Expressions.Expression<Func<TEntity, bool>> whereClause)
        //{
        //    return this._dbSet.Where(whereClause).OrderBy(order).Skip((param.page - 1) * param.PageSize).Take(param.PageSize).AsQueryable();
        //}
    }

}
