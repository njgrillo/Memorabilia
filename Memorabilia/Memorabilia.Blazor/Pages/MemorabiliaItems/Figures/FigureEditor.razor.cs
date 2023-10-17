namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Figures;

public partial class FigureEditor 
    : MemorabiliaItem<FigureEditModel>
{
    [Inject]
    public FigureValidator Validator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        MemorabiliaId = DataProtectorService.DecryptId(EncryptMemorabiliaId);
        EditModel.MemorabiliaId = MemorabiliaId;

        Entity.Memorabilia memorabilia = await Mediator.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (memorabilia.Brand == null)
            return;

        EditModel = new(new FigureModel(memorabilia));
    }

    protected async Task OnSave()
    {
        var command = new SaveFigure.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await Mediator.Send(command);
    }
}
