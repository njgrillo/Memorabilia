namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Pants;

public partial class PantEditor 
    : MemorabiliaItem<PantEditModel>
{
    [Inject]
    public PantValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        Entity.Memorabilia memorabilia = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (memorabilia.Brand == null)
            return;

        EditModel = new(new PantModel(memorabilia));
    }

    protected async Task OnSave()
    {
        var command = new SavePant.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        EditModel.SavedSuccessfully = true;
    }
}
