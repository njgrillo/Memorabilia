namespace Memorabilia.Blazor.Pages.Admin.FigureSpecialtyTypes;

public partial class FigureSpecialtyTypeEditor : EditDomainItem<FigureSpecialtyType>, IEditDomainItem
{
    public async Task OnLoad()
    {
        await OnLoad(new GetFigureSpecialtyType.Query(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveFigureSpecialtyType.Command(ViewModel));
    }
}
