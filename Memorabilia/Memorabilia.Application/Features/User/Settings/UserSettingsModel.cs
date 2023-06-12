namespace Memorabilia.Application.Features.User.Settings;

public class UserSettingsModel : Model
{
    public UserSettingsModel() { }

    public override string PageTitle 
        => "User Settings";

    public string DashboardImageFileName 
        => Constant.ImageFileName.Dashboard;
}
