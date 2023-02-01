namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Jerseys;

public partial class JerseyEditor : MemorabiliaItem<SaveJerseyViewModel>
{
    [Inject]
    public JerseyValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetJersey(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SaveJerseyViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        var command = new SaveJersey.Command(ViewModel);

        ViewModel.ValidationResult = Validator.Validate(command);

        if (!ViewModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        ViewModel.SavedSuccessfully = true;
    }
}
