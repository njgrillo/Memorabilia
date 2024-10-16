namespace Memorabilia.Blazor.Pages.Admin.Colleges;

public partial class EditCollege
    : EditItem<CollegeEditModel, CollegeModel>
{
    protected override async Task OnInitializedAsync()
    {
        if (Id == 0)
            return;

        EditModel = (await Mediator.Send(new GetCollege(Id))).ToEditModel();
    }

    protected async Task Save()
    {
        await Save(new SaveCollege(EditModel));
    }
}
