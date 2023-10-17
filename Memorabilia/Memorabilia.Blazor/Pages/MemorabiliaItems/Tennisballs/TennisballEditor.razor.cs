namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Tennisballs;

public partial class TennisballEditor 
    : MemorabiliaItem<TennisballEditModel>
{
    [Inject]
    public TennisballValidator Validator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        MemorabiliaId = DataProtectorService.DecryptId(EncryptMemorabiliaId);
        EditModel.MemorabiliaId = MemorabiliaId;

        Entity.Memorabilia memorabilia = await Mediator.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (memorabilia.Brand == null)
            return;

        EditModel = new(new TennisballModel(memorabilia));
    }

    protected async Task OnSave()
    {
        var command = new SaveTennisball.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await Mediator.Send(command);
    }
}
