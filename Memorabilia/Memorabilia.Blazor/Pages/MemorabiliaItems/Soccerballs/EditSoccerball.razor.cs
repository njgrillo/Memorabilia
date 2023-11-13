namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Soccerballs;

public partial class EditSoccerball
    : MemorabiliaItem<SoccerballEditModel>
{
    [Inject]
    public SoccerballValidator Validator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        MemorabiliaId = DataProtectorService.DecryptId(EncryptMemorabiliaId);
        EditModel.MemorabiliaId = MemorabiliaId;

        Entity.Memorabilia memorabilia = await Mediator.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (memorabilia.Brand == null)
            return;

        EditModel = new(new SoccerballModel(memorabilia));
    }

    protected async Task OnSave()
    {
        var command = new SaveSoccerball.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await Mediator.Send(command);
    }
}
