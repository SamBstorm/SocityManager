using System;
using System.Collections.Generic;
using System.Text;

namespace Common.SocityManager.Repositories
{
    public interface IRepository<TEntity,TId>
    {
        TEntity Get(TId id);
        IEnumerable<TEntity> Get();
        TId Insert(TEntity entity);
        void Update(TId id, TEntity entity);
        void Delete(TId id);
    }
}
