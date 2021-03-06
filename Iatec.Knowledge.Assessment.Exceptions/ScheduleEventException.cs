using Iatec.Knowledge.Assessment.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iatec.Knowledge.Assessment.Exceptions
{
    public class ScheduleEventException
    {
        public void ScheduleEventValidationException(ScheduleEvent entity) 
        {
            if (entity.Month == 0)
                throw new Exception("Month should be set");
            if (entity.MonthName == String.Empty)
                throw new Exception("Month should be set");
            if (entity.Name == String.Empty)
                throw new Exception("Month should be set");
            if (entity.Date.Year == 1)
                throw new Exception("Date should be set");
            if (entity.Year <= 1)
                throw new Exception("Year should be set");

        }
    }
}
