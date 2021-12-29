using Iatec.Knowledge.Assessment.Entity;
using Iatec.Knowledge.Assessment.Entity.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Iatec.Knowledge.Assessment.Contracts.Interfaces
{
    public interface IEvent:IGenericInterface<Event>
    {
       
        IEnumerable<Event> Get(EventFilters filter);
        
    }
}
