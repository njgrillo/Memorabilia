namespace Memorabilia.Blazor.Pages.Admin.People;

public partial class PersonImageEditor 
    : EditPersonItem<PersonImageEditModel, PersonImageModel>
{
    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public ILogger<PersonImageEditor> Logger { get; set; }

    private bool _hasImage;

    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SavePersonImage(EditModel.PersonId, EditModel.PersonImageFileName));
    }

    protected override async Task OnInitializedAsync()
    {
        Entity.Person person = await QueryRouter.Send(new GetPerson(PersonId));

        EditModel = person.ToImageEditModel();

        _hasImage = !EditModel.PersonImageFileName.IsNullOrEmpty();

        IsLoaded = true;
    }

    private async Task LoadFile(InputFileChangeEventArgs e)
    {
        try
        {
            EditModel.PersonImageFileName = await ImageService.LoadFile(e.File, Enum.ImageRootType.People);
        }
        catch (Exception ex)
        {
            Logger.LogError("File: {Filename} Error: {Error}", e.File.Name, ex.Message);
        }

        _hasImage = true;
    }

    protected void OnSaveReturnClick()
    {
        EditModel.ExitNavigationPath = EditModel.SaveReturnNavigationPath;
    }

    private void Remove()
    {
        EditModel.PersonImageFileName = null;
        _hasImage = false;
    }
}
