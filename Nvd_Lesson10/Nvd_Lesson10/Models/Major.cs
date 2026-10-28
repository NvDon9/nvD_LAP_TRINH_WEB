using System.ComponentModel.DataAnnotations;

namespace Nvd_Lesson10.Models;

public class Major
{
    public int MajorID { get; set; }

    [Required, StringLength(100)]
    public string MajorName { get; set; } = string.Empty;

    public Major()
    {
        Learners = new HashSet<Learner>();
    }

    public virtual ICollection<Learner> Learners { get; set; }
}
