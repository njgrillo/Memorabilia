namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Guitars;

public partial class GuitarEditor : MemorabiliaItem<SaveGuitarViewModel>
{
    [Inject]
    public GuitarValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetGuitar(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SaveGuitarViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        var command = new SaveGuitar.Command(ViewModel);

        ViewModel.ValidationResult = Validator.Validate(command);

        if (!ViewModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        ViewModel.SavedSuccessfully = true;
    }
}
