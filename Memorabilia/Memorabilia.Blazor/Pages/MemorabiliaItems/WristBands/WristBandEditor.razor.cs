namespace Memorabilia.Blazor.Pages.MemorabiliaItems.WristBands;

public partial class WristBandEditor : MemorabiliaItem<SaveWristBandViewModel>
{
    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetWristBand(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SaveWristBandViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveWristBand.Command(ViewModel));
    }

    private void SelectedPersonChanged(SavePersonViewModel person)
    {
        ViewModel.Person = person;
    }

    private void SelectedTeamChanged(SaveTeamViewModel team)
    {
        ViewModel.Team = team;
    }
}
