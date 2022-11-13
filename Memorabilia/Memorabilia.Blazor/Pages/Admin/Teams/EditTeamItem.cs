#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.Teams;

public abstract class EditTeamItem<TSaveViewModel, TViewModel> : EditItem<TSaveViewModel, TViewModel>
{
    [Parameter]
    public int SportLeagueLevelId { get; set; }

    [Parameter]
    public int TeamId { get; set; }

    protected override void Initialize()
    {
        ViewModel = (TSaveViewModel)Activator.CreateInstance(typeof(TSaveViewModel), TeamId);
    }
}
