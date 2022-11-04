#nullable disable

namespace Memorabilia.Blazor.Pages.Tools.Baseball;

public partial class ViewCareerRecords : CommandQuery
{
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public string PersonImageRootPath { get; set; }

    protected bool FilterFunc1(CareerRecordViewModel viewModel) => FilterFunc(viewModel, Search);
    protected string Search;

    private CareerRecordsViewModel _viewModel = new();

    protected bool FilterFunc(CareerRecordViewModel viewModel, string search)
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

    protected override async Task OnInitializedAsync()
    {
        _viewModel = await QueryRouter.Send(new GetCareerRecords(Sport.Baseball.Id));
    }
}