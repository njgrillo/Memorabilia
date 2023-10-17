namespace Memorabilia.Blazor.Pages.Admin.Colors;

public partial class ViewColors 
    : ViewDomainItem<ColorsModel>
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await Mediator.Send(new SaveColor(editModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Model = new ColorsModel(await Mediator.Send(new GetColors()));
    }
}
