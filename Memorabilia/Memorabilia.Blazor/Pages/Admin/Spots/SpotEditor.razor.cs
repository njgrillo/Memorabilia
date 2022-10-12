namespace Memorabilia.Blazor.Pages.Admin.Spots;

public partial class SpotEditor : EditDomainItem<Spot>, IEditDomainItem
{
    public async Task OnLoad()
    {
        await OnLoad(new Application.Features.Admin.Spots.GetSpot.Query(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new Application.Features.Admin.Spots.SaveSpot.Command(ViewModel));
    }
}
