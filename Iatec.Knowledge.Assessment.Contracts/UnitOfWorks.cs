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
        private GenericRepository<EventNotification> eventNotificationRepository;



        public GenericRepository<EventNotification> EventNotificationRepository 
        {
            get 
            {
                if (this.eventNotificationRepository == null) 
                {
                    this.eventNotificationRepository = new GenericRepository<EventNotification>(context);
                }
                return eventNotificationRepository;
            }
        }

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

        public GenericRepository<Schedule> ScheduleRepository 
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
        public GenericRepository<User> UserRepository 
        {
            get 
            {
                if (this.userRepository == null) 
                {
                    this.userRepository = new GenericRepository<User>(context);
                }
                return userRepository;
            }
        }
        public void Save() 
        {
            context.SaveChanges();
        }
        public async Task SaveAsync() 
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
