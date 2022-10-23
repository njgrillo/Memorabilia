namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Photos;

public partial class PhotoEditor : MemorabiliaItem<SavePhotoViewModel>
{
    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetPhoto(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SavePhotoViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SavePhoto.Command(ViewModel));
    }
}
