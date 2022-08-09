using System;
using System.Collections.Generic;
using System.Text;

namespace Common.SocityManager.Repositories
{
    public interface ILocalRepository<TLocal> : IRepository<TLocal,Guid> 
    {
        IEnumerable<TLocal> GetByBuilding(Guid buildingId);
    }
}
