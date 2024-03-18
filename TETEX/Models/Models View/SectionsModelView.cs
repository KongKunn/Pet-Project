namespace TETEX.Models.Models_View;

public class SectionsModelView

{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTimeOffset ModifiedDate { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public string VideoUrl { get; set; }

    public Guid CourseId { get; set; }
    public Course Course { get; set; }
    public ICollection<Lessons> Lessons { get; set; }
}
