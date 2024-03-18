namespace TETEX.Models.Models_View;

public class CourseModelView
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Requirments { get; set; }
    public int Time { get; set; }
    public string Target { get; set; }
    public string Knowledge { get; set; }
    public Guid UserId { get; set; }
    public Guid CategoryCourseld { get; set; }
    public DateTimeOffset ModifiedDate { get; set; }
    public string ModifiedBy { get; set; }
    public DateTimeOffset CreateDate { get; set; }
    public string CreateBy { get; set; }
    public string Rating { get; set; }
}
