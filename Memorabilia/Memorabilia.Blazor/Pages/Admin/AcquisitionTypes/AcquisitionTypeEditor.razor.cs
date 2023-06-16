namespace Memorabilia.Blazor.Pages.Admin.AcquisitionTypes;

public partial class AcquisitionTypeEditor 
    : EditDomainItem<AcquisitionType>
{
    protected override async Task OnInitializedAsync()
    {
        await OnLoad(new GetAcquisitionType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveAcquisitionType(EditModel));
    }
}
