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
    public class ScheduleEventBusiness : IScheduleEvent
    {
        private UnitOfWorks unitOfWork;
        private ScheduleEventException scheduleEventException;
        
        public ScheduleEventBusiness()
        {
            unitOfWork = new UnitOfWorks();
            scheduleEventException = new ScheduleEventException();
        }

        public async Task Delete(int id)
        {
            unitOfWork.ScheduleEventRepository.Delete(id);
            await unitOfWork.SaveAsync();
        }

        public IEnumerable<ScheduleEvent> Get()
        {
            return unitOfWork.ScheduleEventRepository.Get();
        }

        public ScheduleEvent GetById(int id)
        {
            return unitOfWork.ScheduleEventRepository.GetById(id);
        }

        public async Task Insert(ScheduleEvent entity)
        {
            var Event = unitOfWork.EventRepository.GetById(entity.IdEvent);
            entity.Name = Event.Name;
            entity.Date = Event.Date;
            entity.Participants = Event.Participants;
            entity.Place = Event.Place;
            entity.TypeEvent = Event.TypeEvent;
            entity.UserOwner = Event.UserOwner;
            entity.Description = Event.Description;
            entity.Year = Event.Date.Year;
            entity.Month = Event.Date.Month;
            entity.Days = Event.Date.Day;
            entity.MonthName = entity.Date.ToString("MMMM").ToUpper();
            var scheduleList = unitOfWork.ScheduleRepository.Get();
            scheduleEventException.ScheduleEventValidationException(entity);
            unitOfWork.ScheduleEventRepository.Insert(entity);
            await unitOfWork.SaveAsync();
        }

        public async Task Update(ScheduleEvent entity)
        {
            var scheduleEvent = unitOfWork.ScheduleEventRepository.GetById(entity.IdSchedule);
            
            scheduleEventException.ScheduleEventValidationException(entity);

            scheduleEvent.Month = entity.Month;
            scheduleEvent.Year = entity.Year;
            scheduleEvent.MonthName = entity.MonthName;
            scheduleEvent.Name = entity.Name;
            scheduleEvent.Date = entity.Date;
           
            unitOfWork.ScheduleEventRepository.Update(entity);
            await unitOfWork.SaveAsync();
        }
    }
}
