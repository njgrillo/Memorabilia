namespace Memorabilia.Blazor.Pages.MemorabiliaItems.GolfBalls;

public partial class EditGolfball
    : MemorabiliaItem<GolfballEditModel>
{
    [Inject]
    public GolfballValidator Validator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        MemorabiliaId = DataProtectorService.DecryptId(EncryptMemorabiliaId);
        EditModel.MemorabiliaId = MemorabiliaId;

        Entity.Memorabilia memorabilia = await Mediator.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (memorabilia.Brand == null)
            return;

        EditModel = new(new GolfballModel(memorabilia));
    }

    protected async Task OnSave()
    {
        var command = new SaveGolfball.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await Mediator.Send(command);
    }
}
