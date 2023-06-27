namespace Memorabilia.Blazor.Pages.Admin.People;

public partial class AccoladePersonEditor 
    : EditPersonItem<PersonAccoladeEditModel, PersonAccoladeModel>
{
    [Inject]
    public AccoladeValidator Validator { get; set; }    

    protected override async Task OnInitializedAsync()
    {
        PersonAccoladeModel model 
            = new(await QueryRouter.Send(new GetPerson(PersonId)));

        EditModel = new PersonAccoladeEditModel(PersonId, model);

        IsLoaded = true;
    }

    protected async Task Save()
    {
        var command = new SavePersonAccolades.Command(PersonId, EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await HandleValidSubmit(command);
    }
}
