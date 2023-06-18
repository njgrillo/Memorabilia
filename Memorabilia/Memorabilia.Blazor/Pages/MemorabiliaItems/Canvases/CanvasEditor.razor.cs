namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Canvases;

public partial class CanvasEditor 
    : MemorabiliaItem<CanvasEditModel>
{
    [Inject]
    public CanvasValidator Validator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Entity.Memorabilia memorabilia = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

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

        await CommandRouter.Send(command);

        EditModel.SavedSuccessfully = true;
    }
}
