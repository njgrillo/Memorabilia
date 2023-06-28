namespace Memorabilia.Blazor.Pages.Admin.Sports;

public partial class SportEditor 
    : EditItem<SportEditModel, SportModel>
{
    protected override async Task OnInitializedAsync()
    {
        if (Id == 0)
            return;

        EditModel = (await QueryRouter.Send(new GetSport(Id))).ToEditModel();
    }

    protected async Task Save()
    {
        await Save(new SaveSport(EditModel));
    }
}
