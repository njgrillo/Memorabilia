namespace Memorabilia.Domain.Entities;

public class UserSettings : Framework.Library.Domain.Entity.DomainEntity
{
    public UserSettings() { }

    public UserSettings(int userId, bool useDarkTheme)
    {
        UseDarkTheme = useDarkTheme;
        UserId = userId;
    }

    public bool UseDarkTheme { get; private set; }

    public int UserId { get; private set; }

    public void Set(bool useDarkTheme)
    {
        UseDarkTheme = useDarkTheme;
    }
}
