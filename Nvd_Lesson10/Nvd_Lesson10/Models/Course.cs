using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nvd_Lesson10.Models;

public class Course
{
    public Course()
    {
        Enrollments = new HashSet<Enrollment>();
    }

    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int CourseID { get; set; }

    [Required, StringLength(100)]
    public string Title { get; set; } = string.Empty;

    [Range(0, 30)]
    public int Credits { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; }
}
