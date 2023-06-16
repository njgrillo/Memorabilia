namespace Memorabilia.Blazor.Pages.Admin.Conferences;

public partial class ViewConferences 
    : ViewItem<ConferencesModel, ConferenceModel>
{
    protected override async Task OnInitializedAsync()
    {
        Model = new ConferencesModel(await QueryRouter.Send(new GetConferences()));
    }

    protected override async Task Delete(int id)
    {
        ConferenceModel deletedItem = Model.Conferences.Single(conference => conference.Id == id);

        var editModel = new ConferenceEditModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveConference(editModel));

        Model.Conferences.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(Model.ItemTitle);
    }

    protected override bool FilterFunc(ConferenceModel model, string search)
        => search.IsNullOrEmpty() ||
           model.SportLeagueLevelName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           model.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           (!model.Abbreviation.IsNullOrEmpty() &&
           model.Abbreviation.Contains(search, StringComparison.OrdinalIgnoreCase));
}
