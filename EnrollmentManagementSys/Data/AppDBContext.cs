using EnrollmentManagementSys.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EnrollmentManagementSys.Models.ModelViews;

namespace EnrollmentManagementSys.Data
{
    public class AppDBContext : IdentityDbContext<ApplicationUser>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }


        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentsCourses { get; set;}
        public DbSet<YearLevel> YearLevels { get; set; }
        public DbSet<StudentStatus> StudentStatuses { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public DbSet<StudentSubjectType> StudentSubjectTypes { get; set; }
        public DbSet<Fee> Fees { get; set; }
        public DbSet<FeeType> FeeTypes { get; set; }
        public DbSet<Term> Terms { get; set; }
        public DbSet<StudentPayment> StudentPayments { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<ModeOfPayment> ModeOfPayments { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<OfferedSubject> OfferedSubjects { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<ClassType> ClassTypes { get; set; }
        public DbSet<SubjectSchedule> SubjectSchedules { get; set; }
        public DbSet<Instructor> Instructors { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<StudentSubjectType>()
                .HasMany(x => x.StudentSubjects)
                .WithOne(x => x.StudentSubjectType)
                .HasForeignKey(x => x.TypeID)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);

            builder.Entity<Student>()
                .HasMany(x => x.StudentPayments)
                .WithOne(x => x.Student)
                .HasForeignKey(x => x.RecordID)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);

            builder.Entity<StudentSubject>()
                .HasMany(x => x.OfferedSubjects)
                .WithOne(x => x.StudentSubject)
                .HasForeignKey(x => x.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<SubjectSchedule>()
                .HasOne(ss => ss.Section)
                .WithMany(s => s.SubjectSchedules)
                .HasForeignKey(ss => ss.SectionID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<SubjectSchedule>()
                .HasOne(ss => ss.Instructor)
                .WithMany(i => i.SubjectSchedules)
                .HasForeignKey(ss => ss.InstructorID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<SubjectSchedule>()
                .HasOne(ss => ss.Room)
                .WithMany(r => r.SubjectSchedules)
                .HasForeignKey(ss => ss.RoomID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<SubjectSchedule>()
                .HasOne(ss => ss.SchoolYear)
                .WithMany(sy => sy.SubjectSchedules)
                .HasForeignKey(ss => ss.SchoolYearID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<SubjectSchedule>()
                .HasOne(ss => ss.Semester)
                .WithMany(se => se.SubjectSchedules)
                .HasForeignKey(ss => ss.SemesterID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<SubjectSchedule>()
                .HasOne(ss => ss.StudentSubject)
                .WithMany(ssb => ssb.SubjectSchedules)
                .HasForeignKey(ss => ss.SubjectId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<SubjectSchedule>()
                .HasOne(ss => ss.StudentCourse)
                .WithMany(sc => sc.SubjectSchedules)
                .HasForeignKey(ss => ss.StudentCourseID)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(builder);

            builder.Entity<Student>()
                .HasMany(x => x.Enrollments)
                .WithOne(x => x.Student)
                .HasForeignKey(x => x.RecordID)
                .OnDelete(DeleteBehavior.Restrict);

        }
        public DbSet<EnrollmentManagementSys.Models.ModelViews.ApplicationUserView> ApplicationUserView { get; set; } = default!;
        public DbSet<SchoolYear> SchoolYears { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<EnrollmentStatus> EnrollmentsStatuses { get; set;}
    }

}
