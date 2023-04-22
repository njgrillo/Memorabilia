namespace Memorabilia.Blazor.Pages.Tools.NewProfileStuff;

public abstract class PersonProfile : ComponentBase
{
    [Parameter]
    public Domain.Entities.Person Person { get; set; }
}
