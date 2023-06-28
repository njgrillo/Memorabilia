namespace Memorabilia.Blazor.Pages.Admin.Conferences;

public partial class ConferenceEditor 
    : EditItem<ConferenceEditModel, ConferenceModel>
{   
    protected override async Task OnInitializedAsync()
    {
        if (Id == 0)
            return;

        EditModel = (await QueryRouter.Send(new GetConference(Id))).ToEditModel();
    }

    protected async Task Save()
    {
        await Save(new SaveConference(EditModel));
    }
}
