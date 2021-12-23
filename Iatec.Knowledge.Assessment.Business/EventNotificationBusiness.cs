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
    public class EventNotificationBusiness:IEventNotification
    {
        private UnitOfWorks unitOfWork;
        private EventNotificationException eventNotificationException;

        public EventNotificationBusiness()
        {
            unitOfWork = new UnitOfWorks();
            eventNotificationException = new EventNotificationException();
        }

        public async Task Delete(int id)
        {
            unitOfWork.EventNotificationRepository.Delete(id);
           await unitOfWork.SaveAsync();
        }

        public IEnumerable<EventNotification> Get()
        {
            return unitOfWork.EventNotificationRepository.Get();
        }

        public EventNotification GetById(int id)
        {
            return unitOfWork.EventNotificationRepository.GetById(id);
        }

        public async Task Insert(EventNotification entity)
        {
            eventNotificationException.EventNotificationValidation(entity);
            unitOfWork.EventNotificationRepository.Insert(entity);
            await unitOfWork.SaveAsync();
        }

        public async Task Update(EventNotification entity)
        {
            eventNotificationException.EventNotificationValidation(entity);
            var eventNotification = unitOfWork.EventNotificationRepository.GetById(entity.IdEvent);
            eventNotification.IdUser = entity.IdUser;
            eventNotification.IsAcepted = entity.IsAcepted;
            unitOfWork.EventNotificationRepository.Update(eventNotification);
           await unitOfWork.SaveAsync();
        }
    }
}
