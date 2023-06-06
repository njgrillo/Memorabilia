namespace Memorabilia.Application.Features.Tools.Shared;

public abstract class SportToolModel : IWithName
{
    public virtual string Name { get; }

    public virtual string ProfileLink { get; set; }

    public Constant.Sport Sport { get; set; }
}
