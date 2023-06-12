namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Posters;

public partial class PosterEditor : MemorabiliaItem<PosterEditModel>
{
    [Inject]
    public PosterValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (viewModel.Size == null)
            return;

        ViewModel = new PosterEditModel(new PosterModel(viewModel));
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
