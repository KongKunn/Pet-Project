using System.ComponentModel.DataAnnotations;
using System.Xml;
using static System.Collections.Specialized.BitVector32;

namespace TETEX.Models
{
    public class Lessons
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set;}
        public string Description { get; set;}

        public DateTimeOffset ModifiedDate { get; set; }
        public Guid SectionId { get; set; }
        public Sections Sections { get; set; }


    }
}
