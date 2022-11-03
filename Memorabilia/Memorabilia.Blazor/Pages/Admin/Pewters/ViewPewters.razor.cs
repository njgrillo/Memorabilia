#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.Pewters;

public partial class ViewPewters : ViewItem<PewtersViewModel, PewterViewModel>
{
    [Parameter]
    public string PewterImageRootPath { get; set; }

    protected string GetImage(string imagePath)
    {
        var path = imagePath == ImagePath.ImageNotAvailable
                ? imagePath
                : Path.Combine(PewterImageRootPath, imagePath);

        return $"data:image/jpg;base64,{Convert.ToBase64String(File.ReadAllBytes(path))}";
    }

    protected async Task OnLoad()
    {
        await OnLoad(new GetPewters());
    }

    protected override async Task Delete(int id)
    {
        var deletedItem = ViewModel.Pewters.Single(pewter => pewter.Id == id);
        var viewModel = new SavePewterViewModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SavePewter(viewModel));

        ViewModel.Pewters.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(ViewModel.ItemTitle);
    }

    protected override bool FilterFunc(PewterViewModel viewModel, string search)
    {
        return search.IsNullOrEmpty() ||
               viewModel.FranchiseName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               viewModel.TeamName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               viewModel.SizeName.Contains(search, StringComparison.OrdinalIgnoreCase);
    }
}
