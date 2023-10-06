namespace Memorabilia.Application.Features.Services.Interfaces;

public interface IApplicationStateService
{
    Entity.User CurrentUser { get; set; }

    bool IsDarkTheme { get; set; }

    Task Load(int userId);

    void Logout();

    Constant.LoginProvider Provider { get; set; }

    void Set(Entity.User user);

    string SubscriberLevel { get; }
}
