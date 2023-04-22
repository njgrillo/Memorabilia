namespace Memorabilia.Blazor.Pages.Tools.NewProfileStuff.Sports;

public partial class PositionsProfile
{
    [Parameter]
    public Domain.Entities.Person Person { get; set; }

    [Parameter]
    public Sport Sport { get; set; }

    private Domain.Entities.PersonPosition[] Positions;

    protected override void OnParametersSet()
    {
        Positions = Person.Positions
                          .Filter(Sport)
                          .OrderBy(position => position.Position.Name) 
                          .ToArray();
    }
}
