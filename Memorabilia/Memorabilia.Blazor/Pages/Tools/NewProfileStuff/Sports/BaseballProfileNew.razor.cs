namespace Memorabilia.Blazor.Pages.Tools.NewProfileStuff.Sports;

public partial class BaseballProfileNew
{
    [Parameter]
    public Domain.Entities.Person Person { get; set; }

    private Sport Sport => Sport.Baseball;
}
