namespace Memorabilia.Blazor.Pages.Admin.Sports;

public partial class SportEditor 
    : EditItem<SportEditModel, SportModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveSport(EditModel));
    }

    protected override async Task OnInitializedAsync()
    {
        if (Id == 0)
            return;

        EditModel = (await QueryRouter.Send(new GetSport(Id))).ToEditModel();
    }
}
