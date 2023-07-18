namespace Memorabilia.Blazor.Pages.Admin.Management; 

public partial class ManageItems 
{
    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }
}
