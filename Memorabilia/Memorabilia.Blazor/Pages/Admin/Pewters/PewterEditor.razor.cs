namespace Memorabilia.Blazor.Pages.Admin.Pewters;

public partial class PewterEditor 
    : EditItem<PewterEditModel, PewterModel>
{
    [Inject]
    public ILogger<PewterEditor> Logger { get; set; }

    private bool _hasImage;

    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SavePewter(ViewModel));
    }

    protected async Task OnLoad()
    {
        if (Id == 0)
            return;

        ViewModel = new PewterEditModel(new PewterModel(await QueryRouter.Send(new GetPewter(Id))));

        _hasImage = !ViewModel.FileName.IsNullOrEmpty();
    }

    private async Task LoadFile(InputFileChangeEventArgs e)
    {
        var file = e.File;

        try
        {
            if (!Directory.Exists(ImagePath.PewterImageRootPath))
                Directory.CreateDirectory(ImagePath.PewterImageRootPath);

            var fileName = Path.GetRandomFileName();
            var path = Path.Combine(ImagePath.PewterImageRootPath, fileName);

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
