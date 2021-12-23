using Iatec.Knowledge.Assessment.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iatec.Knowledge.Assessment.Exceptions
{
    public class EventNotificationException
    {
        public void EventNotificationValidation(EventNotification entity) 
        {
            if (entity.IdEvent == 0)
                throw new Exception("Some problem has occur with the Event, try again");
            if (entity.IdUser == 0)
                throw new Exception("User must be assigned");
            if (entity.IdEvent == 0)
                throw new Exception("Event must be assigned");
        }
    }
}
