namespace Memorabilia.Blazor.Pages.Admin.Conferences;

public partial class ViewConferences : ViewItem<ConferencesModel, ConferenceModel>
{
    protected async Task OnLoad()
    {
        ViewModel = new ConferencesModel(await QueryRouter.Send(new GetConferences()));
    }

    protected override async Task Delete(int id)
    {
        var deletedItem = ViewModel.Conferences.Single(conference => conference.Id == id);
        var viewModel = new ConferenceEditModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveConference(viewModel));

        ViewModel.Conferences.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(ViewModel.ItemTitle);
    }

    protected override bool FilterFunc(ConferenceModel viewModel, string search)
        => search.IsNullOrEmpty() ||
           viewModel.SportLeagueLevelName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           viewModel.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           (!viewModel.Abbreviation.IsNullOrEmpty() &&
           viewModel.Abbreviation.Contains(search, StringComparison.OrdinalIgnoreCase));
}
