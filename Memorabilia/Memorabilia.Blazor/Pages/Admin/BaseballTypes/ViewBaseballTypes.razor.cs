namespace Memorabilia.Blazor.Pages.Admin.BaseballTypes;

public partial class ViewBaseballTypes 
    : ViewDomainItem<BaseballTypesModel>
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await Mediator.Send(new SaveBaseballType(editModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Model = new BaseballTypesModel(await Mediator.Send(new GetBaseballTypes()));
    }
}
