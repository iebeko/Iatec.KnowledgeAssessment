using Iatec.Knowledge.Assessment.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iatec.KnowledgeAssessment.Context
{
    public class BuilderContext:DbContext
    {
        public BuilderContext() 
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<BuilderContext>());
        }

        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<ScheduleEvent> ScheduleEvents { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<EventNotification> EventNotifications { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
        }
    }
}
