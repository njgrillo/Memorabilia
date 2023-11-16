namespace Memorabilia.Domain.Constants;

public sealed class TeamStep : DomainItemConstant
{
    public static readonly TeamStep Championship = new(5, "Championships");
    public static readonly TeamStep Conference = new(3, "Conferences");
    public static readonly TeamStep Division = new(2, "Divisions");       
    public static readonly TeamStep League = new(4, "Leagues");       
    public static readonly TeamStep Team = new(1, "Team");

    public static readonly TeamStep[] All =
    [
       Championship,
       Conference,
       Division,
       League,
       Team
    ];

    private TeamStep(int id, string name) 
        : base(id, name) { }

    public static TeamStep Find(int id)
        => All.SingleOrDefault(teamStep => teamStep.Id == id);
}
