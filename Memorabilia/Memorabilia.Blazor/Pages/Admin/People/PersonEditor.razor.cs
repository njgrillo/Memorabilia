namespace Memorabilia.Blazor.Pages.Admin.People;

public partial class PersonEditor : EditItem<SavePersonViewModel, PersonViewModel>
{
    protected async Task HandleValidSubmit()
    {
        var command = new SavePerson.Command(ViewModel);

        await HandleValidSubmit(command);

        ViewModel.Id = command.Id;
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
                                + (!ViewModel.Suffix.IsNullOrEmpty() ? $" {ViewModel.Suffix}," : ",")
                                + (!ViewModel.Nickname.IsNullOrEmpty() ? $" {ViewModel.Nickname}" : $" {ViewModel.FirstName}");

        ViewModel.ProfileName = $"{(!ViewModel.Nickname.IsNullOrEmpty() ? ViewModel.Nickname : ViewModel.FirstName)}"
                               + $" {ViewModel.LastName}"
                               + (!ViewModel.Suffix.IsNullOrEmpty() ? $" {ViewModel.Suffix}" : string.Empty);

        ViewModel.LegalName = $"{ViewModel.FirstName}"
                                + (!ViewModel.MiddleName.IsNullOrEmpty() ? $" {ViewModel.MiddleName}" : string.Empty)
                                + (!ViewModel.LastName.IsNullOrEmpty() ? $" {ViewModel.LastName}" : string.Empty);
    }
}
