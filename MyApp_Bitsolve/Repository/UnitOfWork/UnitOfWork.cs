using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using System.Data.Entity.Validation;

namespace Repository
{
    public sealed class UnitOfWork : IUnitOfWork,IDisposable
    {
        private readonly MyApp_BitSolveEntities  _DbContext;

        public MyApp_BitSolveEntities dbContext
        {
            get { return _DbContext; }
        }

        public UnitOfWork(MyApp_BitSolveEntities dbContext)
        {
            _DbContext = dbContext;
        }

        public void Complete()
        {
            try
            {
                dbContext.SaveChanges();
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
                throw;
            }
           
        }


        public void Dispose()
        {
            _DbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
