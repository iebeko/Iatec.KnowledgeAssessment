using Iatec.Knowledge.Assessment.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iatec.Knowledge.Assessment.Contracts.Interfaces
{
    public interface IUser
    {
        Task Insert(User entity);
        Task Delete(int id);
        User GetById(int id);
        IEnumerable<User> Get();
        Task Update(User entity);
    }
}
