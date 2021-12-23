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
    public class ScheduleBusiness:ISchedule
    {
        private UnitOfWorks unitOfWork;
        private ScheduleException scheduleException;
        public ScheduleBusiness()
        {
            unitOfWork = new UnitOfWorks();
            scheduleException = new ScheduleException();
        }

        public async Task Delete(int id)
        {
            unitOfWork.ScheduleRepository.Delete(id);
            await unitOfWork.SaveAsync();
        }

        public IEnumerable<Schedule> Get()
        {
            return unitOfWork.ScheduleRepository.Get();
        }

        public Schedule GetById(int id)
        {
            return unitOfWork.ScheduleRepository.GetById(id);
        }

        public async Task Insert(Schedule entity)
        {
            var scheduleList = unitOfWork.ScheduleRepository.Get();
            scheduleException.ScheduleNameValidationException(scheduleList, entity);
            scheduleException.ScheduleValidationException(entity);
            unitOfWork.ScheduleRepository.Insert(entity);
            await unitOfWork.SaveAsync();
        }

        public async Task Update(Schedule entity)
        {
            var schedule = unitOfWork.ScheduleRepository.GetById(entity.IdSchedule);
            var scheduleList = unitOfWork.ScheduleRepository.Get().Where(c => c.IdSchedule == entity.IdSchedule);
            
            scheduleException.ScheduleValidationException(entity);
            schedule.NameSchedule = entity.NameSchedule;
            scheduleException.ScheduleNameValidationException(scheduleList,entity);
            unitOfWork.ScheduleRepository.Update(entity);
            await unitOfWork.SaveAsync();
        }
    }
}
