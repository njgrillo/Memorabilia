

namespace Memorabilia.Blazor.Pages.Admin.Pewters;

public partial class PewterEditor : EditItem<SavePewterViewModel, PewterViewModel>
{
    [Inject]
    public ILogger<PewterEditor> Logger { get; set; }

    [Parameter]
    public string PewterImageRootPath { get; set; }

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

        _hasImage = !ViewModel.FileName.IsNullOrEmpty();
    }

    private async Task LoadFile(InputFileChangeEventArgs e)
    {
        var file = e.File;

        try
        {
            if (!Directory.Exists(PewterImageRootPath))
                Directory.CreateDirectory(PewterImageRootPath);

            var fileName = Path.GetRandomFileName();
            var path = Path.Combine(PewterImageRootPath, fileName);

            await using FileStream fs = new(path, FileMode.Create);
            await file.OpenReadStream(5120000).CopyToAsync(fs);

            ViewModel.FileName = fileName;
            _hasImage = true;
        }
        catch (Exception ex)
        {
            Logger.LogError("File: {Filename} Error: {Error}", file.Name, ex.Message);
        }
    }

    private void Remove()
    {
        ViewModel.FileName = null;
        _hasImage = false;
    }
}
