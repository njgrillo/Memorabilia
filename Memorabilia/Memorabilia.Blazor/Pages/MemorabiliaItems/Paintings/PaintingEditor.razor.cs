namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Paintings;

public partial class PaintingEditor : MemorabiliaItem<PaintingEditModel>
{
    [Inject]
    public PaintingValidator Validator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Entity.Memorabilia memorabilia = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (memorabilia.Brand == null)
            return;

        EditModel = new(new PaintingModel(memorabilia));
    }

    protected async Task OnSave()
    {
        var command = new SavePainting.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);
    }
}
