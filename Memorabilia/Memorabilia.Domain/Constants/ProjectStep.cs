namespace Memorabilia.Domain.Constants;

public class ProjectStep : DomainItemConstant
{
    public static readonly ProjectStep General = new(2, "General Information");
    public static readonly ProjectStep ProjectDetail = new(3, "Project Details");
    public static readonly ProjectStep ProjectType = new(1, "Project Type");   
    
    public static readonly ProjectStep[] All =
    [
       General,
       ProjectDetail,
       ProjectType
    ];

    private ProjectStep(int id, string name)
        : base(id, name) { }

    public static ProjectStep Find(int id)
        => All.SingleOrDefault(projectStep => projectStep.Id == id);
}
