namespace Memorabilia.Blazor.Pages.Admin.Conferences;

public partial class ConferenceEditor 
    : EditItem<ConferenceEditModel, ConferenceModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveConference(ViewModel));
    }

    protected async Task OnLoad()
    {
        if (Id == 0)
            return;

        ViewModel = new ConferenceEditModel(new ConferenceModel(await QueryRouter.Send(new GetConference(Id))));
    }
}
