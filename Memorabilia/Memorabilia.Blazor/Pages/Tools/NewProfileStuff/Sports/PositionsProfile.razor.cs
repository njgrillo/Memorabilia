namespace Memorabilia.Blazor.Pages.Tools.NewProfileStuff.Sports;

public partial class PositionsProfile : SportProfile
{
    private Domain.Entities.PersonPosition[] Positions;

    protected override void OnParametersSet()
    {
        Positions = Person.Positions
                          .Filter(Sport)
                          .OrderBy(position => position.Position.Name) 
                          .ToArray();
    }
}
