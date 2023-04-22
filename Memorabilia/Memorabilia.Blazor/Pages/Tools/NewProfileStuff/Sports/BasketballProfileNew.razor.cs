namespace Memorabilia.Blazor.Pages.Tools.NewProfileStuff.Sports;

public partial class BasketballProfileNew
{
    [Parameter]
    public Domain.Entities.Person Person { get; set; }

    private Sport Sport => Sport.Basketball;
}
