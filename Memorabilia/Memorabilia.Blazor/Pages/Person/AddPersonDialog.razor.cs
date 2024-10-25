namespace Memorabilia.Blazor.Pages.Person;

public partial class AddPersonDialog : ComponentBase
{
    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public PersonValidator Validator { get; set; }

    [CascadingParameter]
    public MudDialogInstance MudDialog { get; set; }

    protected PersonEditModel EditModel { get; set; }
        = new() { IsUserAdded = true };

    public Alert[] ValidationResultAlerts
        => EditModel.ValidationResult != null
            ? EditModel.ValidationResult.Errors
                                        .Select(error => new Alert(error.ErrorMessage, Severity.Error))
                                        .ToArray()
            : [];

    public void Cancel()
    {
        MudDialog.Cancel();
    }

    public void Close()
    {
        MudDialog.Cancel();
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

    public async Task Save()
    {
        var command = new SavePerson.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await Mediator.Send(command); 

        EditModel.Id = command.Id;

        Entity.Person person = await Mediator.Send(new GetPerson(EditModel.Id));

        MudDialog.Close(DialogResult.Ok(person));
    }
}
