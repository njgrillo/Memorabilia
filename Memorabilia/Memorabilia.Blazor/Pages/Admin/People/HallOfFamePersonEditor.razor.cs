namespace Memorabilia.Blazor.Pages.Admin.People;

public partial class HallOfFamePersonEditor 
    : EditPersonItem<PersonHallOfFamesEditModel, PersonHallOfFameModel>
{
    [Inject]
    public HallOfFameValidator Validator { get; set; }

    private bool PerformValidation;

    protected async Task HandleValidSubmit()
    {
        var command = new SavePersonHallOfFame.Command(PersonId, EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
        {
            PerformValidation = true;
            return;
        }

        await HandleValidSubmit(new SavePersonHallOfFame.Command(PersonId, EditModel));

        PerformValidation = false;
    }

    protected override async Task OnInitializedAsync()
    {
        var model = new PersonHallOfFameModel(await QueryRouter.Send(new GetPerson(PersonId)));

        EditModel = new PersonHallOfFamesEditModel(PersonId, model);

        PerformValidation = true;
    }    
}
