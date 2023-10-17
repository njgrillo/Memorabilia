namespace Memorabilia.Blazor.Pages.Admin.ImageTypes;

public partial class ViewImageTypes 
    : ViewDomainItem<ImageTypesModel>
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await Mediator.Send(new SaveImageType(editModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Model = new ImageTypesModel(await Mediator.Send(new GetImageTypes()));
    }
}
