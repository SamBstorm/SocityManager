using BLL.SocityManager.Entities;
using BLL.SocityManager.Handlers;
using Common.SocityManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.SocityManager.Services
{
    public class LocalService : ILocalRepository<Local>
    {
        private readonly ILocalRepository<DAL.SocityManager.Entities.Local> _repo;
        private readonly IBuildingRepository<DAL.SocityManager.Entities.Building> _buildingRepo;

        public LocalService(ILocalRepository<DAL.SocityManager.Entities.Local> repo, IBuildingRepository<DAL.SocityManager.Entities.Building> buildingRepo)
        {
            this._repo = repo;
            _buildingRepo = buildingRepo;
        }
        public void Delete(Guid id)
        {
            _repo.Delete(id);
        }

        public Local Get(Guid id)
        {
            Local result = _repo.Get(id).ToBLL();
            result.Building = _buildingRepo.GetByLocal(id).ToBLL();
            return result;
        }

        public IEnumerable<Local> Get()
        {
            return _repo.Get().Select(u => u.ToBLL());
        }

        public IEnumerable<Local> GetByBuilding(Guid buildingId)
        {
            return _repo.GetByBuilding(buildingId).Select(l => l.ToBLL());
        }

        public Guid Insert(Local entity)
        {
            return _repo.Insert(entity.ToDAL());
        }

        public void Update(Guid id, Local entity)
        {
            _repo.Update(id, entity.ToDAL());
        }
    }
}
