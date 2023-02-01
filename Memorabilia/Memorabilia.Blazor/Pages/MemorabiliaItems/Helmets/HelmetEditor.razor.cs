namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Helmets;

public partial class HelmetEditor : MemorabiliaItem<SaveHelmetViewModel>
{
    [Inject]
    public HelmetValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetHelmet(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SaveHelmetViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        var command = new SaveHelmet.Command(ViewModel);

        ViewModel.ValidationResult = Validator.Validate(command);

        if (!ViewModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        ViewModel.SavedSuccessfully = true;
    }
}
