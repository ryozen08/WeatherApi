using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Infrastructure;



namespace Repository.Implementation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DatabaseContext Context;

        public Repository(DatabaseContext context)
        {
            Context = context;
        }

        public T Create(T t)
        {
            Context.Set<T>().Add(t);
            return t;
        }
        public async Task SaveChangesAsync()
        {
            try
            {
                await Context.SaveChangesAsync();
            }
            catch (DbEntityValidationException dbEx)
            {
                var raise =
                (
                    from validationErrors in dbEx.EntityValidationErrors
                    from validationError in validationErrors.ValidationErrors
                    select $"{validationErrors.Entry.Entity}:{validationError.ErrorMessage}"
                ).Aggregate<string, Exception>(dbEx, (current, message) => new InvalidOperationException(message, current));

                throw raise;
            }
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate);
        }

    }
}
