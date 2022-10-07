#nullable disable

namespace Memorabilia.Blazor.Pages;

public abstract class CommandQuery : ComponentBase
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }
}
