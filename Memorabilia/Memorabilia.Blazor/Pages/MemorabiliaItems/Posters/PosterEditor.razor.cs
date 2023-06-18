namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Posters;

public partial class PosterEditor 
    : MemorabiliaItem<PosterEditModel>
{
    [Inject]
    public PosterValidator Validator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Entity.Memorabilia memorabilia = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (memorabilia.Size == null)
            return;

        EditModel = new(new PosterModel(memorabilia));
    }

    protected async Task OnSave()
    {
        var command = new SavePoster.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        EditModel.SavedSuccessfully = true;
    }
}
