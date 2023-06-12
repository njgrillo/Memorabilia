namespace Memorabilia.Blazor.Pages.Admin.People;

public partial class ViewPeople 
    : ViewItem<PeopleModel, PersonModel>
{
    protected async Task OnLoad()
    {
        ViewModel = new PeopleModel(await QueryRouter.Send(new GetPeople()));
    }

    protected override async Task Delete(int id)
    {
        PersonModel deletedItem = ViewModel.People.Single(person => person.Id == id);
        var viewModel = new PersonEditModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SavePerson.Command(viewModel));

        ViewModel.People.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(ViewModel.ItemTitle);
    }

    protected override bool FilterFunc(PersonModel viewModel, string search)
        => search.IsNullOrEmpty() ||
           viewModel.DisplayName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           viewModel.ProfileName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           viewModel.FirstName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           viewModel.LastName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           viewModel.LegalName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           viewModel.Nicknames.Any(nickname => nickname.Nickname.Contains(search, StringComparison.OrdinalIgnoreCase)) ||
           CultureInfo.CurrentCulture.CompareInfo.IndexOf(viewModel.LegalName,
                                                          search,
                                                          CompareOptions.IgnoreNonSpace) > -1 ||
           CultureInfo.CurrentCulture.CompareInfo.IndexOf(viewModel.DisplayName,
                                                          search,
                                                          CompareOptions.IgnoreNonSpace) > -1 ||
           CultureInfo.CurrentCulture.CompareInfo.IndexOf(viewModel.ProfileName,
                                                          search,
                                                          CompareOptions.IgnoreNonSpace) > -1 ||
           CultureInfo.CurrentCulture.CompareInfo.IndexOf(viewModel.FirstName,
                                                          search,
                                                          CompareOptions.IgnoreNonSpace) > -1 ||
           CultureInfo.CurrentCulture.CompareInfo.IndexOf(viewModel.LastName,
                                                          search,
                                                          CompareOptions.IgnoreNonSpace) > -1;
}
