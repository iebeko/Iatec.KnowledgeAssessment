using Iatec.Knowledge.Assessment.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iatec.Knowledge.Assessment.Exceptions
{
    public class EventException
    {
        public void ValidationException(Event entity) 
        {
            if (entity.Name == String.Empty) 
                throw new Exception("Name should be filled ");
            if (entity.Date.Year == 1) 
                throw new Exception("Time should be set");
            if (entity.Description == String.Empty)
                throw new Exception("Decription must be set");
            if (entity.Place == String.Empty)
                throw new Exception("Place must be set");
            if (entity.Date <= DateTime.Now)
                throw new Exception("The date can´t be an older date.");
            if (entity.Participants == 0)
                throw new Exception("Participants must be greater than 0");
        }

        public void ValidationInsertOverlap(IEnumerable<Event> list, Event entity) 
        {
            var result = list.Where(c => c.Year == entity.Year && c.Month == entity.Month && c.Days == entity.Days);
            if (result.Count() > 0)
                throw new Exception("Exclusive events occurs this date, please choose a different date");
        }
    }
}
