using DBmodels.Models;
using Microsoft.EntityFrameworkCore;

namespace DBmodels.Configuration
{
    public class GcContext : DbContext
    {
        public GcContext(DbContextOptions<GcContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Stage> Stages { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Criterion> Criterions { get; set; }
        public DbSet<GcAttribute> GcAttributes { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<Preference> Preferences { get; set; }
        public DbSet<Threshold> Thresholds { get; set; }
        public DbSet<Constraint> Constraints { get; set; }
    }
}
