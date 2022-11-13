namespace Memorabilia.Application.Features.Tools.Shared;

public abstract class TeamSportToolViewModel : SportToolViewModel, IWithName
{
    public override string Name => TeamName;

    public abstract int TeamId { get; }

    public abstract string TeamName { get; }    
}
