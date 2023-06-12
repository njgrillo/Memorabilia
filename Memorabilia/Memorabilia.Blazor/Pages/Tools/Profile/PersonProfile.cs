namespace Memorabilia.Blazor.Pages.Tools.Profile;

public abstract class PersonProfile : ComponentBase
{
    [Parameter]
    public Entity.PersonOccupation Occupation { get; set; }

    [Parameter]
    public Entity.Person Person { get; set; }

    protected Occupation OccupationType
        => Occupation != null
           ? Constant.Occupation.Find(Occupation.OccupationId)
           : null;
}
