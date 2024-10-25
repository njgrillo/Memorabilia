namespace Memorabilia.Application.Features.Tools.Shared;

public abstract class SportToolModel : Model, IWithName
{
    public virtual string ProfileLink { get; set; }

    public Constant.Sport Sport { get; set; }
}
