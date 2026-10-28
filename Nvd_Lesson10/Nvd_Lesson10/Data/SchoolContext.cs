using Microsoft.EntityFrameworkCore;
using Nvd_Lesson10.Models;

namespace Nvd_Lesson10.Data;

public class SchoolContext : DbContext
{
    public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }

    public virtual DbSet<Course> Courses { get; set; } = null!;
    public virtual DbSet<Learner> Learners { get; set; } = null!;
    public virtual DbSet<Enrollment> Enrollments { get; set; } = null!;
    public virtual DbSet<Major> Majors { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Major>().ToTable(nameof(Major));
        modelBuilder.Entity<Course>().ToTable(nameof(Course));
        modelBuilder.Entity<Enrollment>().ToTable(nameof(Enrollment));
        modelBuilder.Entity<Learner>().ToTable(nameof(Learner));
    }
}
