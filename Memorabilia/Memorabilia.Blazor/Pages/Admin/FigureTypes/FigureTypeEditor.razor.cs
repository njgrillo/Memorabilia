namespace Memorabilia.Blazor.Pages.Admin.FigureTypes;

public partial class FigureTypeEditor  
    : EditDomainItem<FigureType>
{
    protected override async Task OnInitializedAsync()
    {
        await OnLoad(new GetFigureType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveFigureType(EditModel));
    }
}
