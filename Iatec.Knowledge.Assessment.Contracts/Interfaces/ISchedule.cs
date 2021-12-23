using Iatec.Knowledge.Assessment.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iatec.Knowledge.Assessment.Contracts.Interfaces
{
    public interface ISchedule
    {
        Task Insert(Schedule entity);
        Task Delete(int id);
        Schedule GetById(int id);
        IEnumerable<Schedule> Get();
        Task Update(Schedule entity);
    }
}
