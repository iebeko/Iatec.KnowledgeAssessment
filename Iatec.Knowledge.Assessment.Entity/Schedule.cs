using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Iatec.Knowledge.Assessment.Entity
{
    public class Schedule
    {
        [Key]
        public int IdSchedule { get; set; }
        public int IdUser { get; set; }
        public virtual User User { get; set; }
        public string NameSchedule { get; set; }
        public virtual IEnumerable<ScheduleEvent> EventosList{ get; set; }
    }
}
