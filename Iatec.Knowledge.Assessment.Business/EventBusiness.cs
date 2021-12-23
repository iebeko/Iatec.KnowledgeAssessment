using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iatec.Knowledge.Assessment.Contracts;
using Iatec.Knowledge.Assessment.Contracts.Interfaces;
using Iatec.Knowledge.Assessment.Entity;
using Iatec.Knowledge.Assessment.Exceptions;

namespace Iatec.Knowledge.Assessment.Business
{
    public class EventBusiness:IEvent
    {
        private UnitOfWorks _unitOfWork;
        private EventException _eventException;

        public EventBusiness()
        {
            _unitOfWork = new UnitOfWorks();
            _eventException = new EventException();
        }

        public async Task Delete(int id)
        {
            var result = _unitOfWork.EventRepository.GetById(id);
            _unitOfWork.EventRepository.Delete(result);
            await _unitOfWork.SaveAsync();

        }

        public IEnumerable<Event> Get()
        {
            return _unitOfWork.EventRepository.Get();
        }

        public Event GetById(int id)
        {
            return _unitOfWork.EventRepository.GetById(id);
        }

        public async Task Insert(Event entity)
        {
            
            if (entity.TypeEvent == TypeEvents.Exclusive) 
            {
                var result = _unitOfWork.EventRepository.Get().Where(c => c.TypeEvent == TypeEvents.Exclusive);
                _eventException.ValidationInsertOverlap(result, entity);
            }
            _eventException.ValidationException(entity);
            _unitOfWork.EventRepository.Insert(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task Update(Event entity)
        {
            if (entity.TypeEvent == TypeEvents.Exclusive)
            {
                var EventExclusiveList = _unitOfWork.EventRepository.Get().Where(c => c.TypeEvent == TypeEvents.Exclusive);
                _eventException.ValidationInsertOverlap(EventExclusiveList, entity);
            }
            _eventException.ValidationException(entity);
            var result = _unitOfWork.EventRepository.GetById(entity.IdEvent);
            result.Name = entity.Name;
            result.Place = entity.Place;
            result.TypeEvent = entity.TypeEvent;
            result.UserOwner = entity.UserOwner;
            result.IsShareable = entity.IsShareable;
            result.IsDeleted = entity.IsDeleted;
            _unitOfWork.EventRepository.Update(result);
            await _unitOfWork.SaveAsync();
        }
    }
}
