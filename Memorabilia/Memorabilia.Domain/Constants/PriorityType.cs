namespace Memorabilia.Domain.Constants;

public sealed class PriorityType : DomainItemConstant
{
    public static readonly PriorityType MustHave = new(1, "Must Have");
    public static readonly PriorityType NiceToHave = new(2, "Nice to Have");
    public static readonly PriorityType NoWay = new(4, "No Way");
    public static readonly PriorityType TakeItOrLeaveIt = new(3, "Take it or Leave it");
    public static readonly PriorityType Watching = new(1004, "Watching");

    public static readonly PriorityType[] All =
    [
        MustHave,
        NiceToHave,
        NoWay,
        TakeItOrLeaveIt,
        Watching
    ];

    private PriorityType(int id, string name, string abbreviation = null) 
        : base(id, name, abbreviation) { }

    public static PriorityType Find(int id)
        => All.SingleOrDefault(priorityType => priorityType.Id == id);
}
