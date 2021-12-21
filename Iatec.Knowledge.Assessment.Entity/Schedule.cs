using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iatec.Knowledge.Assessment.Entity
{
    public class Schedule
    {
        public int IdSchedule { get; set; }
        public int IdUser { get; set; }
        public virtual IEnumerable<ScheduleEvent> EventosList{ get; set; }
    }
}
