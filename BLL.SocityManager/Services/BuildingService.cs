using BLL.SocityManager.Entities;
using BLL.SocityManager.Handlers;
using Common.SocityManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.SocityManager.Services
{
    public class BuildingService : IBuildingRepository<Building>
    {
        private readonly IBuildingRepository<DAL.SocityManager.Entities.Building> _repo;
        private readonly ILocalRepository<DAL.SocityManager.Entities.Local> _localRepo;

        public BuildingService(IBuildingRepository<DAL.SocityManager.Entities.Building> repo, ILocalRepository<DAL.SocityManager.Entities.Local> localRepo)
        {
            this._repo = repo;
            _localRepo = localRepo;
        }

        public void Delete(Guid id)
        {
            _repo.Delete(id);
        }

        public Building Get(Guid id)
        {
            Building result = _repo.Get(id).ToBLL();
            IEnumerable<Local> locals = _localRepo.GetByBuilding(id).Select(l => l.ToBLL());
            foreach (Local local in locals) result.Locals.Add(local);
            return result;
        }

        public IEnumerable<Building> Get()
        {
            return _repo.Get().Select(b => b.ToBLL());
        }

        public Building GetByLocal(Guid localId)
        {
            return _repo.GetByLocal(localId).ToBLL();
        }

        public Guid Insert(Building entity)
        {
            return _repo.Insert(entity.ToDAL());
        }

        public void Update(Guid id, Building entity)
        {
            _repo.Update(id, entity.ToDAL());
        }
    }
}
