namespace Memorabilia.Blazor.Pages.Admin.Divisions;

public partial class DivisionEditor 
    : EditItem<DivisionEditModel, DivisionModel>
{
    protected override async Task OnInitializedAsync()
    {
        if (Id == 0)
            return;

        EditModel = (await Mediator.Send(new GetDivision(Id))).ToEditModel();
    }

    protected async Task Save()
    {
        await Save(new SaveDivision(EditModel));
    }
}
