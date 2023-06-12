namespace Memorabilia.Blazor.Pages.Admin.People;

public partial class ViewPeople 
    : ViewItem<PeopleModel, PersonModel>
{
    protected async Task OnLoad()
    {
        Model = new PeopleModel(await QueryRouter.Send(new GetPeople()));
    }

    protected override async Task Delete(int id)
    {
        PersonModel deletedItem = Model.People.Single(person => person.Id == id);

        var editModel = new PersonEditModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SavePerson.Command(editModel));

        Model.People.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(Model.ItemTitle);
    }

    protected override bool FilterFunc(PersonModel model, string search)
        => search.IsNullOrEmpty() ||
           model.DisplayName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           model.ProfileName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           model.FirstName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           model.LastName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           model.LegalName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           model.Nicknames.Any(nickname => nickname.Nickname.Contains(search, StringComparison.OrdinalIgnoreCase)) ||
           CultureInfo.CurrentCulture.CompareInfo.IndexOf(model.LegalName,
                                                          search,
                                                          CompareOptions.IgnoreNonSpace) > -1 ||
           CultureInfo.CurrentCulture.CompareInfo.IndexOf(model.DisplayName,
                                                          search,
                                                          CompareOptions.IgnoreNonSpace) > -1 ||
           CultureInfo.CurrentCulture.CompareInfo.IndexOf(model.ProfileName,
                                                          search,
                                                          CompareOptions.IgnoreNonSpace) > -1 ||
           CultureInfo.CurrentCulture.CompareInfo.IndexOf(model.FirstName,
                                                          search,
                                                          CompareOptions.IgnoreNonSpace) > -1 ||
           CultureInfo.CurrentCulture.CompareInfo.IndexOf(model.LastName,
                                                          search,
                                                          CompareOptions.IgnoreNonSpace) > -1;
}
