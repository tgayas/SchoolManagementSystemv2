using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagementSystemv2.Models
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets for all your models
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Teacher> Teachers { get; set; } = null!;
        public DbSet<Course> Courses { get; set; } = null!;
        public DbSet<Enrollment> Enrollments { get; set; } = null!;
        public DbSet<Grade> Grades { get; set; } = null!;
        public DbSet<Attendance> Attendances { get; set; } = null!;
        public DbSet<Classroom> Classrooms { get; set; } = null!;
        public DbSet<Parent> Parents { get; set; } = null!;
        public DbSet<PaymentRecord> PaymentRecords { get; set; } = null!;
        public DbSet<TuitionBilling> TuitionBillings { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure precision for decimal properties
            modelBuilder.Entity<Grade>()
                .Property(g => g.Score)
                .HasPrecision(18, 2); // Precision: 18 digits total, 2 after the decimal point

            modelBuilder.Entity<PaymentRecord>()
                .Property(pr => pr.Amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<TuitionBilling>()
                .Property(tb => tb.TotalAmount)
                .HasPrecision(18, 2);

            // Configure relationships with Fluent API
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId);

            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Student)
                .WithMany(s => s.Attendances)
                .HasForeignKey(a => a.StudentId);

            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Course)
                .WithMany(c => c.Attendances)
                .HasForeignKey(a => a.CourseId);

            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Student)
                .WithMany(s => s.Grades)
                .HasForeignKey(g => g.StudentId);

            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Course)
                .WithMany(c => c.Grades)
                .HasForeignKey(g => g.CourseId);

            modelBuilder.Entity<PaymentRecord>()
                .HasOne(pr => pr.Student)
                .WithMany(s => s.PaymentRecords)
                .HasForeignKey(pr => pr.StudentId);

            modelBuilder.Entity<TuitionBilling>()
                .HasOne(tb => tb.Student)
                .WithMany(s => s.TuitionBillings)
                .HasForeignKey(tb => tb.StudentId);

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Classroom)
                .WithMany(cr => cr.Courses)
                .HasForeignKey(c => c.ClassroomId);

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Teacher)
                .WithMany(t => t.Courses)
                .HasForeignKey(c => c.TeacherId);

            // Seed data
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher { Id = 1, FirstName = "John", LastName = "Doe", SubjectSpecialization = "Mathematics" },
                new Teacher { Id = 2, FirstName = "Jane", LastName = "Smith", SubjectSpecialization = "Physics" }
            );

            modelBuilder.Entity<Classroom>().HasData(
                new Classroom { Id = 1, RoomNumber = "A101", Location = "Main Building" },
                new Classroom { Id = 2, RoomNumber = "B202", Location = "Science Wing" }
            );

            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    Id = 1,
                    CourseName = "Physics 101",
                    TeacherId = 2,
                    ClassroomId = 2,
                    Credits = 4,
                    Description = "Introduction to Physics"
                }
            );
        }
    }
}
