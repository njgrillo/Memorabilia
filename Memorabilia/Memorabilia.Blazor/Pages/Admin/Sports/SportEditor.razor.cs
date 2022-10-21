namespace Memorabilia.Blazor.Pages.Admin.Sports;

public partial class SportEditor : EditItem<SaveSportViewModel, SportViewModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveSport(ViewModel));
    }

    protected async Task OnLoad()
    {
        if (Id == 0)
            return;

        ViewModel = new SaveSportViewModel(await QueryRouter.Send(new GetSport(Id)));
    }
}
