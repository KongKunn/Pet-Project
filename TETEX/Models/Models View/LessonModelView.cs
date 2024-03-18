namespace TETEX.Models.Models_View;

public class LessonModelView

{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string VideoUrl { get; set; }
    public string Time { get; set; }

    public DateTimeOffset ModifiedDate { get; set; }
    public string ModifiedBy { get; set; }
    public DateTimeOffset CreateDate { get; set; }
    public Guid SectionId { get; set; }
    public Sections Sections { get; set; }
}
