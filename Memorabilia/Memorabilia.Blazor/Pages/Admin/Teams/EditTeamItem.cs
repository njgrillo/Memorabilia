namespace Memorabilia.Blazor.Pages.Admin.Teams;

public abstract class EditTeamItem<TSaveModel, TModel> 
    : EditItem<TSaveModel, TModel>
{
    [Parameter]
    public int SportLeagueLevelId { get; set; }

    [Parameter]
    public int TeamId { get; set; }

    protected override void Initialize()
    {
        EditModel = (TSaveModel)Activator.CreateInstance(typeof(TSaveModel), TeamId);
    }
}
