using Iatec.Knowledge.Assessment.Entity;
using Iatec.KnowledgeAssessment.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iatec.Knowledge.Assessment.Contracts
{
    public class UnitOfWorks : IDisposable
    {
        public BuilderContext context;
        public UnitOfWorks()
        {
            this.context = new BuilderContext();
        }

        private GenericRepository<Event> eventRepository;
        private GenericRepository<Schedule> scheduleRepository;
        private GenericRepository<ScheduleEvent> scheduleEventRepository;
        private GenericRepository<User> userRepository;

        public GenericRepository<Event> EventRepository 
        {
            get 
            {
                if (this.eventRepository == null) 
                {
                    this.eventRepository = new GenericRepository<Event>(context);
                }
                return eventRepository;
            }
        }
        public GenericRepository<ScheduleEvent> ScheduleEventRepository 
        {
            get 
            {
                if (this.scheduleEventRepository == null) 
                {
                    this.scheduleEventRepository = new GenericRepository<ScheduleEvent>(context);
                }
                return scheduleEventRepository;
            }
        }

        private GenericRepository<Schedule> ScheduleRepository 
        {
            get 
            {
                if (this.scheduleRepository == null) 
                {
                    this.scheduleRepository = new GenericRepository<Schedule>(context);
                }
                return scheduleRepository;
            }
        }

        public void Save() 
        {
            context.SaveChangesAsync();
        }
        public async Task SaveNoAsync() 
        {
            await context.SaveChangesAsync();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed) 
            {
                if (disposing) 
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose() 
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
