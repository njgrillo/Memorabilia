namespace Memorabilia.Domain.Entities;

public class UserSettings : Entity
{
    public UserSettings() { }

    public UserSettings(int userId, 
                        bool useDarkTheme,
                        string googleEmailAddress,
                        string microsoftEmailAddress,
                        string xHandle)
    {
        GoogleEmailAddress = googleEmailAddress;
        MicrosoftEmailAddress = microsoftEmailAddress;
        UseDarkTheme = useDarkTheme;
        UserId = userId;
        XHandle = xHandle;
    }

    public string GoogleEmailAddress { get; private set; }

    public string MicrosoftEmailAddress { get; private set; }

    public bool UseDarkTheme { get; private set; }

    public int UserId { get; private set; }

    public string XHandle { get; private set; }

    public void Set(bool useDarkTheme,
                    string googleEmailAddress,
                    string microsoftEmailAddress,
                    string xHandle)
    {
        GoogleEmailAddress = googleEmailAddress;
        MicrosoftEmailAddress = microsoftEmailAddress;
        UseDarkTheme = useDarkTheme;
        XHandle = xHandle;
    }
}
