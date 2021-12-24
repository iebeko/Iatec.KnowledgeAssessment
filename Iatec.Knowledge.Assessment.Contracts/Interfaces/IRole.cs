using Iatec.Knowledge.Assessment.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iatec.Knowledge.Assessment.Contracts.Interfaces
{
    public interface IRole
    {
        IEnumerable<Role> Get();
        Task Insert(Role entity);
        Task Update(Role entity);
        Task Delete(int id);
        Role GetById(int id);
    }
}
