using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Repository;

namespace Service
{
    public abstract class BaseService<T> where T : Entity
    {
        protected readonly IRepository<T> Repository;

        protected BaseService(IRepository<T> repository)
        {
            Repository = repository;
        }

        protected virtual T Create(T entity)
        {
            return Repository.Create(entity);
        }
    }
}
