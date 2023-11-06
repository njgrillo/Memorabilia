namespace Memorabilia.Blazor.Pages.Admin.Positions;

public partial class EditPosition 
    : EditItem<PositionEditModel, PositionModel>
{
    protected override async Task OnInitializedAsync()
    {
        if (Id == 0)
            return;

        EditModel = (await Mediator.Send(new GetPosition(Id))).ToEditModel();
    }

    protected async Task Save()
    {
        await Save(new SavePosition(EditModel));
    }
}
