using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Xml;

namespace TETEX.Models
{
    public class Enrollments
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CourseId1 { get; set; }

        public DateTimeOffset ModifiedDate { get; set; }

        public Course Course { get; set; }
        public AspNetUser User { get; set; }

    }
}
