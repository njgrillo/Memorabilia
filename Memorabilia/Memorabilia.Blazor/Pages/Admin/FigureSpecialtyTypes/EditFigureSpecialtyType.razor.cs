namespace Memorabilia.Blazor.Pages.Admin.FigureSpecialtyTypes;

public partial class EditFigureSpecialtyType
    : EditDomainItem<FigureSpecialtyType>
{
    protected override async Task OnInitializedAsync()
    {
        await OnLoad(new GetFigureSpecialtyType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveFigureSpecialtyType(EditModel));
    }
}
