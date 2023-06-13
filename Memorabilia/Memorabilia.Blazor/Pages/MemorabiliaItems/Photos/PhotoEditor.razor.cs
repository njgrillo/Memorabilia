namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Photos;

public partial class PhotoEditor 
    : MemorabiliaItem<PhotoEditModel>
{
    [Inject]
    public PhotoValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        Entity.Memorabilia memorabilia = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (memorabilia.Brand == null)
            return;

        EditModel = new(new PhotoModel(memorabilia));
    }

    protected async Task OnSave()
    {
        var command = new SavePhoto.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        EditModel.SavedSuccessfully = true;
    }
}
