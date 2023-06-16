namespace Memorabilia.Blazor.Pages.Admin.Commissioners;

public partial class CommissionerEditor 
    : EditItem<CommissionerEditModel, CommissionerModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveCommissioner(EditModel));
    }

    protected override async Task OnInitializedAsync()
    {
        if (Id == 0)
            return;        

        EditModel = (await QueryRouter.Send(new GetCommissioner(Id))).ToEditModel();
    }
}
