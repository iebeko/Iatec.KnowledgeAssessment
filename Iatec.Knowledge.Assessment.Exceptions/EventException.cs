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
        public void ValidationException(Event entidad) 
        {
            if (entidad.Name == String.Empty) 
                throw new Exception("Name should be filled ");
            if (entidad.Date.Year == 1) 
                throw new Exception("Time should be set");
            if (entidad.Description == String.Empty)
                throw new Exception("Decription must be set");
            if (entidad.Place == String.Empty)
                throw new Exception("Place must be set");
            
        }

        public void ValidationInsertOverlap(int month) 
        {

        }
    }
}
