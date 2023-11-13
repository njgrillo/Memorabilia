namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Canvases;

public partial class EditCanvas 
    : MemorabiliaItem<CanvasEditModel>
{
    [Inject]
    public CanvasValidator Validator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        MemorabiliaId = DataProtectorService.DecryptId(EncryptMemorabiliaId);
        EditModel.MemorabiliaId = MemorabiliaId;

        Entity.Memorabilia memorabilia = await Mediator.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (memorabilia.Brand == null)
            return;

        EditModel = new(new CanvasModel(memorabilia));
    }

    protected async Task OnSave()
    {
        var command = new SaveCanvas.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await Mediator.Send(command);
    }
}
