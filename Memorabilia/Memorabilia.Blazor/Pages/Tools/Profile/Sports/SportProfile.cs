namespace Memorabilia.Blazor.Pages.Tools.Profile.Sports;

public abstract class SportProfile : PersonProfile
{
    [Parameter]
    public Sport Sport { get; set; }
}
