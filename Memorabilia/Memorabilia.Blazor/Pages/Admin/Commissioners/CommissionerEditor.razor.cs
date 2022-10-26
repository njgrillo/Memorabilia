namespace Memorabilia.Blazor.Pages.Admin.Commissioners;

public partial class CommissionerEditor : EditItem<SaveCommissionerViewModel, CommissionerViewModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveCommissioner(ViewModel));
    }

    protected async Task OnLoad()
    {
        if (Id == 0)
            return;

        ViewModel = new SaveCommissionerViewModel(await Get(new GetCommissioner(Id)));
    }
}
