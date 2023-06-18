namespace Memorabilia.Blazor.Pages.Admin.People;

public partial class PersonEditor 
    : EditItem<PersonEditModel, PersonModel>
{
    [Inject]
    public PersonValidator Validator { get; set; }

    protected bool PerformValidation;

    protected async Task HandleValidSubmit()
    {
        var command = new SavePerson.Command(EditModel);

        PerformValidation = true;

        EditModel.ValidationResult = Validator.Validate(command);        

        if (!EditModel.ValidationResult.IsValid)
            return;

        await HandleValidSubmit(command);

        EditModel.Id = command.Id;

        PerformValidation = false;
    }

    protected override async Task OnInitializedAsync()
    {
        if (Id == 0)
            return;

        Entity.Person person = await QueryRouter.Send(new GetPerson(Id));

        EditModel = new PersonEditModel(new PersonModel(person));
    }

    public void OnNameFieldBlur()
    {
        EditModel.DisplayName = $"{EditModel.LastName}"
                                + (!EditModel.Nickname.IsNullOrEmpty() ? $", {EditModel.Nickname}" : $", {EditModel.FirstName}");

        EditModel.ProfileName = $"{(!EditModel.Nickname.IsNullOrEmpty() ? EditModel.Nickname : EditModel.FirstName)}"
                               + $" {EditModel.LastName}";

        EditModel.LegalName = $"{EditModel.FirstName}"
                                + (!EditModel.MiddleName.IsNullOrEmpty() ? $" {EditModel.MiddleName}" : string.Empty)
                                + (!EditModel.LastName.IsNullOrEmpty() ? $" {EditModel.LastName}" : string.Empty)
                                + (!EditModel.Suffix.IsNullOrEmpty() ? $" {EditModel.Suffix}" : string.Empty);
    }
}
