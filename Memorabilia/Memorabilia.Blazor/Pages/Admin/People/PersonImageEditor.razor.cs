namespace Memorabilia.Blazor.Pages.Admin.People;

public partial class PersonImageEditor 
    : EditPersonItem<PersonImageEditModel, PersonImageModel>
{
    [Inject]
    public ILogger<PersonImageEditor> Logger { get; set; }

    [Parameter]
    public string PersonImageRootPath { get; set; }

    private bool _hasImage;

    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SavePersonImage(EditModel.PersonId, EditModel.PersonImageFileName));
    }

    protected async Task OnLoad()
    {
        Entity.Person person = await QueryRouter.Send(new GetPerson(PersonId));

        EditModel = person.ToImageEditModel();

        _hasImage = !EditModel.PersonImageFileName.IsNullOrEmpty();
    }

    private async Task LoadFile(InputFileChangeEventArgs e)
    {
        IBrowserFile file = e.File;

        try
        {
            if (!Directory.Exists(PersonImageRootPath))
                Directory.CreateDirectory(PersonImageRootPath);

            string fileName = Path.GetRandomFileName();
            string path = Path.Combine(PersonImageRootPath, fileName);

            await using FileStream fs = new(path, FileMode.Create);
            await file.OpenReadStream(5120000).CopyToAsync(fs);

            EditModel.PersonImageFileName = fileName;
            _hasImage = true;
        }
        catch (Exception ex)
        {
            Logger.LogError("File: {Filename} Error: {Error}", file.Name, ex.Message);
        }
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
