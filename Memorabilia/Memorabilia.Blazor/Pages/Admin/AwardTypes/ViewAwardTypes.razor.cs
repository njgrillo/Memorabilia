namespace Memorabilia.Blazor.Pages.Admin.AwardTypes;

public partial class ViewAwardTypes 
    : ViewDomainItem<AwardTypesModel>
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await OnDelete(new SaveAwardType(editModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Model = new AwardTypesModel(await Mediator.Send(new GetAwardTypes()));
    }
}
