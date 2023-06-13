namespace Memorabilia.Blazor.Services;

public class PersonFilterService
{
    public static bool Filter(Entity.Person person, string search)
        => search.IsNullOrEmpty() ||
           person.DisplayName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           person.ProfileName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           person.FirstName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           person.LastName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           person.LegalName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           person.Nicknames.Any(nickname => nickname.Nickname.Contains(search, StringComparison.OrdinalIgnoreCase)) ||
           CultureInfo.CurrentCulture.CompareInfo.IndexOf(person.LegalName,
                                                          search,
                                                          CompareOptions.IgnoreNonSpace) > -1 ||
           CultureInfo.CurrentCulture.CompareInfo.IndexOf(person.DisplayName,
                                                          search,
                                                          CompareOptions.IgnoreNonSpace) > -1 ||
           CultureInfo.CurrentCulture.CompareInfo.IndexOf(person.ProfileName,
                                                          search,
                                                          CompareOptions.IgnoreNonSpace) > -1 ||
           CultureInfo.CurrentCulture.CompareInfo.IndexOf(person.FirstName,
                                                          search,
                                                          CompareOptions.IgnoreNonSpace) > -1 ||
           CultureInfo.CurrentCulture.CompareInfo.IndexOf(person.LastName,
                                                          search,
                                                          CompareOptions.IgnoreNonSpace) > -1;

    public static bool Filter(PersonModel model, string search)
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
