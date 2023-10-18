namespace Memorabilia.Domain.Entities;

public class ProjectCard : Entity
{
    public ProjectCard() { }

    public ProjectCard(int projectId,
        int brandId,
        int? teamId,
        int? year)
    {
        ProjectId = projectId;
        BrandId = brandId;
        TeamId = teamId;
        Year = year;
    }

    public int BrandId { get; set; }

    public int ProjectId { get; set; }

    public int? TeamId { get; set; }

    public int? Year { get; set; }

    public void Set(int brandId, int? teamId, int? year)
    {
        BrandId = brandId;
        TeamId = teamId;
        Year = year;
    }
}
