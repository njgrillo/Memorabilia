namespace Memorabilia.Domain.Entities;

public class ProjectHelmet : Entity
{
    public ProjectHelmet() { }

    public ProjectHelmet(int projectId,
        int helmetTypeId,
        int? helmetFinishId,
        int? sizeId)
    {
        ProjectId = projectId;
        HelmetTypeId = helmetTypeId;
        HelmetFinishId = helmetFinishId;
        SizeId = sizeId;
    }

    public int? HelmetFinishId { get; set; }

    public int HelmetTypeId { get; set; }

    public int ProjectId { get; set; }

    public int? SizeId { get; set; }

    public void Set(int helmetTypeId, int? helmetFinishId, int? sizeId)
    {
        HelmetTypeId = helmetTypeId;
        HelmetFinishId = helmetFinishId;
        SizeId = sizeId;
    }
}
