namespace Memorabilia.Blazor.Pages.Admin.FigureTypes;

public partial class FigureTypeEditor  : EditDomainItem<FigureType>, IEditDomainItem
{
    public async Task OnLoad()
    {
        await OnLoad(new GetFigureType.Query(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveFigureType.Command(ViewModel));
    }
}
