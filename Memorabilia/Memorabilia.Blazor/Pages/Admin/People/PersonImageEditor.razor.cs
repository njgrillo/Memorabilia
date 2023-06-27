﻿namespace Memorabilia.Blazor.Pages.Admin.People;

public partial class PersonImageEditor 
    : EditPersonItem<PersonImageEditModel, PersonImageModel>
{
    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public ILogger<PersonImageEditor> Logger { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    private bool _hasImage;    

    protected override async Task OnInitializedAsync()
    {
        Entity.Person person = await QueryRouter.Send(new GetPerson(PersonId));

        EditModel = person.ToImageEditModel();

        _hasImage = !EditModel.PersonImageFileName.IsNullOrEmpty();

        IsLoaded = true;
    }

    protected async Task Save()
    {
        EditModeType editModeType = EditModel.Id > 0
            ? EditModeType.Update
            : EditModeType.Add;

        await HandleValidSubmit(new SavePersonImage(EditModel.PersonId, EditModel.PersonImageFileName));

        NavigationManager.NavigateTo(EditModel.SaveReturnNavigationPath);

        Snackbar.Add($"{EditModel.ItemTitle} {(EditModel.ItemTitle.EndsWith("s") ? "were " : "was ")} {editModeType.ToEditModeTypeNamePastTense()} successfully!", Severity.Success);
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

    private void Remove()
    {
        EditModel.PersonImageFileName = null;
        _hasImage = false;
    }
}
