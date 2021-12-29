using System;
using System.ComponentModel.DataAnnotations;

namespace Iatec.Knowledge.Assessment.Entity
{
    public class ScheduleEvent
    {
        [Key]
        public int IdScheduleEvent { get; set; }
        public int IdEvent { get; set; } 
        public int IdSchedule { get; set; }
        public virtual Schedule Schedule { get; set; }
        public string MonthName { get; set; }


        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int Days { get; set; }
        public string Place { get; set; }
        public TypeEvents TypeEvent { get; set; }
        public string UserOwner { get; set; }
        public int Participants { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsShareable { get; set; }
    }
}
