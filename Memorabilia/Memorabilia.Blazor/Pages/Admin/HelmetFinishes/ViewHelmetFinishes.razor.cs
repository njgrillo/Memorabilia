namespace Memorabilia.Blazor.Pages.Admin.HelmetFinishes;

public partial class ViewHelmetFinishes 
    : ViewDomainItem<HelmetFinishesModel>
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await CommandRouter.Send(new SaveHelmetFinish(editModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Model = new HelmetFinishesModel(await QueryRouter.Send(new GetHelmetFinishes()));
    }
}
