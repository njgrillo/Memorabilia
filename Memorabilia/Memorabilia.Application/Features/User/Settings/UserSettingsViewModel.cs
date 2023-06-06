namespace Memorabilia.Application.Features.User.Settings;

public class UserSettingsViewModel : Model
{
    public UserSettingsViewModel() { }

    public override string PageTitle => "User Settings";

    public string DashboardImageFileName => Constant.ImageFileName.Dashboard;
}
