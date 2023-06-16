namespace Memorabilia.Blazor.Pages.Admin.Divisions;

public partial class DivisionEditor 
    : EditItem<DivisionEditModel, DivisionModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveDivision(EditModel));
    }

    protected override async Task OnInitializedAsync()
    {
        if (Id == 0)
            return;

        EditModel = (await QueryRouter.Send(new GetDivision(Id))).ToEditModel();
    }
}
