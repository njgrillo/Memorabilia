namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Bats;

public partial class BatEditor 
    : MemorabiliaItem<BatEditModel>
{
    [Inject]
    public BatValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        Entity.Memorabilia memorabilia = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (memorabilia.Brand == null)
            return;

        EditModel = new(new BatModel(memorabilia));
    }

    protected async Task OnSave()
    {
        var command = new SaveBat.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        EditModel.SavedSuccessfully = true;
    }
}
