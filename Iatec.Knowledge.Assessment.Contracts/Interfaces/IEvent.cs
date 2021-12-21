using Iatec.Knowledge.Assessment.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iatec.Knowledge.Assessment.Contracts.Interfaces
{
    public interface IEvent
    {
        Task Insert(Event entity);
        Task Delete(int id);
        Event GetById(int id);
        IEnumerable<Event> Get();
        Task Update(Event entity);
    }
}
