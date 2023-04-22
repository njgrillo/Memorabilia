namespace Memorabilia.Blazor.Pages.Tools.NewProfileStuff.Sports;

public partial class FootballProfileNew
{
    [Parameter]
    public Domain.Entities.Person Person { get; set; }

    private Sport Sport => Sport.Football;
}
