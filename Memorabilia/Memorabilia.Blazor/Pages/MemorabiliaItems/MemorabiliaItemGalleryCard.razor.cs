using Memorabilia.Application.Services.Interfaces;

namespace Memorabilia.Blazor.Pages.MemorabiliaItems;

public partial class MemorabiliaItemGalleryCard
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public string Description { get; set; }  

    [Parameter]
    public string EditNavigationPath { get; set; }

    [Parameter]
    public MemorabiliaGalleryItemModel MemorabiliaItem { get; set; }

    [Parameter]
    public string PrimaryImageFileName { get; set; }

    [Parameter]
    public string PrimaryImageNavigationPath { get; set; }    

    [Parameter]
    public string Subtitle { get; set; }

    [Parameter]
    public string Title { get; set; }

    [Parameter]
    public string TooltipText { get; set; }    

    protected void OnEditClick()
    {
        NavigationManager.NavigateTo(EditNavigationPath);
    }

    protected void OnPrimaryImageClick()
    {
        NavigationManager.NavigateTo(PrimaryImageNavigationPath);
    }

    private string GetImageNavigationPath(AutographGalleryModel model)
        => model.Person.Sports.Count != 0
            ? $"/Tools/{model.Person.Sports.First().Sport.Name}Profile/{DataProtectorService.EncryptId(model.Person.Id)}"
            : NavigationPath.PersonProfile;
}
