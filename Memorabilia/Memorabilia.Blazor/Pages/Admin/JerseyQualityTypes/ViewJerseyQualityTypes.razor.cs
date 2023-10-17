namespace Memorabilia.Blazor.Pages.Admin.JerseyQualityTypes;

public partial class ViewJerseyQualityTypes 
    : ViewDomainItem<JerseyQualityTypesModel>
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await Mediator.Send(new SaveJerseyQualityType(editModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Model = new JerseyQualityTypesModel(await Mediator.Send(new GetJerseyQualityTypes()));
    }
}
