namespace Memorabilia.Blazor.Pages.Admin.Spots;

public partial class SpotEditor 
    : EditDomainItem<Spot>
{
    protected override async Task OnInitializedAsync()
    {
        await OnLoad(new Application.Features.Admin.Spots.GetSpot(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new Application.Features.Admin.Spots.SaveSpot(EditModel));
    }
}
