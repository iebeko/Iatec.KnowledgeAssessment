using Iatec.Knowledge.Assessment.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iatec.Knowledge.Assessment.Contracts.Interfaces
{
    public interface IScheduleEvent
    {
        Task Insert(ScheduleEvent entity);
        Task Delete(int id);
        ScheduleEvent GetById(int id);
        IEnumerable<ScheduleEvent> Get();
        Task Update(ScheduleEvent entity);
    }
}
