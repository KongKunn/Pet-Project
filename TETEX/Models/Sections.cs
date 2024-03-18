using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Xml;

namespace TETEX.Models
{
    public class Sections
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset ModifiedDate { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public string VideoUrl { get; set; }

        public Guid CourseId { get; set; }
        //public object CourseID { get; internal set; }
        public Course Course { get; set; }
        public ICollection<Lessons> Lessons { get; set; }
    }
}
