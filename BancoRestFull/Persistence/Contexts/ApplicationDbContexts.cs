using Application.Interfaces;
using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public  class ApplicationDbContexts: DbContext
    {
        private readonly IDateTimeServices DateTimeServices;


        public ApplicationDbContexts(DbContextOptions<ApplicationDbContexts> options, IDateTimeServices dateTime) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
           this.DateTimeServices= dateTime;
        }
        DbSet<Cliente> clientes { get; set; }

        public override Task<int> SaveChangesAsync (CancellationToken cancellation= new CancellationToken())
        {
            
            foreach (var c in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch(c.State){ 
                case EntityState.Added:
                        c.Entity.Create = DateTimeServices.NowUtc;
                        c.Entity.LastModified = DateTimeServices.NowUtc;
                        break;
                    case EntityState.Modified:

                        c.Entity.LastModified=DateTimeServices.NowUtc;
                        break; 
                
                }


            }
           
            return base.SaveChangesAsync(cancellation);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
