namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Jerseys;

public partial class JerseyEditor 
    : MemorabiliaItem<JerseyEditModel>
{
    [Inject]
    public JerseyValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        Entity.Memorabilia memorabilia = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (memorabilia.Brand == null)
            return;

        EditModel = new(new JerseyModel(memorabilia));
    }

    protected async Task OnSave()
    {
        var command = new SaveJersey.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        EditModel.SavedSuccessfully = true;
    }
}
