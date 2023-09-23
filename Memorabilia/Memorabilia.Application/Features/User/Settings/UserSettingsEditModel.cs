namespace Memorabilia.Application.Features.User.Settings;

public class UserSettingsEditModel
{
	public UserSettingsEditModel() { }

	public UserSettingsEditModel(Entity.User user)
	{
		GoogleEmailAddress = user.UserSettings?.GoogleEmailAddress ?? string.Empty;
        MicrosoftEmailAddress = user.UserSettings?.MicrosoftEmailAddress ?? string.Empty;
		UseDarkTheme = user.UserSettings?.UseDarkTheme ?? false;
		XHandle = user.UserSettings?.XHandle ?? string.Empty;
    }

	public string GoogleEmailAddress { get; set; }

	public string MicrosoftEmailAddress { get; set; }

    public bool UseDarkTheme { get; set; }

	public string XHandle { get; set; }
}
