namespace Memorabilia.Blazor.Pages.Admin.Commissioners;

public partial class CommissionerEditor 
    : EditItem<CommissionerEditModel, CommissionerModel>
{   
    protected override async Task OnInitializedAsync()
    {
        if (Id == 0)
            return;        

        EditModel = (await Mediator.Send(new GetCommissioner(Id))).ToEditModel();
    }

    protected async Task Save()
    {
        await Save(new SaveCommissioner(EditModel));
    }
}
