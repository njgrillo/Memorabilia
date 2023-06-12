namespace Memorabilia.Blazor.Pages.Admin.Sports;

public partial class SportEditor 
    : EditItem<SportEditModel, SportModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveSport(EditModel));
    }

    protected async Task OnLoad()
    {
        if (Id == 0)
            return;

        EditModel = new SportEditModel(new SportModel(await QueryRouter.Send(new GetSport(Id))));
    }
}
