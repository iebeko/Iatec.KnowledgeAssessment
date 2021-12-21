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
        }
    }
}
