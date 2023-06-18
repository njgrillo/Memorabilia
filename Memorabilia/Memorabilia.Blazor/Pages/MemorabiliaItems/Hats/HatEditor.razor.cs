namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Hats;

public partial class HatEditor 
    : MemorabiliaItem<HatEditModel>
{
    [Inject]
    public HatValidator Validator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Entity.Memorabilia memorabilia = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (memorabilia.Brand == null)
            return;

        EditModel = new(new HatModel(memorabilia));
    }

    protected async Task OnSave()
    {
        var command = new SaveHat.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        EditModel.SavedSuccessfully = true;
    }
}
