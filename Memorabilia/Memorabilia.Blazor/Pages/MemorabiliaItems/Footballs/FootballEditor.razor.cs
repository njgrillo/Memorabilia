namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Footballs;

public partial class FootballEditor : MemorabiliaItem<SaveFootballViewModel>
{
    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetFootball(MemorabiliaId));

        if (viewModel.Brand == null)
        {
            ViewModel.GameStyleTypeId = GameStyleType.None.Id;
            return;
        }

        ViewModel = new SaveFootballViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveFootball.Command(ViewModel));
    }

    private void SelectedPersonChanged(SavePersonViewModel person)
    {
        ViewModel.Person = person;
    }
}
