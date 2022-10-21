namespace Memorabilia.Blazor.Pages.Admin.Divisions;

public partial class DivisionEditor : EditItem<SaveDivisionViewModel, DivisionViewModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveDivision(ViewModel));
    }

    protected async Task OnLoad()
    {
        if (Id == 0)
            return;

        ViewModel = new SaveDivisionViewModel(await Get(new GetDivision(Id)));
    }
}
