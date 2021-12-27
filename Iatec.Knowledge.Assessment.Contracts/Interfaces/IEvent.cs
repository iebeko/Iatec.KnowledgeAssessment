using Iatec.Knowledge.Assessment.Entity;
using Iatec.Knowledge.Assessment.Entity.Filters;
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
        IEnumerable<Event> Get(EventFilters filter);
        Task Update(Event entity);
    }
}
