using Microsoft.EntityFrameworkCore;
using ProjectHive.API.Models;
using ProjectHive.API.Models.DTO;

namespace ProjectHive.API.Data
{
    public class ProjectHiveDbContext : DbContext
    {
        public ProjectHiveDbContext(DbContextOptions<ProjectHiveDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<ProjectTracker> ProjectTracker { get; set; }
        public DbSet<GeographyLocation> GeographyLocation { get; set; }
        public DbSet<AccountList> AccountList { get; set; }
        public DbSet<VerticalList> VerticalList { get; set; }
        public DbSet<StatusList> StatusList { get; set; }
        public DbSet<ProjectTrackerViewEx> ProjectTrackerViewEx { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectTracker>()
                .HasMany(g => g.GeographyLocations)
                .WithMany(p => p.ProjectTrackers);

            modelBuilder.Entity<ProjectTracker>()
               .HasOne(u => u.AccountList)
               .WithMany(up => up.ProjectTracker)
               .HasForeignKey(up => up.AccountListId);

            modelBuilder.Entity<ProjectTracker>()
                .HasOne(u => u.VerticalList)
                .WithMany(v => v.ProjectTracker)
                .HasForeignKey(v => v.VerticalListId);

            modelBuilder.Entity<ProjectTracker>()
                .HasOne(p => p.StatusList)
                .WithMany(s => s.ProjectTracker)
                .HasForeignKey(s => s.StatusListId);

            modelBuilder.Entity<ProjectTrackerViewEx>()
            .HasNoKey() // Since this is a view, there's no primary key
            .ToView("projecttrackerview"); // This maps to your SQL view
        }

    }
}
