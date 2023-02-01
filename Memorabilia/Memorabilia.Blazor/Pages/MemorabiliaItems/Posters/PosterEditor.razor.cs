namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Posters;

public partial class PosterEditor : MemorabiliaItem<SavePosterViewModel>
{
    [Inject]
    public PosterValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetPoster(MemorabiliaId));

        if (viewModel.Size == null)
            return;

        ViewModel = new SavePosterViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        var command = new SavePoster.Command(ViewModel);

        ViewModel.ValidationResult = Validator.Validate(command);

        if (!ViewModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        ViewModel.SavedSuccessfully = true;
    }
}
