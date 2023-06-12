namespace Memorabilia.Blazor.Pages.Admin.Pewters;

public partial class PewterEditor 
    : EditItem<PewterEditModel, PewterModel>
{
    [Inject]
    public ILogger<PewterEditor> Logger { get; set; }

    private bool _hasImage;

    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SavePewter(EditModel));
    }

    protected async Task OnLoad()
    {
        if (Id == 0)
            return;

        EditModel = (await QueryRouter.Send(new GetPewter(Id))).ToEditModel();

        _hasImage = !EditModel.FileName.IsNullOrEmpty();
    }

    private async Task LoadFile(InputFileChangeEventArgs e)
    {
        IBrowserFile file = e.File;

        try
        {
            if (!Directory.Exists(ImagePath.PewterImageRootPath))
                Directory.CreateDirectory(ImagePath.PewterImageRootPath);

            string fileName = Path.GetRandomFileName();
            string path = Path.Combine(ImagePath.PewterImageRootPath, fileName);

            await using FileStream fs = new(path, FileMode.Create);
            await file.OpenReadStream(5120000).CopyToAsync(fs);

            EditModel.FileName = fileName;
            _hasImage = true;
        }
        catch (Exception ex)
        {
            Logger.LogError("File: {Filename} Error: {Error}", file.Name, ex.Message);
        }
    }

    private void Remove()
    {
        EditModel.FileName = null;
        _hasImage = false;
    }
}
