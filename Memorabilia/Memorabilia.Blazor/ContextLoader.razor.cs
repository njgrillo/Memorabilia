namespace Memorabilia.Blazor;

public partial class ContextLoader : CommandQuery
{
    private bool _displaySpinner = true;

    protected override async Task OnInitializedAsync()
    {
        await CommandRouter.Send(new InitializeContext());

        _displaySpinner = false;
    }
}
