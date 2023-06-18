namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Baseballs;

public partial class BaseballEditor 
    : MemorabiliaItem<BaseballEditModel>
{
    [Inject]
    public BaseballValidator Validator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Entity.Memorabilia memorabilia = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

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

        await CommandRouter.Send(command);

        EditModel.SavedSuccessfully = true;
    }    
}
