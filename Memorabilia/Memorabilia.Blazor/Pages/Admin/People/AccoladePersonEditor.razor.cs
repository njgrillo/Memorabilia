namespace Memorabilia.Blazor.Pages.Admin.People;

public partial class AccoladePersonEditor 
    : EditPersonItem<PersonAccoladeEditModel, PersonAccoladeModel>
{
    [Inject]
    public AccoladeValidator Validator { get; set; }

    private bool PerformValidation;

    protected async Task HandleValidSubmit()
    {
        var command = new SavePersonAccolades.Command(PersonId, EditModel);        

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
        {
            PerformValidation = true;
            return;
        }

        await HandleValidSubmit(command);

        PerformValidation = false;
    }

    protected override async Task OnInitializedAsync()
    {
        PersonAccoladeModel model 
            = new(await QueryRouter.Send(new GetPerson(PersonId)));

        EditModel = new PersonAccoladeEditModel(PersonId, model);

        PerformValidation = true;
    }    
}
