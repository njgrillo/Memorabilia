namespace Memorabilia.Blazor.Pages.Tools.NewProfileStuff.Sports;

public abstract class SportProfile : PersonProfile
{
    [Parameter]
    public Sport Sport { get; set; }
}
