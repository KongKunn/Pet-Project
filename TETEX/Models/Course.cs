using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Xml;

namespace TETEX.Models
{
    public class Course
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Requirments { get; set; }   
        public Guid UserId { get; set; }
        public Guid CategoryCourseld { get; set; }
        public DateTimeOffset ModifiedDate { get; set; }
        public ICollection<Enrollments> Enrollments { get; set; }



    }
}
