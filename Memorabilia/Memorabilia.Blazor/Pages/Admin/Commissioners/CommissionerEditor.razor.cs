namespace Memorabilia.Blazor.Pages.Admin.Commissioners;

public partial class CommissionerEditor 
    : EditItem<CommissionerEditModel, CommissionerModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveCommissioner(EditModel));
    }

    protected async Task OnLoad()
    {
        if (Id == 0)
            return;        

        EditModel = new CommissionerEditModel(new CommissionerModel(await QueryRouter.Send(new GetCommissioner(Id))));
    }
}
