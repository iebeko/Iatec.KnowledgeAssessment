using Iatec.Knowledge.Assessment.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iatec.Knowledge.Assessment.Exceptions
{
    public class ScheduleException:Exception
    {
        public void ScheduleValidationException(Schedule entity) 
        {
            if (entity.IdUser == 0)
                throw new Exception("UserId must be assigned");
            if (entity.NameSchedule == String.Empty)
                throw new Exception("Name should be typed");
        }
        public void ScheduleNameValidationException(IEnumerable<Schedule> scheduleList,Schedule entity) 
        {
            var result = scheduleList.FirstOrDefault(c => c.NameSchedule == entity.NameSchedule);
            if (result == null)
                throw new Exception("This name has been chosen, choose a different one");
        }
    }
}
