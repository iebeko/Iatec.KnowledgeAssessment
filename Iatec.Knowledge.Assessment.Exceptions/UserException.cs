using Iatec.Knowledge.Assessment.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iatec.Knowledge.Assessment.Exceptions
{
    public class UserException
    {
        public void UserValidationException(User entity) 
        {
            if (entity.Name == String.Empty)
                throw new Exception("Name must be set");
            if (entity.LastName == String.Empty)
                throw new Exception("Lastname must be set");
            if (entity.PhoneNumber == String.Empty)
                throw new Exception("Phone number is empty");
            
        }
    }
}
