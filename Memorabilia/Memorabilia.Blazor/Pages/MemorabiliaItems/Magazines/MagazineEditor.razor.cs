namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Magazines;

public partial class MagazineEditor : MemorabiliaItem<SaveMagazineViewModel>
{
    [Inject]
    public MagazineValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetMagazine(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SaveMagazineViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        var command = new SaveMagazine.Command(ViewModel);

        ViewModel.ValidationResult = Validator.Validate(command);

        if (!ViewModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        ViewModel.SavedSuccessfully = true;
    }
}
