namespace Memorabilia.Blazor.Pages.Admin.People;

public partial class PersonEditor : EditItem<SavePersonViewModel, PersonViewModel>
{
    [Inject]
    public PersonValidator Validator { get; set; }

    private bool PerformValidation;

    protected async Task HandleValidSubmit()
    {
        var command = new SavePerson.Command(ViewModel);

        PerformValidation = true;

        ViewModel.ValidationResult = Validator.Validate(command);        

        if (!ViewModel.ValidationResult.IsValid)
            return;

        await HandleValidSubmit(command);

        ViewModel.Id = command.Id;

        PerformValidation = false;
    }

    protected async Task OnLoad()
    {
        if (Id == 0)
            return;

        ViewModel = new SavePersonViewModel(await Get(new GetPerson(Id)));
    }

    public void OnNameFieldBlur()
    {
        ViewModel.DisplayName = $"{ViewModel.LastName}"
                                + (!ViewModel.Nickname.IsNullOrEmpty() ? $", {ViewModel.Nickname}" : $", {ViewModel.FirstName}");

        ViewModel.ProfileName = $"{(!ViewModel.Nickname.IsNullOrEmpty() ? ViewModel.Nickname : ViewModel.FirstName)}"
                               + $" {ViewModel.LastName}";

        ViewModel.LegalName = $"{ViewModel.FirstName}"
                                + (!ViewModel.MiddleName.IsNullOrEmpty() ? $" {ViewModel.MiddleName}" : string.Empty)
                                + (!ViewModel.LastName.IsNullOrEmpty() ? $" {ViewModel.LastName}" : string.Empty)
                                + (!ViewModel.Suffix.IsNullOrEmpty() ? $" {ViewModel.Suffix}" : string.Empty);
    }
}
