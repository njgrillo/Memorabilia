#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.Pewters;

public partial class PewterEditor : EditItem<SavePewterViewModel, PewterViewModel>
{
    [Inject]
    public ILogger<PewterEditor> Logger { get; set; }

    [Parameter]
    public string ImageDirectoryPath { get; set; }

    private bool _hasImage;

    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SavePewter(ViewModel));
    }

    protected async Task OnLoad()
    {
        if (Id == 0)
            return;

        ViewModel = new SavePewterViewModel(await Get(new GetPewter(Id)));

        _hasImage = !ViewModel.ImagePath.IsNullOrEmpty();
    }

    private async Task LoadFile(InputFileChangeEventArgs e)
    {
        var file = e.File;

        try
        {
            var directory = Path.Combine(ImageDirectoryPath, "wwwroot/siteimages/pewters");

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            var fileName = Path.GetRandomFileName();
            var path = Path.Combine(directory, fileName);

            await using FileStream fs = new(path, FileMode.Create);
            await file.OpenReadStream(5120000).CopyToAsync(fs);

            ViewModel.ImagePath = $"wwwroot/siteimages/pewters/{fileName}";
            _hasImage = true;
        }
        catch (Exception ex)
        {
            Logger.LogError("File: {Filename} Error: {Error}", file.Name, ex.Message);
        }
    }

    private void Remove()
    {
        ViewModel.ImagePath = null;
        _hasImage = false;
    }
}
