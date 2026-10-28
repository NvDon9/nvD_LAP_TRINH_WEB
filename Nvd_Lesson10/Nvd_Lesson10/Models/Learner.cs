using System.ComponentModel.DataAnnotations;

namespace Nvd_Lesson10.Models;

public class Learner
{
    public Learner()
    {
        Enrollments = new HashSet<Enrollment>();
    }

    public int LearnerID { get; set; }

    [Required, StringLength(50)]
    public string LastName { get; set; } = string.Empty;

    [Required, StringLength(100)]
    public string FirstMidName { get; set; } = string.Empty;

    [DataType(DataType.Date)]
    public DateTime EnrollmentDate { get; set; }

    public int MajorID { get; set; }
    public virtual Major? Major { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; }
}
