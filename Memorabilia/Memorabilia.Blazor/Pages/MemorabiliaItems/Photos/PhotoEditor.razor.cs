namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Photos;

public partial class PhotoEditor : MemorabiliaItem<SavePhotoViewModel>
{
    [Inject]
    public PhotoValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetPhoto(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SavePhotoViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        var command = new SavePhoto.Command(ViewModel);

        ViewModel.ValidationResult = Validator.Validate(command);

        if (!ViewModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        ViewModel.SavedSuccessfully = true;
    }
}
