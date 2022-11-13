using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Shared;

public abstract class PersonSportToolViewModel : SportToolViewModel, IWithName
{
    public override string Name => PersonName;

    public abstract int PersonId { get; }

    public abstract string PersonImageFileName { get; }

    public abstract string PersonName { get; }

    public override string ProfileLink => $"/Tools/{SportLeagueLevel.Sport.Name}Profile/{PersonId}";    
}
