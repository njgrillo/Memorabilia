namespace Memorabilia.Blazor.Pages.Admin.ImageMaintenance;

public partial class ImageMaintenance : CommandQuery
{
    [Parameter]
    public string MemorabiliaImageRootPath { get; set; }

    [Parameter]
    public string PersonImageRootPath { get; set; }

    protected ImageMaintenanceModel Model 
        = new();

    protected override async Task OnInitializedAsync()
    {
        Model = await QueryRouter.Send(new GetImageMaintenance(MemorabiliaImageRootPath, PersonImageRootPath));
    }

    private void Delete()
    {
        if (!Model.OrphanedImageFileNames.Any())
            return;

        foreach (string file in Model.OrphanedImageFileNames)
        {
            bool found = false;

            foreach (string directory in Directory.GetDirectories(MemorabiliaImageRootPath))
            {
                string path = Path.Combine(directory, file);

                if (File.Exists(path))
                {
                    found = true;
                    File.Delete(path);
                    break;
                }
            }

            if (!found)
            {
                string path = Path.Combine(PersonImageRootPath, file);

                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        foreach (string imageFile in Model.OrphanedImageFileNames)
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
