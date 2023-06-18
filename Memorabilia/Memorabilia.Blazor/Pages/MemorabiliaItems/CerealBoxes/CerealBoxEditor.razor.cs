namespace Memorabilia.Blazor.Pages.MemorabiliaItems.CerealBoxes;

public partial class CerealBoxEditor 
    : MemorabiliaItem<CerealBoxEditModel>
{
    [Inject]
    public CerealBoxValidator Validator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Entity.Memorabilia memorabilia = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (memorabilia.Brand == null)
            return;

        EditModel = new CerealBoxEditModel(new CerealBoxModel(memorabilia));
    }

    protected async Task OnSave()
    {
        var command = new SaveCerealBox.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        EditModel.SavedSuccessfully = true; 
    }
}
