#nullable disable

namespace Memorabilia.Blazor.Pages.Tools.Baseball;

public partial class ViewLeaders : CommandQuery
{
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public string PersonImageRootPath { get; set; }

    protected bool FilterFunc1(LeaderViewModel viewModel) => FilterFunc(viewModel, Search);
    protected string Search;

    private LeadersViewModel _viewModel = new();

    protected bool FilterFunc(LeaderViewModel viewModel, string search)
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

    private async Task OnInputChange(int leaderTypeId)
    {
        _viewModel = await QueryRouter.Send(new GetLeaders(leaderTypeId));
    }
}
