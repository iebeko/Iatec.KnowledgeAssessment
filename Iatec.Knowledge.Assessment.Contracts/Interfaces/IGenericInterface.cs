using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iatec.Knowledge.Assessment.Contracts.Interfaces
{
    public interface IGenericInterface<T>
    {
        Task Insert(T entity);
        Task Delete(int id);
        T GetById(int id);
        IEnumerable<T> Get();
        Task Update(T entity);
    }
}
}
