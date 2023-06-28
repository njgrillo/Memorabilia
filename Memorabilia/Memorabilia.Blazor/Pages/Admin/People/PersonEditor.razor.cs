namespace Memorabilia.Blazor.Pages.Admin.People;

public partial class PersonEditor 
    : EditItem<PersonEditModel, PersonModel>
{
    [Inject]
    public PersonValidator Validator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        if (Id == 0)
        {
            IsLoaded = true;
            return;
        }

        Entity.Person person = await QueryRouter.Send(new GetPerson(Id));

        EditModel = new PersonEditModel(new PersonModel(person));

        IsLoaded = true;
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

    protected async Task Save()
    {
        var command = new SavePerson.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await Save(command);

        EditModel.Id = command.Id;
    }
}
