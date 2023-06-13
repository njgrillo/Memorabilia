namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Bammers;

public partial class BammerEditor 
    : MemorabiliaItem<BammerEditModel>
{
    [Inject]
    public BammerValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        Entity.Memorabilia memorabilia = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (memorabilia.Brand == null)
            return;

        EditModel = new(new BammerModel(memorabilia));
    }

    protected async Task OnSave()
    {
        var command = new SaveBammer.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        EditModel.SavedSuccessfully = true;
    }
}
