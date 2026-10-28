using Microsoft.EntityFrameworkCore;
using Nvd_Lesson10.Models;

namespace Nvd_Lesson10.Data;

public static class DbInitializer
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new SchoolContext(
            serviceProvider.GetRequiredService<DbContextOptions<SchoolContext>>());

        context.Database.EnsureCreated();

        if (context.Majors.Any())
            return;

        context.Majors.AddRange(
            new Major { MajorName = "Information Technology" },
            new Major { MajorName = "Economics" },
            new Major { MajorName = "Mathematics" });
        context.SaveChanges();

        context.Learners.AddRange(
            new Learner { FirstMidName = "Carson", LastName = "Alexander", EnrollmentDate = new DateTime(2005, 9, 1), MajorID = 1 },
            new Learner { FirstMidName = "Meredith", LastName = "Alonso", EnrollmentDate = new DateTime(2002, 9, 1), MajorID = 2 },
            new Learner { FirstMidName = "Arturo", LastName = "Anand", EnrollmentDate = new DateTime(2003, 9, 1), MajorID = 3 });

        context.Courses.AddRange(
            new Course { CourseID = 1050, Title = "Chemistry", Credits = 3 },
            new Course { CourseID = 4022, Title = "Microeconomics", Credits = 3 },
            new Course { CourseID = 4041, Title = "Macroeconomics", Credits = 3 });
        context.SaveChanges();

        context.Enrollments.AddRange(
            new Enrollment { LearnerID = 1, CourseID = 1050, Grade = 5.5f },
            new Enrollment { LearnerID = 1, CourseID = 4022, Grade = 3.5f },
            new Enrollment { LearnerID = 2, CourseID = 4041, Grade = 4.0f });
        context.SaveChanges();
    }
}
