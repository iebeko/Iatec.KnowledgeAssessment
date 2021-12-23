using Iatec.Knowledge.Assessment.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iatec.Knowledge.Assessment.Contracts.Interfaces
{
    public interface IEventNotification
    {
        Task Insert(EventNotification entity);
        Task Delete(int id);
        EventNotification GetById(int id);
        IEnumerable<EventNotification> Get();
        Task Update(EventNotification entity);
    }
}
