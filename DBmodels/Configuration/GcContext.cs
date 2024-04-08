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
        public DbSet<Member> Members { get; set; }
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>()
                .HasOne(m => m.Project)
                .WithMany()
                .HasForeignKey(m => m.ProjectId);

            modelBuilder.Entity<Member>()
                .HasOne(m => m.User)
                .WithMany()
                .HasForeignKey(m => m.UserId);

            modelBuilder.Entity<Member>()
                .HasOne(m => m.Role)
                .WithMany()
                .HasForeignKey(m => m.RoleId);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Project)
                .WithMany()
                .HasForeignKey(c => c.ProjectId);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Member)
                .WithMany()
                .HasForeignKey(c => c.MemberId);

            modelBuilder.Entity<Evaluation>()
                .HasOne(e => e.Project)
                .WithMany()
                .HasForeignKey(e => e.ProjectId);

            modelBuilder.Entity<Evaluation>()
                .HasOne(e => e.Member)
                .WithMany()
                .HasForeignKey(e => e.MemberId);

            modelBuilder.Entity<Evaluation>()
                .HasOne(e => e.Option)
                .WithMany()
                .HasForeignKey(e => e.OptionId);

            modelBuilder.Entity<Evaluation>()
                .HasOne(e => e.Criterion)
                .WithMany()
                .HasForeignKey(e => e.CriterionId);

            modelBuilder.Entity<Preference>()
                .HasOne(p => p.Project)
                .WithMany()
                .HasForeignKey(p => p.ProjectId);

            modelBuilder.Entity<Preference>()
                .HasOne(p => p.Member)
                .WithMany()
                .HasForeignKey(p => p.MemberId);

            modelBuilder.Entity<Preference>()
                .HasOne(p => p.Criterion1)
                .WithMany()
                .HasForeignKey(p => p.CriterionId1);

            modelBuilder.Entity<Preference>()
                .HasOne(p => p.Criterion2)
                .WithMany()
                .HasForeignKey(p => p.CriterionId2);

            modelBuilder.Entity<Threshold>()
                .HasOne(t => t.Project)
                .WithMany()
                .HasForeignKey(t => t.ProjectId);

            modelBuilder.Entity<Threshold>()
                .HasOne(t => t.Member)
                .WithMany()
                .HasForeignKey(t => t.MemberId);

            modelBuilder.Entity<Threshold>()
                .HasOne(t => t.Criterion)
                .WithMany()
                .HasForeignKey(t => t.CriterionId);

            modelBuilder.Entity<Constraint>()
                .HasOne(c => c.Project)
                .WithMany()
                .HasForeignKey(c => c.ProjectId);

            modelBuilder.Entity<Constraint>()
                .HasOne(c => c.Member)
                .WithMany()
                .HasForeignKey(c => c.MemberId);

            modelBuilder.Entity<Constraint>()
                .HasOne(c => c.Option)
                .WithMany()
                .HasForeignKey(c => c.OptionId);

            modelBuilder.Entity<Constraint>()
                .HasOne(c => c.Criterion)
                .WithMany()
                .HasForeignKey(c => c.CriterionId);
        }
    }
}
