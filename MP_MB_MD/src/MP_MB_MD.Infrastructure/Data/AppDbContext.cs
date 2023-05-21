using Ardalis.EFCore.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MP_MB_MD.Core.ProjectAggregate;
using MP_MB_MD.Core.ProjectAggregate.Entity;
using MP_MB_MD.SharedKernel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MP_MB_MD.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IMediator _mediator;

        //public AppDbContext(DbContextOptions options) : base(options)
        //{
        //}

        public AppDbContext(DbContextOptions<AppDbContext> options, IMediator mediator)
            : base(options)
        {
            _mediator = mediator;
        }

        public DbSet<ToDoItem> ToDoItems { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyAllConfigurationsFromCurrentAssembly();

            // alternately this is built-in to EF Core 2.2
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            // ignore events if no dispatcher provided
            if (_mediator == null) return result;

            // dispatch events only if save was successful
            var entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
                .Select(e => e.Entity)
                .Where(e => e.Events.Any())
                .ToArray();

            foreach (var entity in entitiesWithEvents)
            {
                var events = entity.Events.ToArray();
                entity.Events.Clear();
                foreach (var domainEvent in events)
                {
                    await _mediator.Publish(domainEvent).ConfigureAwait(false);
                }
            }

            return result;
        }

        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }

        public DbSet<Grievance> Grievance { get; set; }
        public DbSet<Manage_User> Manage_User { get; set; }
        public DbSet<Mst_UserType> Mst_UserType { get; set; }
        public DbSet<Block_Ulb> Block_Ulb { get; set; }
        public DbSet<Gram_Panchayat> Gram_Panchayat { get; set; }
        public DbSet<Department_Table> Department_Table { get; set; }
        
    }
}