using System;
using System.Collections.Generic;
using System.Text;

namespace Common.SocityManager.Repositories
{
    public interface IBuildingRepository<TBuilding> : IRepository<TBuilding,Guid>
    {
        TBuilding GetByLocal(Guid localId);
    }
}
