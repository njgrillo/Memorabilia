namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Baseballs;

public partial class EditBaseball 
    : MemorabiliaItem<BaseballEditModel>
{
    [Inject]
    public BaseballValidator Validator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        MemorabiliaId = DataProtectorService.DecryptId(EncryptMemorabiliaId);
        EditModel.MemorabiliaId = MemorabiliaId;

        Entity.Memorabilia memorabilia = await Mediator.Send(new GetMemorabiliaItem(MemorabiliaId));        

        if (memorabilia.Brand == null)
            return;

        EditModel = new(new BaseballModel(memorabilia));
    }

    protected async Task OnSave()
    {
        var command = new SaveBaseball.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await Mediator.Send(command);
    }    
}
