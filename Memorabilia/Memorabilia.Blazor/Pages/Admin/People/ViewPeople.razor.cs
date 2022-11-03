#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.People;

public partial class ViewPeople : ViewItem<PeopleViewModel, PersonViewModel>
{
    [Parameter]
    public string PersonImageRootPath { get; set; }

    protected string GetImage(string imagePath)
    {
        var path = imagePath == ImagePath.ImageNotAvailable
                ? imagePath
                : Path.Combine(PersonImageRootPath, imagePath);

        return $"data:image/jpg;base64,{Convert.ToBase64String(File.ReadAllBytes(path))}";
    }

    protected async Task OnLoad()
    {
        await OnLoad(new GetPeople());
    }

    protected override async Task Delete(int id)
    {
        var deletedItem = ViewModel.People.Single(person => person.Id == id);
        var viewModel = new SavePersonViewModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SavePerson.Command(viewModel));

        ViewModel.People.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(ViewModel.ItemTitle);
    }

    protected override bool FilterFunc(PersonViewModel viewModel, string search)
    {
        return search.IsNullOrEmpty() ||
               viewModel.DisplayName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               viewModel.FirstName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               viewModel.LastName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               viewModel.LegalName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               CultureInfo.CurrentCulture.CompareInfo.IndexOf(viewModel.LegalName,
                                                              search,
                                                              CompareOptions.IgnoreNonSpace) > -1 ||
               CultureInfo.CurrentCulture.CompareInfo.IndexOf(viewModel.DisplayName,
                                                              search,
                                                              CompareOptions.IgnoreNonSpace) > -1 ||
               CultureInfo.CurrentCulture.CompareInfo.IndexOf(viewModel.FirstName,
                                                              search,
                                                              CompareOptions.IgnoreNonSpace) > -1 ||
               CultureInfo.CurrentCulture.CompareInfo.IndexOf(viewModel.LastName,
                                                              search,
                                                              CompareOptions.IgnoreNonSpace) > -1;
    }
}
