namespace Memorabilia.Blazor.Pages.Admin.People;

public partial class HallOfFamePersonEditor 
    : EditPersonItem<SavePersonHallOfFamesViewModel, PersonHallOfFameViewModel>
{
    [Inject]
    public HallOfFameValidator Validator { get; set; }

    private bool PerformValidation;

    protected async Task HandleValidSubmit()
    {
        var command = new SavePersonHallOfFame.Command(PersonId, ViewModel);

        ViewModel.ValidationResult = Validator.Validate(command);

        if (!ViewModel.ValidationResult.IsValid)
        {
            PerformValidation = true;
            return;
        }

        await HandleValidSubmit(new SavePersonHallOfFame.Command(PersonId, ViewModel));

        PerformValidation = false;
    }

    protected async Task OnLoad()
    {
        ViewModel = new SavePersonHallOfFamesViewModel(PersonId, await Get(new GetPersonHallOfFames(PersonId)));

        PerformValidation = true;
    }    
}
