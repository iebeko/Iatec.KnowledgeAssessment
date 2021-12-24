using Iatec.Knowledge.Assessment.Contracts;
using Iatec.Knowledge.Assessment.Contracts.Interfaces;
using Iatec.Knowledge.Assessment.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iatec.Knowledge.Assessment.Business
{
   public class RoleBusiness:IRole
    {
        private UnitOfWorks unitOfWorks;

        public RoleBusiness()
        {
            unitOfWorks = new UnitOfWorks();
        }

        public async Task Delete(int id)
        {
            unitOfWorks.RoleRepository.Delete(id);
            await unitOfWorks.SaveAsync();
        }

        public IEnumerable<Role> Get()
        {
            return unitOfWorks.RoleRepository.Get();
        }

        public Role GetById(int id)
        {
            return unitOfWorks.RoleRepository.GetById(id);
        }

        public Task Insert(Role entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(Role entity)
        {
            throw new NotImplementedException();
        }
        
    }
}
