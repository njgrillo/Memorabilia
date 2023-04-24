﻿

namespace Memorabilia.Blazor.Pages.Admin.People;

public partial class PersonImageEditor : EditPersonItem<SavePersonImageViewModel, PersonImageViewModel>
{
    [Inject]
    public ILogger<PersonImageEditor> Logger { get; set; }

    [Parameter]
    public string PersonImageRootPath { get; set; }

    private bool _hasImage;

    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SavePersonImage.Command(ViewModel));
    }

    protected async Task OnLoad()
    {
        ViewModel = new SavePersonImageViewModel(await Get(new GetPersonImage(PersonId)));
        _hasImage = !ViewModel.PersonImageFileName.IsNullOrEmpty();
    }

    private async Task LoadFile(InputFileChangeEventArgs e)
    {
        var file = e.File;

        try
        {
            if (!Directory.Exists(PersonImageRootPath))
                Directory.CreateDirectory(PersonImageRootPath);

            var fileName = Path.GetRandomFileName();
            var path = Path.Combine(PersonImageRootPath, fileName);

            await using FileStream fs = new(path, FileMode.Create);
            await file.OpenReadStream(5120000).CopyToAsync(fs);

            ViewModel.PersonImageFileName = fileName;
            _hasImage = true;
        }
        catch (Exception ex)
        {
            Logger.LogError("File: {Filename} Error: {Error}", file.Name, ex.Message);
        }
    }

    protected void OnSaveReturnClick()
    {
        ViewModel.ExitNavigationPath = ViewModel.SaveReturnNavigationPath;
    }

    private void Remove()
    {
        ViewModel.PersonImageFileName = null;
        _hasImage = false;
    }
}
