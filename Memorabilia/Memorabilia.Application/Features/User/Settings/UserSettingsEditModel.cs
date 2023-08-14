namespace Memorabilia.Application.Features.User.Settings;

public class UserSettingsEditModel
{
	public UserSettingsEditModel() { }

	public UserSettingsEditModel(Entity.User user)
	{
		UseDarkTheme = user.UserSettings?.UseDarkTheme ?? false;
    }

    public bool UseDarkTheme { get; set; }
}
