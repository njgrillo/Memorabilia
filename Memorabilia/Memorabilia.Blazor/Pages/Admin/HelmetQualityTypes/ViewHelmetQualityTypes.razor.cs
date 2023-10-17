namespace Memorabilia.Blazor.Pages.Admin.HelmetQualityTypes;

public partial class ViewHelmetQualityTypes 
    : ViewDomainItem<HelmetQualityTypesModel>
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await Mediator.Send(new SaveHelmetQualityType(editModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Model = new HelmetQualityTypesModel(await Mediator.Send(new GetHelmetQualityTypes()));
    }
}
