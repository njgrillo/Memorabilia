namespace Memorabilia.Blazor.Pages.Admin.InternationalHallOfFameTypes;

public partial class ViewInternationalHallOfFameTypes 
    : ViewDomainItem<InternationalHallOfFameTypesModel>
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await Mediator.Send(new SaveInternationalHallOfFameType(editModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Model = new InternationalHallOfFameTypesModel(await Mediator.Send(new GetInternationalHallOfFameTypes()));
    }
}
