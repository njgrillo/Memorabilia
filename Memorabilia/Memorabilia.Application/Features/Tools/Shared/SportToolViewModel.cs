namespace Memorabilia.Application.Features.Tools.Shared;

public abstract class SportToolViewModel : IWithName
{
    public virtual string Name { get; }

    public virtual string ProfileLink { get; set; }

    public Domain.Constants.Sport Sport { get; set; }
}
