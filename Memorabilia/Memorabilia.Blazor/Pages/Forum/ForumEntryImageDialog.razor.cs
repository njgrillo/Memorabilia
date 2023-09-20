namespace Memorabilia.Blazor.Pages.Forum;

public partial class ForumEntryImageDialog
{
    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public ImageService ImageService { get; set; }

    [CascadingParameter]
    public MudDialogInstance MudDialog { get; set; }

    [Parameter]
    public int MaximumImagesAllowed { get; set; }
        = 3;

    protected List<ImageEditModel> Images { get; set; }
        = new();

    private IReadOnlyList<IBrowserFile> _files;

    protected void Add()
    {
        MudDialog.Close(DialogResult.Ok(Images));
    }

    protected void Cancel()
    {
        MudDialog.Cancel();
    }

    protected async Task LoadFiles(InputFileChangeEventArgs e)
    {
        _files = e.GetMultipleFiles(MaximumImagesAllowed);

        foreach (IBrowserFile file in _files)
        {
            string fileName = await ImageService.LoadFile(file, Enum.ImageRootType.User);

            Images.Add(new ImageEditModel(new ImageModel(new Entity.Image(fileName))));
        }        
    }

    protected void Remove(string fileName)
    {
        ImageEditModel image = Images.FirstOrDefault(i => i.FileName == fileName);

        if (image == null)
            return;

        Images.Remove(image);
    }
}
