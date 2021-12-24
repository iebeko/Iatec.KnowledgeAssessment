using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iatec.Knowledge.Assessment.Entity
{
   public class ScheduleEvent
    {
        [Key]
        public int IdScheduleEvent { get; set; }
        public int IdEvent { get; set; } 
        public int IdSchedule { get; set; }
        public virtual Schedule Schedule { get; set; }
        public string NameEvent { get; set; }
        public string Month { get; set; }
        public string MonthName { get; set; }
        public int Year { get; set; }
        public DateTime DateEvent { get; set; }

        
    }
}
