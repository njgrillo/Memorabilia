namespace Memorabilia.Blazor.Pages.Admin.PrivacyTypes;

public partial class ViewPrivacyTypes 
    : ViewDomainItem<PrivacyTypesModel>
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await OnDelete(new SavePrivacyType(editModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Model = new PrivacyTypesModel(await Mediator.Send(new GetPrivacyTypes()));
    }
}
