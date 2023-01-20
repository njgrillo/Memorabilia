namespace Memorabilia.Domain.Constants;

public sealed class ProjectStatusType : DomainItemConstant
{
    public static readonly ProjectStatusType Completed = new(1, "Completed");
    public static readonly ProjectStatusType InProgress = new(2, "In Progress");
    public static readonly ProjectStatusType NotStarted = new(3, "Not Started");

    public static readonly ProjectStatusType[] All =
    {
        Completed,
        InProgress, 
        NotStarted
    };

    private ProjectStatusType(int id, string name, string abbreviation = null) : base(id, name, abbreviation) { }

    public static ProjectStatusType Find(int id)
    {
        return All.SingleOrDefault(projectStatusType => projectStatusType.Id == id);
    }
}
