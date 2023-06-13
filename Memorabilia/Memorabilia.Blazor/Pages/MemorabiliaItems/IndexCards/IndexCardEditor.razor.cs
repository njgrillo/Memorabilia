namespace Memorabilia.Blazor.Pages.MemorabiliaItems.IndexCards;

public partial class IndexCardEditor 
    : MemorabiliaItem<IndexCardEditModel>
{
    [Inject]
    public IndexCardValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        Entity.Memorabilia memorabilia = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (memorabilia.Size == null)
            return;

        EditModel = new(new IndexCardModel(memorabilia));
    }

    protected async Task OnSave()
    {
        var command = new SaveIndexCard.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        EditModel.SavedSuccessfully = true;
    }
}
