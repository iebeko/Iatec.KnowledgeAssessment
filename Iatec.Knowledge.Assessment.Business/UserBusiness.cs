using Iatec.Knowledge.Assessment.Contracts;
using Iatec.Knowledge.Assessment.Contracts.Interfaces;
using Iatec.Knowledge.Assessment.Entity;
using Iatec.Knowledge.Assessment.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iatec.Knowledge.Assessment.Business
{
    public class UserBusiness:IUser
    {
        private UnitOfWorks unitOfWorks;
        private UserException userException;

        public UserBusiness()
        {
            unitOfWorks = new UnitOfWorks();
            userException = new UserException();
        }

        public async Task Delete(int id)
        {
            unitOfWorks.UserRepository.Delete(id);
           await unitOfWorks.SaveAsync();
        }

        public IEnumerable<User> Get()
        {
            return unitOfWorks.UserRepository.Get();
        }

      

        public async Task Insert(User entity)
        {
            userException.UserValidationException(entity);
            unitOfWorks.UserRepository.Insert(entity);
           await unitOfWorks.SaveAsync();
        }

        public async Task Update(User entity)
        {
            unitOfWorks.UserRepository.Update(entity);
            await unitOfWorks.SaveAsync();
        }

        public User GetById(int id)
        {
            return unitOfWorks.UserRepository.GetById(id);
        }

       
    }
}
