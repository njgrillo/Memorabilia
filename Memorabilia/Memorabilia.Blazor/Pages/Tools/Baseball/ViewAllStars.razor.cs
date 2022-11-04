#nullable disable

namespace Memorabilia.Blazor.Pages.Tools.Baseball;

public partial class ViewAllStars : CommandQuery
{
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public string PersonImageRootPath { get; set; }

    protected bool FilterFunc1(AllStarViewModel viewModel) => FilterFunc(viewModel, Search);
    protected string Search;

    private AllStarsViewModel _viewModel = new();

    protected bool FilterFunc(AllStarViewModel viewModel, string search)
    {
        return search.IsNullOrEmpty() ||
               viewModel.PersonName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               CultureInfo.CurrentCulture.CompareInfo.IndexOf(viewModel.PersonName,
                                                              search,
                                                              CompareOptions.IgnoreNonSpace) > -1;
    }

    protected string GetImage(string imagePath)
    {
        var path = imagePath == ImagePath.ImageNotAvailable
                ? imagePath
                : Path.Combine(PersonImageRootPath, imagePath);

        return $"data:image/jpg;base64,{Convert.ToBase64String(File.ReadAllBytes(path))}";
    }

    private async Task OnInputChange(int awardTypeId)
    {
        _viewModel = await QueryRouter.Send(new GetAllStars(awardTypeId));
    }
}
