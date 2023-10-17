namespace Memorabilia.Blazor.Pages.Admin.Sizes;

public partial class ViewSizes 
    : ViewDomainItem<SizesModel>
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await OnDelete(new SaveSize(editModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Model = new SizesModel(await Mediator.Send(new GetSizes()));
    }
}
