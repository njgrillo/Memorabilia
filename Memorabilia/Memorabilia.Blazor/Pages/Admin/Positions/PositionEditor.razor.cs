namespace Memorabilia.Blazor.Pages.Admin.Positions;

public partial class PositionEditor : EditItem<SavePositionViewModel, PositionViewModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SavePosition(ViewModel));
    }

    protected async Task OnLoad()
    {
        if (Id == 0)
            return;

        ViewModel = new SavePositionViewModel(await Get(new GetPosition(Id)));
    }
}
