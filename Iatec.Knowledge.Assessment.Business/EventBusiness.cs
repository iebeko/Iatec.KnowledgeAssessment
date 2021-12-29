using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iatec.Knowledge.Assessment.Contracts;
using Iatec.Knowledge.Assessment.Contracts.Interfaces;
using Iatec.Knowledge.Assessment.Entity;
using Iatec.Knowledge.Assessment.Entity.Filters;
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

        public IEnumerable<Event> Get(EventFilters filter)
        {
            var EventList =  _unitOfWork.EventRepository.Get();
            if (filter.Name != null)
                EventList = EventList.Where(c => c.Name.Contains(filter.Name));
            if (filter.UserOwner != null)
                EventList = EventList.Where(c => c.UserOwner == filter.UserOwner);
            if (filter.Date.HasValue == true)
                EventList = EventList.Where(c => c.Year == filter.Year);
            if (filter.Place != null)
                EventList = EventList.Where(c => c.Place.Contains(filter.Place));
            if (filter.Year > 0)
                EventList = EventList.Where(c => c.Year == filter.Year);
            if (filter.Month > 0)
                EventList = EventList.Where(c => c.Month == filter.Month);
            if (filter.Day > 0)
                EventList = EventList.Where(c =>c.Days == filter.Day);
            if (filter.IsSharable == false)
                EventList = EventList.Where(c => c.TypeEvent == TypeEvents.Exclusive);
            return EventList.ToList();
        }
       
        public Event GetById(int id)
        {
            return _unitOfWork.EventRepository.GetById(id);
        }

        public async Task Insert(Event entity)
        {
            entity.Year = entity.Date.Year;
            entity.Month = entity.Date.Month;
            entity.Days = entity.Date.Day;
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
            var result = _unitOfWork.EventRepository.GetById(entity.IdEvent);
            entity.Year = result.Date.Year;
            entity.Month = result.Date.Month;
            entity.Days = result.Date.Day;
            if (entity.TypeEvent == TypeEvents.Exclusive)
            {
                var EventExclusiveList = _unitOfWork.EventRepository.Get().Where(c => c.TypeEvent == TypeEvents.Exclusive);
                _eventException.ValidationInsertOverlap(EventExclusiveList, entity);
            }
            _eventException.ValidationException(entity);
           
            result.Name = entity.Name;
            result.Place = entity.Place;
            result.TypeEvent = entity.TypeEvent;
            result.UserOwner = entity.UserOwner;
            result.IsShareable = entity.IsShareable;
            result.IsDeleted = entity.IsDeleted;
            result.Date = entity.Date;
            _unitOfWork.EventRepository.Update(result);
            await _unitOfWork.SaveAsync();
        }
    }
}
