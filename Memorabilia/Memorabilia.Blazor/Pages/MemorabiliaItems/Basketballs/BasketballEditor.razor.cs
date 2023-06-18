namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Basketballs;

public partial class BasketballEditor 
    : MemorabiliaItem<BasketballEditModel>
{
    [Inject]
    public BasketballValidator Validator { get; set; }

    protected override async Task OnInitializedAsync()
    {      
        Entity.Memorabilia memorabilia = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (memorabilia.Brand == null)
            return;

        EditModel = new(new BasketballModel(memorabilia));
    }    

    protected async Task OnSave()
    {
        var command = new SaveBasketball.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        EditModel.SavedSuccessfully = true;
    }
}
