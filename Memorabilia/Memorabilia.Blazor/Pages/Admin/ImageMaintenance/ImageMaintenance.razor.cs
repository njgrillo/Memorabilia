

namespace Memorabilia.Blazor.Pages.Admin.ImageMaintenance;

public partial class ImageMaintenance : CommandQuery
{
    [Parameter]
    public string MemorabiliaImageRootPath { get; set; }

    [Parameter]
    public string PersonImageRootPath { get; set; }

    private ImageMaintenanceViewModel _viewModel = new();

    protected override async Task OnInitializedAsync()
    {
        _viewModel = await QueryRouter.Send(new GetImageMaintenance(MemorabiliaImageRootPath, PersonImageRootPath));
    }

    private void Delete()
    {
        if (!_viewModel.OrphanedImageFileNames.Any())
            return;

        foreach (var file in _viewModel.OrphanedImageFileNames)
        {
            var found = false;

            foreach (var directory in Directory.GetDirectories(MemorabiliaImageRootPath))
            {
                var path = Path.Combine(directory, file);

                if (File.Exists(path))
                {
                    found = true;
                    File.Delete(path);
                    break;
                }
            }

            if (!found)
            {
                var path = Path.Combine(PersonImageRootPath, file);

                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        foreach (var imageFile in _viewModel.OrphanedImageFileNames)
        {
            if (File.Exists(Path.Combine(MemorabiliaImageRootPath, imageFile)))
            {
                File.Delete(imageFile);
                continue;
            }

            if (File.Exists(Path.Combine(PersonImageRootPath, imageFile)))
            {
                File.Delete(imageFile);
                continue;
            }
        }
    }
}
