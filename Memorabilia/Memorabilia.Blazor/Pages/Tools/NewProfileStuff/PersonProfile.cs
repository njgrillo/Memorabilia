namespace Memorabilia.Blazor.Pages.Tools.NewProfileStuff;

public abstract class PersonProfile : ComponentBase
{
    [Parameter]
    public Domain.Entities.PersonOccupation Occupation { get; set; }

    [Parameter]
    public Domain.Entities.Person Person { get; set; }

    protected Occupation OccupationType
        => Occupation != null
           ? Domain.Constants.Occupation.Find(Occupation.OccupationId)
           : null;
}
