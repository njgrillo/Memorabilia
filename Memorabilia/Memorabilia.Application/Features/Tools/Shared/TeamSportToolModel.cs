namespace Memorabilia.Application.Features.Tools.Shared;

public abstract class TeamSportToolModel : SportToolModel, IWithName
{
    public override string Name 
        => TeamName;

    public abstract int TeamId { get; }

    public abstract string TeamName { get; }    
}
