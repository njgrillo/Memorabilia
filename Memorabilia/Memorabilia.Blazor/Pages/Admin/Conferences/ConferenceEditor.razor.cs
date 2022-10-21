namespace Memorabilia.Blazor.Pages.Admin.Conferences;

public partial class ConferenceEditor : EditItem<SaveConferenceViewModel, ConferenceViewModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveConference(ViewModel));
    }

    protected async Task OnLoad()
    {
        if (Id == 0)
            return;

        ViewModel = new SaveConferenceViewModel(await Get(new GetConference(Id)));
    }
}
