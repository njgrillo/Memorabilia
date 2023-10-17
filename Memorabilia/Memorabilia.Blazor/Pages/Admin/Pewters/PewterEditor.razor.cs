namespace Memorabilia.Blazor.Pages.Admin.Pewters;

public partial class PewterEditor 
    : EditItem<PewterEditModel, PewterModel>
{
    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public ILogger<PewterEditor> Logger { get; set; }

    private bool _hasImage;    

    protected override async Task OnInitializedAsync()
    {
        if (Id == 0)
            return;

        EditModel = (await Mediator.Send(new GetPewter(Id))).ToEditModel();

        _hasImage = !EditModel.FileName.IsNullOrEmpty();
    }

    protected async Task Save()
    {
        await Save(new SavePewter(EditModel));
    }

    private async Task LoadFile(InputFileChangeEventArgs e)
    {
        try
        {
            EditModel.FileName = await ImageService.LoadFile(e.File, Enum.ImageRootType.Pewter);            
        }
        catch (Exception ex)
        {
            Logger.LogError("File: {Filename} Error: {Error}", e.File.Name, ex.Message);
        }

        _hasImage = true;
    }

    private void Remove()
    {
        EditModel.FileName = null;
        _hasImage = false;
    }
}
