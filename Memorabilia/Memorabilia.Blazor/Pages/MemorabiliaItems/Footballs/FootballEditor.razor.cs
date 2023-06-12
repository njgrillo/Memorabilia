namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Footballs;

public partial class FootballEditor : MemorabiliaItem<FootballEditModel>
{
    [Inject]
    public FootballValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new FootballEditModel(new FootballModel(viewModel));
    }

    protected async Task OnSave()
    {
        var command = new SaveFootball.Command(ViewModel);

        ViewModel.ValidationResult = Validator.Validate(command);

        if (!ViewModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        ViewModel.SavedSuccessfully = true; await CommandRouter.Send(new SaveFootball.Command(ViewModel));
    }
}
